using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstUnitTest
{
    public class BlogTest : IDisposable
    {
        private IWebDriver browser;

        public BlogTest()
        {
            browser = new ChromeDriver();
        }

        private string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"{user}@nonexistent.test.com";
        }

        [Fact]
        public void Test1()
        {
            string comment = "Komentarz";
            string author = "Ewelina Witek";
            string email = GenerateEmail();
            string url = "abc.pl";

            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/");

            var commentLink = browser.FindElement(By.ClassName("comments-link"));
            commentLink.Click();

            var textareaComment = browser.FindElement(By.Id("comment"));
            var inputAuthor = browser.FindElement(By.Id("author"));
            var inputEmail = browser.FindElement(By.Id("email"));
            var inputUrl = browser.FindElement(By.Id("url"));
            var submit = browser.FindElement(By.Id("submit"));

            textareaComment.SendKeys(comment);
            inputAuthor.SendKeys(author);
            inputEmail.SendKeys(email);
            inputUrl.SendKeys(url);
            submit.Click();

            var searchResultsComments = browser.FindElements(By.ClassName("comment-content"));

            IWebElement expected = null;

            foreach (var result in searchResultsComments)
            {
                if (result.FindElement(By.CssSelector("p")).Text == comment)
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
