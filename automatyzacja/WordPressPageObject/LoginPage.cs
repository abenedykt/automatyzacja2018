﻿using System;
using OpenQA.Selenium;

namespace WordPressPageObject
{
    public class LoginPage
    {
        private IWebDriver _browser;
        // Kontrolki
        private IWebElement logInTextBox;
        private IWebElement passwordTextBox;
        private IWebElement logInButton;

        public LoginPage(IWebDriver browser)
        {
            _browser = browser;
        }

        public AdminPage Login(string user, string password)
        {
            _browser.Navigate().GoToUrl(Config.Url);

            logInTextBox = _browser.FindElement(By.Id("user_login"));
            passwordTextBox = _browser.FindElement(By.Id("user_pass"));
            logInButton = _browser.FindElement(By.Id("wp-submit"));

            logInTextBox.Click();
            logInTextBox.SendKeys(user);
            passwordTextBox.Click();
            passwordTextBox.SendKeys(password);
            logInButton.Click();

            
            return new AdminPage(_browser);
        }

        public bool IsLoggedOut()
        {
            throw new NotImplementedException();
        }
    }
}