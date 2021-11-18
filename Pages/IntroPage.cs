using ECS_QA_Test.Helpers;
using ECS_QA_Test.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECS_QA_Test.Pages
{
    public class IntroPage : IIntroPage
    {
        private IBrowserInteraction _browserInteractions;
        IWebDriver _webDriver;

        public IntroPage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
            this._browserInteractions = new BrowserInteraction(_webDriver);

        }
        private IWebElement RenderChalengeBtn => _browserInteractions.WaitAndReturnElement(By.XPath("//button[contains(@data-test-id,'render-challenge')]"));
        private IEnumerable<IWebElement> FirstRow => _browserInteractions.WaitAndReturnElements(By.XPath("//td[contains(@data-test-id,'array-item-1')]"));
        private IEnumerable<IWebElement> SecondRow => _browserInteractions.WaitAndReturnElements(By.XPath("//td[contains(@data-test-id,'array-item-2')]"));
        private IEnumerable<IWebElement> ThirdRow => _browserInteractions.WaitAndReturnElements(By.XPath("//td[contains(@data-test-id,'array-item-3')]"));
        private IWebElement Challenge1TxtBox => _browserInteractions.WaitAndReturnElement(By.XPath("//input[@data-test-id='submit-1']"));
        private IWebElement Challenge2TxtBox => _browserInteractions.WaitAndReturnElement(By.XPath("//input[@data-test-id='submit-2']"));
        private IWebElement Challenge3TxtBox => _browserInteractions.WaitAndReturnElement(By.XPath("//input[@data-test-id='submit-3']"));
        private IWebElement NameTxtBox => _browserInteractions.WaitAndReturnElement(By.XPath("//input[@data-test-id='submit-4']"));
        private IWebElement Submitbtn => _browserInteractions.WaitAndReturnElement(By.XPath("//button[not(contains(@data-test-id,'render-challenge'))]"));



        public void ClickOnRenderChallenge()
        {
            RenderChalengeBtn.ClickWithRetry();
        }
        public void EnterChallenge1()
        {
            Challenge1TxtBox.SendKeysWithClear(GetIndexOfsumIntegersEqualToLeftAndtheRight(FirstRow).ToString());
        }
        public void EnterChallenge2()
        {
            Challenge2TxtBox.SendKeysWithClear(GetIndexOfsumIntegersEqualToLeftAndtheRight(SecondRow).ToString());
        }
        public void EnterChallenge3()
        {
            Challenge3TxtBox.SendKeysWithClear(GetIndexOfsumIntegersEqualToLeftAndtheRight(ThirdRow).ToString());
        }

        public void EnterName(string name)
        {
            NameTxtBox.SendKeysWithClear(name);
        }


        public void ClickOnSubmitBtn()
        {
            Submitbtn.ClickWithRetry();
        }

        private int[] GetArrayFromElements(IEnumerable<IWebElement> row)
        {
            int[] array = new int[row.Count()];
            int y = 0;
            foreach (var item in row)
            {
                array[y] = Int32.Parse(item.Text);
                y++;
            }
            return array;
        }
        private int GetIndexOfsumIntegersEqualToLeftAndtheRight(IEnumerable<IWebElement> row)
        {
            int[] array = GetArrayFromElements(row);

            int left = 0, right = 0;

            for (int i = 0; i < array.Length; i++, left = 0, right = 0)
            {
                for (int j = 0; j < i; j++)
                {
                    left += array[j];
                }
                for (int k = array.Length - 1; k > i; k--)
                {
                    right += array[k];
                }
                if (left == right) return i;
            }
            return -1;
        }
    }
}
