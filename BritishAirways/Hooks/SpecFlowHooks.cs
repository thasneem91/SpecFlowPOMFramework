using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using BritishAirways.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BritishAirways.StepDefinitions
{
    [Binding]
    public sealed class SpecFlowHooks : Report
    {
        private readonly IObjectContainer _container;
        public SpecFlowHooks(IObjectContainer container)
        {
            _container = container;

        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Before Test");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("After Test");
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Before Feature");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
 
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("");
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            _container.RegisterInstanceAs<IWebDriver>(driver);

            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
          var driver = _container.Resolve<IWebDriver>();
            if(driver != null)
            {
                driver.Quit();
            }
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);

                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);

                }
            }

            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message);

                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message);

                }

            }

        }

        [BeforeScenarioBlock]
        public void BeforeScenarioBlock()
        {
            Console.WriteLine("");
        }

        [AfterScenarioBlock]
        public void AfterScenarioBlock()
        {
            Console.WriteLine("");
        }
    }
}