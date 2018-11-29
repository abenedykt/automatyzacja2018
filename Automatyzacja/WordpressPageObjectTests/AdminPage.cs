using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

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

            var dodajNowySearch = _browser.FindElements(By.CssSelector(".wp-submenu > li"));
            var dodajNowy = dodajNowySearch.Single(x => x.Text == "Dodaj nowy");
            dodajNowy.Click();
        }

        internal void EditNote(Note exampleNote)
        {
            var textButton = _browser.FindElement(By.Id("content-html"));
            textButton.Click();

            var titleInput = _browser.FindElement(By.Id("title"));
            var contentArea = _browser.FindElement(By.Id("content"));

            titleInput.Click();
            titleInput.SendKeys(exampleNote.Title);
            contentArea.Click();
            contentArea.SendKeys(exampleNote.Content);
        }

        internal Uri PublishNote()
        {
            WaitForClickable(By.Id("sample-permalink"), 10);
            var urlLink = _browser.FindElement(By.Id("sample-permalink")).Text;
            var publishButton = _browser.FindElement(By.Id("publish"));
            publishButton.Click();

            return new Uri(urlLink);
        }

        internal LoginPage Logout() // metoda wyloguj po wylogowaniu zwraca przechodzi na stronę logowania
        {
            throw new NotImplementedException();
        }

        private void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}