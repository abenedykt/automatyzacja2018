using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NaiveUnitTest
{
    public class BlogAutomatyzacja : IDisposable
    {
        private IWebDriver browser;

        public BlogAutomatyzacja()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void Wpisz_komentarz()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net");
            var komentarz = browser.FindElement(By.CssSelector("span.comments-link"));
            komentarz.Click();
            var wkoment = browser.FindElement(By.Name("comment"));
                
            wkoment.SendKeys("Moj komentarz, Ela");
            wkoment.Click();

            //wkoment.Submit();

            var authorkom = browser.FindElement(By.Name("author"));
            authorkom.SendKeys("ElaK");
            var mailkom = browser.FindElement(By.Name("email"));
            mailkom.SendKeys("elakuch@gmail.com");
            var opublkom = browser.FindElement(By.Name("submit"));
            opublkom.Click();





        }

        public void Dispose()
        {
            browser.Quit();
        }
    }
}
