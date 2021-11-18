using ECS_QA_Test.Helpers;
using ECS_QA_Test.Interfaces;
using ECS_QA_Test.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ECS_QA_Test
{
    [TestFixture]
    public class Tests
    {
        private readonly IIntroPage _introPage;
        private readonly IWebDriver _webDriver;
        private readonly IBrowserDriver _browserDriver;
        private readonly string _url;
        //private readonly IContainer _Container;
        public Tests()
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterType<BrowserDriver>().As<IBrowserDriver>();
            //builder.RegisterType<IntroPage>().As<IIntroPage>();
            //_Container = builder.Build();

            //this._browserDriver = _Container.Resolve<IBrowserDriver>();
            //this._introPage = _Container.Resolve<IIntroPage>();


            this._browserDriver = new BrowserDriver();
            this._webDriver = _browserDriver.GetChrometDriver();
            this._browserDriver = new BrowserDriver();
            this._introPage = new IntroPage(_webDriver);
            
            this._url = _browserDriver.GetApplicationUrl();
            
        }
        [OneTimeSetUp]
        public void Setup()
        {
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
            _webDriver.Quit();
        }
    }
}