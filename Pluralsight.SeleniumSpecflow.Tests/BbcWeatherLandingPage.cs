using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pluralsight.SeleniumSpecflow.Tests
{
    public class BbcWeatherLandingPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"http://www.bbc.co.uk/weather/";

        [FindsBy(How = How.Id, Using = "locator-form-search")]
        private IWebElement _searchField;

        public BbcWeatherLandingPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public static BbcWeatherLandingPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new BbcWeatherLandingPage(driver);
        }

        public string Search
        {
            set
            {
                _searchField.SendKeys(value);
                _searchField.Submit();
                Thread.Sleep(3000); // ajax calls take about 1 second on a good day, 3 for padding
            }
        }

        
    }
}
