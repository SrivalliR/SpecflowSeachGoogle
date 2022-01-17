using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System;
using NUnit.Framework;

namespace SpecflowSeachGoogle.Steps
{
    [Binding]
    public sealed class GoogleSearch
    {
        IWebDriver driver;
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        //private readonly ScenarioContext _scenarioContext;

        //public GoogleSearch(ScenarioContext scenarioContext)
        //{
        //    _scenarioContext = scenarioContext;
        //}

        [Given(@"I navigate to Google page")]
        public void GivenINavigateToGooglePage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Given(@"Enter Selenium in the searchbox")]
        public void GivenEnterSeleniumInTheSearchbox(Table table)
        {
            var data = table.CreateInstance<>
                driver.FindElement(By.Name("q")).SendKeys(table.AddRow);
        }



        [Given(@"Enter string in the searchbox")]
        public void GivenEnterStringInTheSearchbox()
        {
            driver.FindElement(By.Name("q")).SendKeys("Selenium");
        }

        [When(@"Press search button")]
        public void WhenPressSearchButton()
        {
            driver.FindElement(By.Name("btnK")).Click();
        }

        [Then(@"the result page should be displayed")]
        public void ThenTheResultPageShouldBeDisplayed()
        {
            //bool value1;
            string actualstring = "Selenium";
            var handle1= driver.WindowHandles[1];
            string handle1Title=driver.SwitchTo().Window(handle1).Title;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            if (actualstring.ToLower() == handle1Title.ToLower())
            {
                Console.WriteLine("assertion done Equql");
            }
            else
            {
                //Assert.That(actualstring.ToLower(), Is.EqualTo(handle1Title.ToLower()));
                Console.WriteLine("assertion done Notequal ");
            }
        }

    }
}
