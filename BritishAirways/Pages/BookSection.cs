using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BritishAirways.Pages
{
    public class BookSection
    {
        private IWebDriver driver;
        public BookSection(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
