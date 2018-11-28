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
            var autor = "Milena-" + Guid.NewGuid().ToString();

            broswer.Navigate().GoToUrl("http://automatyzacja.benedykt.net");

            var linkKomenatarz = broswer.FindElement(By.CssSelector("span.comments-link"));
            linkKomenatarz.Click();

            var oknoKomentarz = broswer.FindElement(By.Name("comment"));
            oknoKomentarz.SendKeys(Guid.NewGuid().ToString());

            var podpis = broswer.FindElement(By.Name("author"));
            podpis.SendKeys(autor);

            var email = broswer.FindElement(By.Name("email"));
            email.SendKeys(GenerateEmail());

            var opublikujKomentarz = broswer.FindElement(By.Id("submit"));
            opublikujKomentarz.Click();

            IWebElement MojKomentarz = null;



            var Komentarze = broswer.FindElements(By.ClassName("comment-body"));
            /*foreach (var Komentarz in Komentarze)
            {
                if (Komentarz.FindElement(By.CssSelector(".comment-author b")).Text == autor)
                {
                    MojKomentarz = Komentarz;
                    break;

                }
            }
            */

            Komentarze = broswer.FindElements(By.CssSelector(".comment-author b"));

            Assert.NotNull(Komentarze.Single(x => x.Text == autor));

        }

        private string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"{user}@email.com";

        }

        public void Dispose()
        {
            broswer.Quit();
        }
    }
}
