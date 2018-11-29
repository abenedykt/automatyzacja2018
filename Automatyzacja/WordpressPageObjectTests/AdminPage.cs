using System;
using System.Linq;
using OpenQA.Selenium;

namespace WordpressPageObjectTests
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

            var MenuItems = _browser.FindElements(By.ClassName("wp-menu-name"));
            MenuItems.First(Item=>Item.Text=="Wpisy").Click();

            _browser.FindElement(By.LinkText("Dodaj nowy")).Click();
        }

        internal void EditNote(Note exampleNote)
        {
            var AddTitle = _browser.FindElement(By.)
        }

        internal Uri PublishNote()
        {
            throw new NotImplementedException();
        }

        internal LoginPage Logout()
        {
            throw new NotImplementedException();
        }
    }
}