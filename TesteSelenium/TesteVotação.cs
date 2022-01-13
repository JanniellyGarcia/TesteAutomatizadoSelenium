//
//
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver("C:\\Users\\Janni\\Downloads\\chromedriver_win32");
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTestCaseTest()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://localhost:44303/");
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Vote aqui")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("userInput")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("userInput")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("userInput")).SendKeys("Jannielly Garcia");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("BackEnd")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("sendButton")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Votação'])[1]/following::div[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("userInput")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("userInput")).SendKeys("Willyam Oliveira");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("FullStack")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("sendButton")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//body")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("userInput")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("userInput")).SendKeys("Bruno");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("FrontEnd")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("sendButton")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Home")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
