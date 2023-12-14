using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BritishAirways.Pages
{
    public class ManagePage
    {
        private IWebDriver driver;
        public ManagePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
