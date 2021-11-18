using OpenQA.Selenium;
using System.Collections.Generic;

namespace ECS_QA_Test.Interfaces
{
    public interface IBrowserInteraction
    {
        IWebElement WaitAndReturnElement(By elementLocator);
        IWebElement WaitAndReturnElement(By elementLocator, int waitTimeSpan);
        IEnumerable<IWebElement> WaitAndReturnElements(By elementLocator);
        IEnumerable<IWebElement> WaitAndReturnElements(By elementLocator, int waitTimeSpan);
        void GoToUrl(string url);
    }
}