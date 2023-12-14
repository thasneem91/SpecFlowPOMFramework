using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BritishAirways.Pages
{
    public class DiscoverSection
    {
        private IWebDriver driver;
        public DiscoverSection(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
