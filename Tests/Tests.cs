using ECS_QA_Test.Helpers;
using ECS_QA_Test.Interfaces;
using ECS_QA_Test.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ECS_QA_Test.Tests
{
    [TestFixture]
    public class Tests
    {
        private readonly IIntroPage _introPage;
        private readonly IWebDriver _webDriver;
        private readonly IBrowserDriver _browserDriver;
        private readonly string _url;
        public Tests()
        {
            this._browserDriver = new BrowserDriver();
            this._webDriver = _browserDriver.GetChrometDriver();
            this._introPage = new IntroPage(_webDriver);
            this._url = _browserDriver.GetApplicationUrl();
        }
        [OneTimeSetUp]
        public void Setup()
        {
            Docker.StartDocker();
            _webDriver.Navigate().GoToUrl(_url); 
        }
              
        [Test]
        public void Test1_Arrays_Challenge_()
        {
            _introPage.ClickOnRenderChallenge();
            _introPage.EnterChallenge1();
            _introPage.EnterChallenge2();
            _introPage.EnterChallenge3();
            _introPage.EnterName("Test");
            _introPage.ClickOnSubmitBtn();
          

            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
             Docker.StopDocker();
            _webDriver.Quit();
        }
    }
}