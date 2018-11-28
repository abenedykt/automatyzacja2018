using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

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

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Fact]
        public void Test1()
        {
            string comment = RandomString(10);
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

            // zapisanie pętli foreach za pomocą Linq
            var result = searchResultsComments.Where(x => x.FindElement(By.CssSelector("p")).Text == comment);
            Assert.Single(result);

            //IWebElement expected = null;

            //foreach (var result in searchResultsComments)
            //{
            //    if (result.FindElement(By.CssSelector("p")).Text == comment)
            //    {
            //        expected = result;
            //        break;
            //    }
            //}
            //Assert.NotNull(expected);
        }

        [Fact]
        public void Test2()
        {
            string login = "automatyzacja";
            string password = "jesien2018";
            string kokpitName = "Kokpit";
            string logOutName = "Wylogowano się.";

            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");

            var inputLogin = browser.FindElement(By.Id("user_login"));
            var inputPassword = browser.FindElement(By.Id("user_pass"));
            var submit = browser.FindElement(By.Id("wp-submit"));

            inputLogin.Click();
            inputLogin.SendKeys(login);
            inputPassword.Click();
            inputPassword.SendKeys(password);
            submit.Click();

            var kokpit = browser.FindElement(By.CssSelector(".wrap > h1")).Text;
            Assert.True(kokpit == kokpitName);

            var username = browser.FindElements(By.ClassName("display-name")).First();
            MoveToElement(username);

            var logOut = browser.FindElement(By.Id("wp-admin-bar-logout"));
            WaitForClickable(logOut, 1);
            logOut.Click();

            var logOutMessage = browser.FindElement(By.ClassName("message")).Text;
            Assert.True(logOutMessage == logOutName);
        }

        private void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
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
