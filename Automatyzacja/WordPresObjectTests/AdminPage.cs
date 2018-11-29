using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace WordPresObjectTests
{
    internal class AdminPage
    {
        private IWebDriver _browser;

        public AdminPage(IWebDriver browser)
        {
            _browser = browser;
        }
        internal void CreateNewNote()
        {
            var note = _browser.FindElement(By.XPath("//div[text()='Wpisy']"));
            note.Click();

            var addNew = _browser.FindElement(By.XPath("//*[@class='wrap']//a[text()='Dodaj nowy']"));
            addNew.Click();
        }

        internal void EditNote(Note exampleNote)
        {
            var addTitle = _browser.FindElement(By.Name("post_title"));
            addTitle.SendKeys(exampleNote.Title);

            var addContent = _browser.FindElement(By.XPath("//*[@id='wp-content-editor-container']//textarea"));

            addContent.SendKeys(exampleNote.Content);
        }

        internal Uri PublishNote()
        {
            var submit = _browser.FindElement(By.Name("publish"));
            submit.Click();

            var url = _browser.FindElement(By.XPath("//*[@id='sample-permalink']/a")).Text;

            return new Uri(url);
        }

        internal LoginPage Logout()
        {
            var element = _browser.FindElement(By.Id("wp-admin-bar-my-account"));
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();

            _browser.Manage()
               .Timeouts()
               .ImplicitWait = TimeSpan.FromSeconds(5);

            var logOut = _browser.FindElement(By.Id("wp-admin-bar-logout"));
            logOut.Click();

            return new LoginPage(_browser);
        }
    }
}