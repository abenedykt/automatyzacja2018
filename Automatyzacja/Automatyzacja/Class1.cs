using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Automatyzacja
{
    public class WordPressSite : IDisposable
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
            Thread.Sleep(1000);

            var comments = browser.FindElement(By.CssSelector("#comments"));



            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            numbers.Where(x => x % 2 == 0);


            {
                browser.Quit();
                
                }
        }


        public void Dispose()
        {
            if (browser == null)
            {
                ;
            }
        }
 

    }
}

   
