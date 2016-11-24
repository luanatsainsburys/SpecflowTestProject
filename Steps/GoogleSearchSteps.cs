using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace JS.Plc.Ssc.Link.Portal.Acceptance.Tests.Steps
{
    [Binding]
    class GoogleSearchSteps
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            currentDriver = new Lazy<IWebDriver>(() => new ChromeDriver());
        }

        [AfterScenario]
        public void AfterScenario()
        {
            currentDriver.Value.Close();
        }

        //IWebDriver currentDriver = new ChromeDriver();
        private Lazy<IWebDriver> currentDriver;

        [Given(@"I have navigated to Google page")]
        public void GivenIHaveNavigatedToGooglePage()
        {
            currentDriver.Value.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);
        }

        [Given(@"I see the Google page fully loaded")]
        public void GivenISeeTheGooglePageFullyLoaded()
        {
            if (currentDriver.Value.FindElement(By.TagName("body")).Displayed == true)
                Console.WriteLine("Page loaded fully");
            else
                Console.WriteLine("Page failed to load");
        }

        [When(@"I type search keywords as")]
        public void WhenITypeSearchKeywordsAs(Table table)
        {
            dynamic tableDetail = table.CreateDynamicInstance();
            currentDriver.Value.FindElement(By.TagName("body")).SendKeys(tableDetail.Keyword);
        }

        [Then(@"I should see the result for keword")]
        public void ThenIShouldSeeTheResultForKeword(Table table)
        {
            System.Threading.Thread.Sleep(2000);
            dynamic tableDetail = table.CreateDynamicInstance();
            string key = tableDetail.Keyword;
            if (currentDriver.Value.FindElement(By.PartialLinkText("Execute Automation")).Displayed == true)
                Console.WriteLine("Control exist");
            else
                Console.WriteLine("Control not exist");
        }
    }
}
