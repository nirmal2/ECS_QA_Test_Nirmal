using ECS_QA_Test.Configuration;
using ECS_QA_Test.Interfaces;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ECS_QA_Test.Helpers
{
    public class BrowserDriver : IBrowserDriver
    {
        public static ConfigSetting config;
        public static ConfigurationBuilder _builder;
        public IWebDriver _webDriver;


        public static string configPath;
        static BrowserDriver()
        {
            configPath = Directory.GetParent(@"../../../").FullName
           + Path.DirectorySeparatorChar
           + "Configuration/Config.json";
            new DriverManager().SetUpDriver(new ChromeConfig());
            config = new ConfigSetting();
            _builder = new ConfigurationBuilder();
            _builder.AddJsonFile(configPath);
            IConfigurationRoot configuration = _builder.Build();
            configuration.Bind(config);
        }
        public IWebDriver GetChrometDriver()
        {
            return _webDriver = new ChromeDriver();
        }
        public string GetApplicationUrl()
        {
            return config.ApplicationURL;
        }


    }
}
