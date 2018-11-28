using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace Automatyzacja
{
    public class LoginandLogoutWordpress
    {

        private IWebDriver browser;

        private void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        private void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        private void MoveToElement(By selector)
        {
            var element = browser.FindElement(selector);
            MoveToElement(element);
        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }

        public LoginandLogoutWordpress()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void Can_Login_and_Logout_Wordpress()
        {
            //throw new Exception();

            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");

            var name = browser.FindElement(By.CssSelector("#user_login"));
            name.Click();
            name.SendKeys("automatyzacja");

            var password = browser.FindElement(By.CssSelector("#user_pass"));
            password.Click();
            password.SendKeys("jesien2018");

            var button = browser.FindElement(By.CssSelector("#wp-submit"));
            button.Click();

            {
                browser.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(10);
            }


            var nazwaUzytkownika = browser.FindElement(By.ClassName("display-name"));
            Assert.Equal("Jan Automatyczny", nazwaUzytkownika.Text);
            
            MoveToElement(By.CssSelector("#wp-admin-bar-my-account > a"));

            {
                browser.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(10);
            }


            var logout = browser.FindElement(By.CssSelector("#wp-admin-bar-logout"));
            logout.Click();

            var wylogowano = browser.FindElement(By.CssSelector("#login > p.message"));
            Assert.Equal("Wylogowano się.", wylogowano.Text);

            {
                browser.Quit();

            }



        }

        }
    }

