using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using Microsoft.Extensions.Options;


namespace SpecFlowProject3.StepDefinitions
{  
    [Binding]
    public class SomeTestsOnWww_Liaisongroup_ComStepDefinitions
    {
        string path = @"c:\websites\test\selenium\chrome\";
        //opt.BinaryLocation = path + "chrome.exe";
        //driver = new ChromeDriver(path, opt);
        //IWebDriver driver = new ChromeDriver("chromedriver.exe");
       
        IWebDriver driver = new ChromeDriver();
        
        [Given(@"the user is on the ""([^""]*)"" page")]
        public void GivenTheUserIsOnThePage(string url)

        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()='Accept']")).Click();
            Thread.Sleep(3000);
            String actualUrl = driver.Url;
            Assert.AreEqual(url, actualUrl);
            driver.Quit();

        }

        [Given(@"the user navigates to the ""([^""]*)"" on the website")]
        public void GivenTheUserNavigatesToTheOnTheWebsite(string urlExpected)
        {
           // String actualUrl = driver.Title;
           // Assert.AreEqual(urlExpected, actualUrl);
            //driver.Quit();
        }

        [Then(@"the url should be  ""([^""]*)""")]
        public void ThenTheUrlShouldBe(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user selects an event from the ""([^""]*)"" dropdown")]
        public void WhenTheUserSelectsAnEventFromTheDropdown(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user fills in the ""([^""]*)"" field with ""([^""]*)""")]
        public void WhenTheUserFillsInTheFieldWith(string message, string p1)
        {
            throw new PendingStepException();
        }

        [When(@"the user submits the form")]
        public void WhenTheUserSubmitsTheForm()
        {
            throw new PendingStepException();
        }

        [Then(@"the user should see a confirmation message saying ""([^""]*)""")]
        public void ThenTheUserShouldSeeAConfirmationMessageSaying(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"an email should be sent to ""([^""]*)"" confirming the submission and providing next steps")]
        public void ThenAnEmailShouldBeSentToConfirmingTheSubmissionAndProvidingNextSteps(string p0)
        {
            throw new PendingStepException();
        }

    }
}
