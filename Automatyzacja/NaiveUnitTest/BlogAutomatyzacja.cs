using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public void Dispose()

        {
            browser.Quit();
        }

        [Fact]
        public void Blog()
        {
            var autor = Guid.NewGuid().ToString();
            var commentText = "comment";
            var nameText = "Gabrysia";
            var emailText = "@wp.pl";
          
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net");

            browser.FindElement(By.CssSelector("span.comments-link")).Click();

            var PoleKomentarza = browser.FindElement(By.Id(commentText));
            //PoleKomentarza.Click();
            PoleKomentarza.SendKeys(nameText);

            var Podpis = browser.FindElement(By.Id("author"));
            //Podpis.Click();
            Podpis.SendKeys(autor);

            var AdresEmail = browser.FindElement(By.Id("email"));
            //AdresEmail.Click();
            AdresEmail.SendKeys(autor + emailText);

            browser.FindElement(By.Id("submit")).Click();

            var articles = browser.FindElements(By.CssSelector("div>p"));
            IWebElement title = null;

            //foreach (var article in articles)

            {
                //if (article.Text == nameText)
                {
                    //title = article;
                    //break;
                }
            }

            Assert.Single(articles.Where(x => x.Text == nameText));
            //Assert.NotNull(title);



        }



    }
}