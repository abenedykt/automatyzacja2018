using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FinallUnitTest
{
    public class MarkowiczTest : IDisposable
    {
        private ChromeDriver browser;

        public MarkowiczTest()
        {
            browser = new ChromeDriver();
        }
        public void Dispose()
        {
            if (browser != null)
            {
                browser.Quit();
            }
        }

        private string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"{user}@noneexistent.test.com";
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Fact]
        public void MarkowiczTransformacjaTest()
        {
            browser.Navigate().GoToUrl("http://markowicz.pro");
            //var articleTitle = browser.FindElement(By.XPath("//*[@id='post-261']//*[@class='entry-title']"));
            //var articleTitle = browser.FindElement(By.Id("post-261"));

            var articles = browser.FindElementsByCssSelector(".entry-title > a");
            foreach (var article in articles)
            {
                var href = article.GetAttribute("href");
                if (href == "http://markowicz.pro/o-transformacjach/")
                {

                }
            }

            IWebElement expected = null;
            //var userName = browser.FindElementByClassName("author vcard");

            var results = browser.FindElementsByCssSelector("span > a");
            foreach (var result in results)
            {
                if (result.GetAttribute("href") == "http://markowicz.pro/author/rafal-markowicz/")
                {
                    expected = result;
                    break;
                }
            }



            Assert.NotNull(expected);
        }

        [Fact]
        public void AddCheckCommentBlogTest()
        {
            string comment = "Nice post! " + RandomString(5);
            string author = "Mateusz M.";
            string email = GenerateEmail();
            string url = "http://mati.automatyzuje.pl";

            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net");

            // przejscie do komentarza postu
            var commentLink = browser.FindElementByClassName("comments-link");
            commentLink.Click();

            //dodanie komentarza
            var commentTextBox = browser.FindElementById("comment");
            var authorTextBox = browser.FindElementById("author");
            var emailTextBox = browser.FindElementById("email");
            var urlTextBox = browser.FindElementById("url");
            var addCommentButton = browser.FindElementById("submit");

            commentTextBox.Click();
            commentTextBox.SendKeys(comment);

            authorTextBox.SendKeys(author);
            emailTextBox.SendKeys(email);
            urlTextBox.SendKeys(url);

            addCommentButton.Click();

            var addedCommentsToVerify = browser.FindElementsByClassName("comment-content");
            //bool expected = false;

            var com = addedCommentsToVerify.Where(c => c.FindElement(By.CssSelector("p")).Text == comment);
            Assert.Single(com);

            //foreach (var commentA in addedCommentsToVerify)
            //{
            //    if (commentA.FindElement(By.CssSelector("p")).Text == comment)
            //        expected = true;
            //        break;
            //}
            //Assert.True(expected);

        }
    }
}
