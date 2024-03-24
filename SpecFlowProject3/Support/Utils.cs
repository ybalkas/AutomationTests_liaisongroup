using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using static System.Net.Mime.MediaTypeNames;
using SpecFlowProject3.Models;
using System.Xml.Linq;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System.Globalization;

namespace SpecFlowProject3.Support
{
    internal class Utils
    {

        /// Waits for an element to be clickable by its XPath and then clicks it.
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="xpath">The text of an element.</param>

        public static void ClickElementByText(IWebDriver driver, string text)
        {
            // Find elements by XPath that contains the text
            driver.FindElement(By.XPath($"//*[text()='{text}']")).Click();
        }

        static Func<string, By> ReturnXPathIfTextGiven = (text) => By.XPath($"//*[text()='{text}']");

        /// Waits for an element to be clickable by its XPath and then clicks it.
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="xpath">The XPath of the element to wait for and click.</param>
        /// <param name="timeoutInSeconds">The maximum time to wait in seconds.</param>
        public static void WaitForElementAndClick(IWebDriver driver, string text, string locatorType, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            switch (locatorType.ToLower())
            {
                case "textlocator":
                    wait.Until(ExpectedConditions.ElementToBeClickable(ReturnXPathIfTextGiven(text))).Click();
                    break;
                case "idlocator":
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(text))).Click();
                    break;
                case "xpath":
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(text))).Click();
                    break;
                case "linktext":
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(text))).Click();
                    break;
                default:
                    throw new ArgumentException("Invalid locator type");
            }
           
        }
        public static void WaitForElementAndClick(IWebDriver driver, By element, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
        }
        public static void WaitForElementAndClick(IWebDriver driver, string text, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(ReturnXPathIfTextGiven(text))).Click();
        }

        public static void FillTheForm(SelectEventModel selectEvent, IWebDriver driver)
            {
                driver.FindElement(By.Id("field_event_full_name")).SendKeys(selectEvent.FullName);
                driver.FindElement(By.Id("field_event_email")).SendKeys(selectEvent.Email);
                driver.FindElement(By.Id("field_event_organisation")).SendKeys(selectEvent.Organisation);
                driver.FindElement(By.Id("field_message_event")).SendKeys(selectEvent.Message);
            }
       
        /// <summary>
        /// Selects an option from a dropdown by visible text.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="locatorText">locator text as XPath.</param>
        /// <param name="visibleText">The visible text of the option to be selected.</param>
        public static void SelectFromDropdownByGivenLocator(IWebDriver driver, string locatorText, string visibleText)
        {
            var select = new SelectElement(driver.FindElement(By.XPath(locatorText)));
            select.SelectByText(visibleText);
        }
        public static IWebElement FindElementById(IWebDriver driver, string Id)
        {
            return driver.FindElement(By.Id(Id));
          
        }
        public static void ClickByHoverOverAndActions(IWebDriver driver,string xpathLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpathLocator)));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            driver.FindElement(By.XPath(xpathLocator)).Click();
        }
        /// Checks whether given list sorted or not
        /// <param name="webelements">The WebElements List</param>
        /// <param name="sortType">Sort type either OldestToNewest or NewetstoOldest</param>
        public static bool IsSortedListAccordingToDate(List<IWebElement> webelements,string sortType)
        {
            List<string> datesList = new List<string>();
            foreach (var item in webelements)
            {
                datesList.Add(item.FindElement(By.CssSelector("span")).Text);
            }
            string format = "dd/MM/yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;
            List<DateTime> dateTimes = new List<DateTime>();
            foreach (string dateString in datesList)
            {
                DateTime parsedDate = DateTime.ParseExact(dateString, format, provider);
                dateTimes.Add(parsedDate);
            }
            bool IsAscending = true;
            bool IsDescending = true;
            for (int i = 0; i < dateTimes.Count - 1; i++)
            {
                if (dateTimes[i] > dateTimes[i + 1])
                {
                    IsAscending = false;
                }
                if (dateTimes[i] < dateTimes[i + 1])
                {
                    IsDescending = false;
                }
            }
            if (sortType.Equals("NewestToOldest")) return IsDescending;
            if (sortType.Equals("OldestToNewest")) return IsAscending;
            else { return false; }
        }
    }
}
       

