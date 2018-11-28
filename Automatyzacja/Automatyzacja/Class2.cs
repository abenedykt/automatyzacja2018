using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NaiveUnitTest
{
  
    public class Wordpress : IDisposable
    {
        private IWebDriver browser;

        public Wordpress()
        {
            browser = new ChromeDriver();

        }

       
        public void Dispose()
        {
            browser.Quit();
        }

        [Fact]
        public void Logowanie()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");

            var loginlocator = By.Name("log");

            var login = browser.FindElement(loginlocator);
            login.SendKeys("automatyzacja");
            var password= browser.FindElement(By.Name("pwd"));
            password.SendKeys("jesien2018");
            var button = browser.FindElement(By.Name("wp-submit"));
            button.Click();

            var nazwaUzytkownika = browser.FindElement(By.ClassName("display-name"));
            Assert.Equal("Jan Automatyczny", nazwaUzytkownika.Text);

            MoveToElement(nazwaUzytkownika);

            var logoutlink = browser.FindElement(By.Id("wp-admin-bar-logout"));
            WaitForClickable(logoutlink, 5);
            logoutlink.Click();

            Assert.Single(browser.FindElements(loginlocator));
            
        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }

        private void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        private void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
