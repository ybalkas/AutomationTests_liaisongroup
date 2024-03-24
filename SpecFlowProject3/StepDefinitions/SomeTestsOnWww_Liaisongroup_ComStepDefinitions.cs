using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using Microsoft.Extensions.Options;
using static System.Net.Mime.MediaTypeNames;
using SpecFlowProject3.Support;
using TechTalk.SpecFlow.Assist;
using SpecFlowProject3.Models;
using OpenQA.Selenium.DevTools.V120.CSS;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Security.Policy;
using FluentAssertions.Common;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework.Internal;
using System.Globalization;
using static System.Net.WebRequestMethods;
using TechTalk.SpecFlow.Time;
using System.Threading.Tasks;


namespace SpecFlowProject3.StepDefinitions
{
    [Binding]
    public class SomeTestsOnWww_Liaisongroup_ComStepDefinitions
    {
        public IWebDriver driver = new ChromeDriver();
        [Given(@"the user is on the ""(.*)"" dashboard")]
        public void GivenTheUserIsOnTheDashboard(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            Utils.ClickElementByText(driver, "Accept");
            Assert.AreEqual(url, driver.Url);
        }

        [Given(@"the user navigates to the ""(.*)"" page")]
        public void GivenTheUserNavigatesToThePage(string text)
        {
            Utils.WaitForElementAndClick(driver, text, 10);

        }

        [Then(@"the url should be  ""([^""]*)""")]
        public void ThenTheUrlShouldBe(string urlExpected)
        {
            Assert.AreEqual(urlExpected, driver.Url);

        }
        [When(@"the user fill in the registration form with the following details")]
        public void WhenTheUserFillInTheRegistrationFormWithTheFollowingDetails(Table table)
        {
            Utils.WaitForElementAndClick(driver, "Book a meeting", 30);
            var details = table.CreateInstance<SelectEventModel>();
            Utils.FillTheForm(details, driver);
        }

        [When(@"user choose an event ""([^""]*)"" from dropdown")]
        public void WhenUserChooseAnEventFromDropdown(string eventName)
        {
            Utils.SelectFromDropdownByGivenLocator(driver, "//*[@id='field_event_dropdown']", eventName);

        }


        [When(@"the user submits the form")]
        public void WhenTheUserSubmitsTheForm()
        {

            Utils.ClickByHoverOverAndActions(driver, "(//button[contains(@class,'frm_final_submit')])[1]");

        }


        [Then(@"the user should see a confirmation message saying ""([^""]*)""")]
        public void ThenTheUserShouldSeeAConfirmationMessageSaying(string confirmMessage)
        {
            try
            {
                string actualMessage = driver.FindElement(By.XPath("//*[text()='Your responses were successfully submitted. Thank you!']")).Text;
                Assert.AreEqual(confirmMessage, actualMessage);
            }
            catch { Console.WriteLine("Something Went Wrong in text verification"); }
            finally { driver.Quit(); }

        }

        [When(@"User clicks Contact and then click Vacancies")]
        public void WhenUserClicksContactAndThenClickVacancies()
        {
            Utils.WaitForElementAndClick(driver, "Contact", "linkText", 30);
            Utils.WaitForElementAndClick(driver, "//span[text()='Vacancies']", "xpath", 30);
            Assert.AreEqual("START YOUR JOB SEARCH HERE", driver.FindElement(By.XPath("//a[text()='Start your job search here']")).Text);

        }

