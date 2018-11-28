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
        private IWebDriver broswer;

        public BlogAutomatyzacja()
        {
            broswer = new ChromeDriver();
        }

        [Fact]

        public void add_comment()
        {
            broswer.Navigate().GoToUrl("http://automatyzacja.benedykt.net");

            var linkKomenatarz = broswer.FindElement(By.CssSelector("span.comments-link"));
            linkKomenatarz.Click();

            var oknoKomentarz = broswer.FindElement(By.Name("comment"));
            oknoKomentarz.SendKeys("komentarz Mileny");

            var podpis = broswer.FindElement(By.Name("author"));
            podpis.SendKeys("Milena");

            var email = broswer.FindElement(By.Name("email"));
            email.SendKeys("email@email.com");

            var opublikujKomentarz = broswer.FindElement(By.Id("submit"));
            opublikujKomentarz.Click();

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
