using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using Xunit;

namespace Pluralsight.SeleniumSpecflow.Tests
{
    [Binding]
    public class WeatherSteps
    {
        private IWebDriver _driver;
        private BbcWeatherLandingPage _bbcWeatherPage;

        [Given(@"I am on the standard BBC weather screen")]
        public void GivenIAmOnTheStandardBBCWeatherScreen()
        { 
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _bbcWeatherPage = BbcWeatherLandingPage.NavigateTo(_driver);
        }
        
        [When(@"I enter a search term of (.*)")]
        public void WhenIEnterASearchTermOf(string placeName)
        {
            _bbcWeatherPage.Search = placeName;
        }
        
        [Then(@"I should see the weather summary page of (.*)")]
        public void ThenIShouldSeeTheWeatherSummaryPageOf(string placeName)
        {
            // Todo: Use the Page Object Model instead
            Assert.Contains(placeName, _driver.Title);
        }

        [Then(@"I should see a list of places around the world called (.*)")]
        public void ThenIShouldSeeAListOfPlacesAroundTheWorldCalled(string placeName)
        {
            // Todo: Use the Page Object Model instead
            IWebElement resultsElement = _driver.FindElement(By.ClassName("locator-results"));
            var anchors = resultsElement.FindElements(By.TagName("a"));
            Assert.NotEqual(0, anchors.Count);
        }

        [When(@"I select the first search result")]
        public void WhenISelectTheFirstSearchResult()
        {
            // Todo: Use the Page Object Model instead
            IWebElement resultsElement = _driver.FindElement(By.ClassName("locator-results"));
            var anchors = resultsElement.FindElements(By.TagName("a"));
            anchors.First().Click();
        }

        [AfterScenario()]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