        [Then(@"Careers page ""([^""]*)"" opens")]
        public void ThenCareersPageOpens(string careersPage)
        {
            Assert.AreEqual(careersPage, driver.Url);
        }
        [Then(@"User SHould be able to direct to job search page ""([^""]*)""")]
        public void ThenUserSHouldBeAbleToDirectToJobSearchPage(string urlJobSearch)
        {
            try
            {
                Utils.WaitForElementAndClick(driver, "//a[text()='See our current vacancies here']", "xpath", 30);
    
                // Switch to the new tab
                var newTabHandle = driver.WindowHandles.LastOrDefault();
                if (newTabHandle != null)
                {
                    driver.SwitchTo().Window(newTabHandle);
                    // Get the current URL of the new tab
                    Assert.AreEqual(urlJobSearch, driver.Url);
                }
                driver.FindElement(By.XPath("(//input[@type='search'])[2]")).SendKeys("Care Practitioner");
                Utils.WaitForElementAndClick(driver, "//button[text()='Find me a job']", "xpath", 30);
                List<IWebElement> list = driver.FindElements(By.XPath("//*[@class='MhrJobListResult-title']")).ToList();
                Assert.GreaterOrEqual(list.Count, 1);
            }
            catch { throw new Exception(); }

            finally { driver.Quit(); }

        }




        [When(@"User search for ""([^""]*)""")]
        public void WhenUserSearchFor(string p0)
        {

            Utils.WaitForElementAndClick(driver, "(//*[text()='CHC Backlog'])[3]", "xpath", 30);

        }
        [Then(@"User should be able to see search results")]
        public void ThenUserShouldBeAbleToSeeSearchResults()
        {
            List<IWebElement> list = driver.FindElements(By.XPath("//*[contains(@class, 'group sector')]")).ToList();
            Assert.GreaterOrEqual(list.Count, 1);

        }

        [Then(@"User should be able to sort according to date")]
        public void ThenUserShouldBeAbleToSortAccordingToDate()
        {
            try
            {
                var select = new SelectElement(driver.FindElement(By.XPath("//*[@name='sort']")));
                select.SelectByText("Oldest to newest");
                driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();
                List<IWebElement> list = driver.FindElements(By.XPath("//*[contains(@class, 'group sector')]")).ToList();
                //If You substitute "NewestToOldest" it checks whether it is sorted newest to oldest
                Assert.IsTrue(Utils.IsSortedListAccordingToDate(list, "OldestToNewest"));
            }
            catch { throw new Exception(); }
            finally { driver.Quit(); }
        }



        //Scenario 4
        [Given(@"User in helpdesk page")]
        public void GivenUserInHelpdeskPage()
        {
            driver.Navigate().GoToUrl("https://www.liaisongroup.com/liaison-workforce/helpdesk/");
        }

        [When(@"User clicks ""([^""]*)""")]
        public void WhenUserClicks(string queryText)
        {
        Utils.WaitForElementAndClick(driver, queryText, "textlocator", 30);
        }

        [Then(@"User SHould be able to direct to the registration page page ""([^""]*)""")]
        public void ThenUserSHouldBeAbleToDirectToTheRegistrationPagePage(string registrationPage)
        {
            // Switch to the new tab
            var newTabHandle = driver.WindowHandles.LastOrDefault();
            if (newTabHandle != null)
            {
                driver.SwitchTo().Window(newTabHandle);
                // Get the current URL of the new tab
                Assert.AreEqual(registrationPage, driver.Url);
            }
           
        }

        [Then(@"User Cliks new user button")]
        public void ThenUserCliksNewUserButton()
        {
         
            Utils.WaitForElementAndClick(driver, "//a[@href='/Account/Register']", "xpath", 30);
        }

        [When(@"User fills the registration form")]
        public void WhenUserFillsTheRegistrationForm(Table table)
        {
      
           var details = table.CreateInstance<RegisterModel>();
            Utils.RegistrationForm(details, driver);
        }

        [Then(@"user should be able to see success message ""([^""]*)""")]
        public void ThenUserShouldBeAbleToSeeSuccessMessage(string successMessage)
        {
            Utils.WaitForElementAndClick(driver, "//button[text()='Register']", "xpath", 30);
            Assert.IsTrue((driver.FindElement(By.XPath("//*[contains(text(),'Thank you.')]")).Text.Contains(successMessage)));
          
   
        }
    }

}

