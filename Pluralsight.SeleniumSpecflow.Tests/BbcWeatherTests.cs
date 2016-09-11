using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Pluralsight.SeleniumSpecflow.Tests
{
    public class BbcWeatherTests
    {
        [Fact]
        public void StartApplication()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://www.bbc.co.uk/weather/");
            }  
        }

        [Fact]
        public void SearchNorwichReturnsResults()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://www.bbc.co.uk/weather/");

                IWebElement searchInput = driver.FindElement(By.Id("locator-form-search"));

                searchInput.SendKeys("Norwich");
                searchInput.Submit();
            }
        }
    }
}
