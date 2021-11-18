using OpenQA.Selenium;

namespace ECS_QA_Test.Interfaces
{
    public interface IBrowserDriver
    {
        string GetApplicationUrl();
        IWebDriver GetChrometDriver();
    }
}