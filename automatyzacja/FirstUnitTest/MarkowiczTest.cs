using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FinallUnitTest
{
    public class MarkowiczTest : IDisposable
    {
        private ChromeDriver browser;
        private ITestOutputHelper output;

        public MarkowiczTest(ITestOutputHelper output)
        {
            browser = new ChromeDriver();
            this.output = output;
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

        private void MoveToElement(By selector)
        {
            var element = browser.FindElement(selector);
            MoveToElement(element);
        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }

        private void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
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

        [Fact]
        public void LogInLogOutWordpress()
        {
            string login = "automatyzacja";
            string password = "jesien2018";
            string message = "Wylogowano się";

            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin/");

            var loginTextBox = browser.FindElementById("user_login");
            var passwordTextBox = browser.FindElementById("user_pass");
            var logInButton = browser.FindElementById("wp-submit");

            loginTextBox.Click();
            loginTextBox.SendKeys(login);
            passwordTextBox.Click();
            passwordTextBox.SendKeys(password);
            logInButton.Click();

            var kokpit = browser.FindElementByCssSelector(".wrap > h1").Text;
            Assert.True(kokpit.ToLower() == "kokpit");

            var userName = browser.FindElementsByClassName("display-name").First();
            MoveToElement(userName);

            var logOutlink = browser.FindElementById("wp-admin-bar-logout");
            WaitForClickable(logOutlink, 1);
            logOutlink.Click();

            var logOutMessage = browser.FindElementByCssSelector(".message");
            Assert.Contains(message.ToLower(), logOutMessage.Text.ToLower());

            output.WriteLine("Test powiódł się.");
        }

    }
}
