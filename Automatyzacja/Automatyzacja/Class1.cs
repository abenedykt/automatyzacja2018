using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Automatyzacja
{
    public class WordPressSite 
    {
        private IWebDriver browser;

        private string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"{user}@nonexistent.test.com";
        }

        public WordPressSite()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void Can_WordPress_Go()
        {
            //throw new Exception();

            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net");

            var Comment = browser.FindElement(By.CssSelector("#post-1 > footer > span.comments-link > a"));
            Comment.Click();
           

            var Coments = browser.FindElement(By.Id("comment"));
            Coments.Click();
            Coments.SendKeys("Dobry Komentarz Automatyczny");
            Thread.Sleep(1000);

            var Name = browser.FindElement(By.CssSelector("#author"));
            Name.Click();
            Name.SendKeys("Krzysztof Baran");
            Thread.Sleep(1000);

            var user = browser.FindElement(By.CssSelector("#email"));
            user.Click();
            user.SendKeys(GenerateEmail());
            Thread.Sleep(1000);

            var Opublikuj = browser.FindElement(By.CssSelector("#submit"));
            Opublikuj.Click();
            Opublikuj.Submit();
            Thread.Sleep(1000);

            browser.Quit();

        }
    }
}

   
