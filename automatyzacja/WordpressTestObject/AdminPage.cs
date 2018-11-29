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
            //throw new NotImplementedException();

            var menuItems = _browser.FindElements(By.ClassName("wp-menu-name"));
            menuItems.First(item => item.Text == "Wpisy").Click();

            var submenuItems = _browser.FindElements(By.CssSelector(".wp-submenu li a"));
            submenuItems.First(item => item.Text == "Dodaj nowy").Click();
            
        }

        internal void EditNote(Note exampleNote)
        {
            throw new NotImplementedException();
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