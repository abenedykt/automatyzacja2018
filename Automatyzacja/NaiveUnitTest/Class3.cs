using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewTestAddCommnet
{
    public class NewComment: IDisposable
    {
        private IWebDriver browser;

        public NewComment()
        {
            browser = new ChromeDriver();
        } 

        private string GenerateEmail() //generator unikatowego adresu email
        {
            var user = Guid.NewGuid().ToString();
            return $"{user}@nonexistent.test.com";
        }


        [Fact]
        public void Comment()
        {
            var TextKomentarza = Guid.NewGuid().ToString(); //generator unikatowego tekstu komentarza

            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net");

            var comment = browser.FindElement(By.CssSelector("span.comments-link"));
            comment.Click();

            var queryBox = browser.FindElement(By.Name("comment"));
            queryBox.SendKeys(TextKomentarza);

            var name = browser.FindElement(By.Name("author"));
            name.SendKeys("Justyna");

            var email = browser.FindElement(By.Name("email"));
            email.SendKeys(GenerateEmail());

            var dodaj = browser.FindElement(By.Name("submit"));
            dodaj.Click();

            var komentarze = browser.FindElements(By.XPath("//*[@class='comment-content'] /p"));
            IWebElement expected = null;
            foreach (var result in komentarze)
            {
                if (result.Text == TextKomentarza)
                {
                    expected = result;
                    break;
                }

            }
            Assert.NotNull(expected);



        }

        public void Dispose()
        {
           if (browser != null)
            {
                browser.Quit();
            }
        }

    }
}
