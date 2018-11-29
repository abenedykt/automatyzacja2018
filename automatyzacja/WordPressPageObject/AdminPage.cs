using OpenQA.Selenium;
using System;

namespace WordPressPageObject
{
    public class AdminPage
    {
        private IWebDriver _browser;

        public AdminPage(IWebDriver browser)
        {
            _browser = browser;
        }

        public void CreateNewNote()
        {
            _browser.Navigate();
        }

        public void EditNote(Note exampleNote)
        {
            throw new NotImplementedException();
        }

        //poczytac o klasie Uri
        public Uri PublishNote()
        {
            throw new NotImplementedException();
        }

        public LoginPage LogOut()
        {
            throw new NotImplementedException();
        }
    }
}