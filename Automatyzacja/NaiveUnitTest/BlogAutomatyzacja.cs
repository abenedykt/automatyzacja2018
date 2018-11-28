using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using Xunit;

namespace NaiveUnitTest
{
    public class BlogAutomatyzacja : IDisposable
    {
        private readonly IWebDriver _browser;

        public BlogAutomatyzacja()
        {
            _browser= new ChromeDriver();
            _browser.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(5);
            
        }

        [Fact]
        public void Can_comment_a_post_on_blog()
        {
            _browser.Navigate().GoToUrl(Configuration.BlogUrl);

            _browser.FindElement(By.CssSelector(".comments-link")).Click();

            var exampleComment = "Lorem ipsum dolor sit ammet " + Guid.NewGuid().ToString();

            _browser.FindElement(By.Id("comment")).SendKeys(exampleComment);
            _browser.FindElement(By.Id("author")).SendKeys("Jan Testowy");
            _browser.FindElement(By.Id("email")).SendKeys(GenerateEmail());
            _browser.FindElement(By.Id("submit")).Submit();

            var comments = _browser.FindElements(By.CssSelector(".comment-content > p"));

            Assert.Single(comments.Where(comment => comment.Text == exampleComment));
        }

        private string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"{user}@nonexistent.test.com";
        }

        private void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        private void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public void Dispose()
        {
            try
            {
                if (_browser != null)
                {
                    _browser.Quit();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
