using System;
using OpenQA.Selenium;

namespace WordpressPageObjectTests

{
    internal class LoginPage
    {
        private IWebDriver _browser;

        public LoginPage(IWebDriver browser)
        {
            _browser = browser;
        }

        internal AdminPage Login(string user, string password)
        {
            throw new NotImplementedException();
        }

        internal bool IsLoggedOut()
        {
            throw new NotImplementedException();
        }


    }
}
