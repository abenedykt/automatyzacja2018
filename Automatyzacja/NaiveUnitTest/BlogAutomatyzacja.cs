using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
            var chrome = new ChromeDriver();
            
            // simulating slow network
            //
            //chrome.NetworkConditions = new ChromeNetworkConditions
            //{
            //    DownloadThroughput = 50000,
            //    UploadThroughput = 50000,
            //    Latency = TimeSpan.FromMilliseconds(800)
            //};
            _browser = chrome;


            //
            // implicit timeouts
            //
            //_browser.Manage()
            //    .Timeouts()
            //    .ImplicitWait = TimeSpan.FromSeconds(5);
            
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

        [Fact]
        public void Can_login_and_logout()
        {
            _browser.Navigate().GoToUrl(Configuration.BlogAdminUrl);

            _browser.FindElement(By.Id("user_login")).SendKeys("automatyzacja");
            _browser.FindElement(By.Id("user_pass")).SendKeys("jesien2018");
            _browser.FindElement(By.Id("wp-submit")).Click();
<<<<<<< HEAD
            
=======


>>>>>>> 6083b08fe3be993b72405a63c045af2f02e6f4bb
            // todo am I logged in?

            IWebElement element = _browser.FindElement(By.Id("wp-admin-bar-my-account"));
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();

            var logoutButton = By.Id("wp-admin-bar-logout");
            WaitForClickable(logoutButton, 10);
            _browser.FindElement(logoutButton).Click();

            // todo am I logged out? 
<<<<<<< HEAD
            
=======


>>>>>>> 6083b08fe3be993b72405a63c045af2f02e6f4bb
        }

        private string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"{user}@nonexistent.test.com";
        }

        private void MoveToElement(By selector)
        {
            var element = _browser.FindElement(selector);
            MoveToElement(element);
        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
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
