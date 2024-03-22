
/*
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject3.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            string path = @"c:\websites\test\selenium\chrome\";
            //opt.BinaryLocation = path + "chrome.exe";
            //driver = new ChromeDriver(path, opt);
            //IWebDriver driver = new ChromeDriver("chromedriver.exe");
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.co.uk/");
            driver.Close();
            Assert.AreEqual(number, 1);
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic

            throw new PendingStepException();
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            throw new PendingStepException();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            throw new PendingStepException();
        }
    }
}
*/