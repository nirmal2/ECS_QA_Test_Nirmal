using ECS_QA_Test.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace ECS_QA_Test.Helpers
{



    public class BrowserInteraction : IBrowserInteraction
    {

        private readonly IWebDriver _webDriver;
        private WebDriverWait _webDriverWait;
        public BrowserInteraction(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
            _webDriverWait = new WebDriverWait(_webDriver, timeout: TimeSpan.FromSeconds(20));
        }

        /// <summary>
        /// Waits for the element to exist and returns it using the specified element localisation
        /// </summary>
        /// <param name="elementLocator"></param>
        /// <returns></returns>
        public IWebElement WaitAndReturnElement(By elementLocator, int waitTimeSpan)
        {
            _webDriverWait.Timeout = new TimeSpan(waitTimeSpan);
            return _webDriverWait.Until(_ => _webDriver.FindElement(elementLocator));
        }

        /// <summary>
        /// Waits for the element(s) to exist and returns them using the specified element localisation
        /// </summary>
        /// <param name="elementLocator"></param>
        /// <returns></returns>
        public IEnumerable<IWebElement> WaitAndReturnElements(By elementLocator, int waitTimeSpan)
        {
            _webDriverWait.Timeout = new TimeSpan(waitTimeSpan);
            return _webDriverWait.Until(_ => _webDriver.FindElements(elementLocator));
        }
        public IWebElement WaitAndReturnElement(By elementLocator)
        {
            _webDriverWait.Timeout = new TimeSpan(10);
            return _webDriverWait.Until(_ => _webDriver.FindElement(elementLocator));
        }
        public void GoToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Waits for the element(s) to exist and returns them using the specified element localisation
        /// </summary>
        /// <param name="elementLocator"></param>
        /// <returns></returns>
        public IEnumerable<IWebElement> WaitAndReturnElements(By elementLocator)
        {
            _webDriverWait.Timeout = new TimeSpan(10);
            return _webDriverWait.Until(_ => _webDriver.FindElements(elementLocator));
        }
        public static IWebElement WaitUntilElementPresent(IWebDriver driver, By locator)
        {

            try
            {

                WebDriverWait _wait = new WebDriverWait(driver, new TimeSpan(20));
                _wait.Timeout = new TimeSpan(20);
                _wait.Until<IWebElement>(d => d.FindElement(locator));

                IWebElement e = driver.FindElement(locator);
                return e;
            }
            catch (StaleElementReferenceException ex)
            {
                IWebElement e = driver.FindElement(locator);
                return e;
            }

        }

    }
}
