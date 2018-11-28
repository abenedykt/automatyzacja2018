using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace FirstTestMariusz
{
    public class RafalSearchTest :IDisposable
    {
        private IWebDriver browser;
        public RafalSearchTest()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void SearchTransformationAndAssert()
        {
            browser.Navigate().GoToUrl("https://markowicz.pro");

            var row = browser.FindElement(By.XPath("//a[text()='O transformacjach']"));
            Assert.True(row.Text == "O transformacjach");
            row.Click();

            var user = browser.FindElements(By.CssSelector("span > a"));

            IWebElement expected = null;
            foreach (var result in user)
            {
                if (result.GetAttribute("href") == "https://markowicz.pro/author/rafal-markowicz/")
                {
                    expected = result;
                    break;
                }
            }
            Assert.NotNull(expected);
        }
       
        [Fact]
        public void CommentTest()
        {
            var commnetText = $"{Guid.NewGuid().ToString()}@komentarz";
            var authorText = $"{Guid.NewGuid().ToString()}@mariusz"; ;
            var emailText = $"{Guid.NewGuid().ToString()}@mariusz.text.com";

            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net");

            var comments = browser.FindElement(By.XPath("//*[@class='comments-link']/a"));
            comments.Click();

            var comment = browser.FindElement(By.Id("comment"));
            comment.SendKeys(commnetText);

            var author = browser.FindElement(By.Id("author"));
            author.SendKeys(authorText);

            var email = browser.FindElement(By.Id("email"));
            email.SendKeys(emailText);

            var submit = browser.FindElement(By.Id("submit"));
            submit.Click();

            var assertComment = browser.FindElements(By.XPath("//*[@class='comment-content']/p"));
            var result = assertComment.Where(x => x.Text == commnetText);
            Assert.Single(result);
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
