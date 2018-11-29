using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WordpressPageObjectTests
{
    internal class AdminPage
    {
        private IWebDriver _browser;

        public AdminPage(IWebDriver browser)
        {
            _browser = browser;
        }

        internal void CreateNewNote(IWebDriver _browser)
        {
            var wpisy = _browser.FindElement(By.Id("menu-posts"));
            wpisy.Click();
            WaitForClickable(wpisy, 10);

            var dodajNowy = _browser.FindElement(By.CssSelector(".current > .current"));
            wpisy.Click();
        }

        internal void EditNote(Note exampleNote)
        {
            var titleInput = _browser.FindElement(By.Id("title-prompt-text"));
            titleInput.Click();
            titleInput.SendKeys(exampleNote.Title);

            var textButton = _browser.FindElement(By.Id("content-html"));
            textButton.Click();

            var contentArea = _browser.FindElement(By.Id("title-prompt-text"));
            contentArea.Click();
            contentArea.SendKeys(exampleNote.Content);

            var publishButton = _browser.FindElement(By.Id("publish"));
            publishButton.Click();
        }

        internal Uri PublishNote()
        {
            throw new NotImplementedException();
        }

        internal LoginPage Logout() // metoda wyloguj po wylogowaniu zwraca przechodzi na stronę logowania
        {
            throw new NotImplementedException();
        }

        private void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
    }
}