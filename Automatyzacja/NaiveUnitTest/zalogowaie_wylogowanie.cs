using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NaiveUnitTest
{
    public class zalogowaie_wylogowanie : IDisposable
    {
        private IWebDriver broswer;

        public zalogowaie_wylogowanie()
        {
            broswer = new ChromeDriver();
        }

        [Fact]
        public void logowanie()
        {
            broswer.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");

            var nazwaUzytkownika = broswer.FindElement(By.Name("log"));
            nazwaUzytkownika.SendKeys("automatyzacja");

            var haslo = broswer.FindElement(By.Name("pwd"));
            haslo.SendKeys("jesien2018");
            haslo.Submit();

            var nameSelector = By.CssSelector("span.display-name");
            var serchReslut = broswer.FindElement(nameSelector);

            Assert.Equal("Jan Automatyczny", serchReslut.Text);
                
            var menu = broswer.FindElement(nameSelector);
            MoveToElement(menu);
            WaitForClickable(By.Id("wp-admin-bar-logout"),5);
            Wyloguj_sie();

            nazwaUzytkownika = broswer.FindElement(By.Name("log"));

            Assert.NotNull(nazwaUzytkownika);


        }

        private void WaitForClickable(By by, int seconds)

        {

            var wait = new WebDriverWait(broswer, TimeSpan.FromSeconds(seconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));

        }



        private void WaitForClickable(IWebElement element, int seconds)

        {

            var wait = new WebDriverWait(broswer, TimeSpan.FromSeconds(seconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

        }

        private void MoveToElement(By selector)

        {

            var element = broswer.FindElement(selector);

            MoveToElement(element);

        }

        private void MoveToElement(IWebElement element)

        {

            Actions builder = new Actions(broswer);

            Actions moveTo = builder.MoveToElement(element);

            moveTo.Build().Perform();


        }



        private void Wyloguj_sie()
        {

            var wyloguj_sie = broswer.FindElement(By.Id("wp-admin-bar-logout"));
            wyloguj_sie.Click();

        }

        public void Dispose()
        {
            broswer.Dispose();
        }
    }
}
