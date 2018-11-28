using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automatyzacja_2
{
    public class PublicationOfACommentOnTheWebsiteTest : IDisposable
    {

        private IWebDriver browser;
        public PublicationOfACommentOnTheWebsiteTest()
        {
            browser = new ChromeDriver();
        }
        public void Dispose()
        {
            browser.Quit();
        }
        [Fact]
        public void Cwiczenie2()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net");

            var Comments = browser.FindElement(By.CssSelector(".comments-link>a"));
            Comments.Click();


            var AddComment = browser.FindElement(By.Name("comment"));
            var exampleComment = GenerateComment();
            AddComment.SendKeys(exampleComment);

            var AddEmail = browser.FindElement(By.Name("email"));
            AddEmail.SendKeys(GenerateEmail());

            var Signature = browser.FindElement(By.Name("author"));
            Signature.SendKeys("Mario");

            var PostAComment = browser.FindElement(By.Name("submit"));
            PostAComment.Submit();

            var comments = browser.FindElements(By.CssSelector(".comment-content"));
            Assert.NotNull(comments.Single(x => x.Text == exampleComment));
        }
        private string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"mariola.{user}@nonexistent.test.com";

        }
        private string GenerateComment()
        {
            var AddComment = Guid.NewGuid().ToString();
            return $"Dodaję komentarz.{AddComment}Dodaję komentarz";

        }

    }
}
