using System;
using OpenQA.Selenium;

namespace WordPressPageObject
{
    internal class LoginPage
    {
        private IWebDriver _browser;

        public LoginPage(IWebDriver browser)
        {
            _browser = browser;

            browser.Navigate().GoToUrl(Config.Url);

            var Login = _browser.FindElement(By.CssSelector("#user_login"));
            Login.Click();
            Login.SendKeys(Config.User);

            var LoginPassword = _browser.FindElement(By.CssSelector("#user_pass"));
            LoginPassword.Click();
            LoginPassword.SendKeys(Config.Password);

            var buttonSubmit = _browser.FindElement(By.CssSelector("#wp-submit"));
            buttonSubmit.Click();
        }

        internal AdminPage Login(string user, string password)
        {
            return new AdminPage(_browser);
        }

        //internal bool IsloggedOut()
        //{
            //try
           // {
               // _browser.FindElement(By.Id("loginform"));
              //  return true;
          //  }
          //  catch (NotFoundException)
          //  { 
           //     return false;
            }
        }
        
  //  }
//}