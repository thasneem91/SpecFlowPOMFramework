using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace BritishAirways.StepDefinitions
{
    [Binding]
    public class BristishAirwaysHomePageStepDefinitions
    {
        private IWebDriver driver;

        public  BristishAirwaysHomePageStepDefinitions(IWebDriver driver) => driver = driver;

        [Given(@"User opens the browser")]
        public void GivenUserOpensTheBrowser()
        {
            //driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
        }

        [Given(@"User enters the British Airways Url in the brwoser")]
        public void GivenUserEntersTheBritishAirwaysUrlInTheBrwoser()
        {
            driver.Url = "https://www.britishairways.com/travel/home/public/en_in/";
        }

        [When(@"User clicks on British Airways logo")]
        public void WhenUserClicksOnBritishAirwaysLogo()
        {
            IWebElement logo = driver.FindElement(By.XPath("//*[@id='ba-logo-0']"));
            logo.Click();
        }

        [Then(@"British Airways Homepage is launched")]
        public void ThenBritishAirwaysHomepageIsLaunched()
        {

            Console.WriteLine(driver.Title);
            String expectedTitle = "British Airways | Book Flights, Holidays, City Breaks & Check In Online";
            String actualTitle = driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle);

        }
    }
}
