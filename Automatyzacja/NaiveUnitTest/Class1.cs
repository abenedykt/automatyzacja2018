using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace WebTests
{
    public class TestTools
    {
        //Generate random email
        public string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"pz_{user}@noneexistent.test.com";
        }

        //Wait for element 1
        public void WaitForClickable(By by, int seconds, IWebDriver _browser)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
        //Wait for element 2
        public void WaitForClickable(IWebElement element, int seconds, IWebDriver _browser)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        //Set mouse coursor over element 1
        public void MoveToElement(By selector, IWebDriver _browser)
        {
            var element = _browser.FindElement(selector);
            MoveToElement(element, _browser);
        }
        //Set mouse coursor over element 2
        public void MoveToElement(IWebElement element, IWebDriver _browser)
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }
    }

    public class GoogleSearchTest : IDisposable
    {
        //zmienna/pole w klasie
        private IWebDriver browser;

        //konstruktor
        public GoogleSearchTest()
        {
            browser = new ChromeDriver();
        }

        //funkcja zwalniająca obiekt (jeśli jest interfejs IDisposable musi być funkcja Dispose())
        public void Dispose()
        {
            browser.Quit();
        }

        [Fact]
        public void SearchCodeSprinters()
        {
            browser.Navigate().GoToUrl("http://google.com");

            var queryBox = browser.FindElement(By.Name("q"));
            queryBox.SendKeys("code sprinters");
            queryBox.Submit();

            var searchResult = browser.FindElements(By.CssSelector("div.rc"));

            IWebElement expected = null;

            foreach (var result in searchResult)
            {
                var link = result.FindElement(By.CssSelector(".r>a"));
                if (link.GetAttribute("href") == "http://agileszkolenia.pl/")
                {
                    expected = result;
                    break;
                }
            }

            Assert.NotNull(expected);
        }
    }

    public class MarkowiczProTest : IDisposable
    {
        //zmienna/pole w klasie
        private IWebDriver browser;

        //konstruktor
        public MarkowiczProTest()
        {
            browser = new ChromeDriver();
        }

        //funkcja zwalniająca obiekt (jeśli jest interfejs IDisposable musi być funkcja Dispose())
        public void Dispose()
        {
            browser.Quit();
        }

        [Fact]
        public void CheckNoteAndAuthor()
        {
            //Check if correct note is on main page
            browser.Navigate().GoToUrl("http://markowicz.pro");

            var notes = browser.FindElements(By.CssSelector("header.entry-header"));

            IWebElement expected = null;

            foreach (var result in notes)
            {
                var link = result.FindElement(By.CssSelector("h2.entry-title>a"));
                if (link.GetAttribute("href") == "http://markowicz.pro/o-transformacjach/")
                {
                    expected = result;

                    //Open note
                    link.Click();

                    //Check author
                    var author_link = browser.FindElement(By.CssSelector("span.author.vcard>a")).GetAttribute("href");
                    Assert.Equal("http://markowicz.pro/author/rafal-markowicz/", author_link);
                    break;
                }
            }

            //Check if note exists
            Assert.NotNull(expected);
        }
    }

    public class BlogComment : TestTools, IDisposable
    {
        //zmienna/pole w klasie
        private IWebDriver browser;

        //konstruktor
        public BlogComment()
        {
            browser = new ChromeDriver();
        }

        //funkcja zwalniająca obiekt (jeśli jest interfejs IDisposable musi być funkcja Dispose())
        public void Dispose()
        {
            browser.Quit();
        }

        [Fact]
        public void AddComment()
        {
            string comment_text = "To jest komentarz dodany przez Piotr Zajac " + DateTime.Now.ToString(); ;
            string sign_text = "Piotr Zajac";
            string email_text = GenerateEmail();

            //Open main page
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net");

            //Click comments link
            browser.FindElement(By.CssSelector("span.comments-link>a")).Click();

            //Fill comment box
            var comment_box = browser.FindElement(By.Id("comment"));
            comment_box.SendKeys(comment_text);

            //Fill sign box
            var sign_box = browser.FindElement(By.Id("author"));
            sign_box.SendKeys(sign_text);

            //Fill email box
            var email_box = browser.FindElement(By.Id("email"));
            email_box.SendKeys(email_text);

            //Confirm comment
            var publish_buttton = browser.FindElement(By.Id("submit"));
            publish_buttton.Click();

            //Check if comment was added
            var comments_list = browser.FindElement(By.CssSelector("ol.comment-list")).FindElements(By.CssSelector("li"));
            //bool expected_exists = false;

            comments_list.Single(x=> x.FindElement(By.ClassName("fn")).Text == sign_text && x.FindElement(By.CssSelector("div.comment-content>p")).Text == comment_text);

            /*
            foreach (var result in comments_list)
            {
                //Get elements
                var author_element = result.FindElement(By.ClassName("fn"));
                var comment_element = result.FindElement(By.CssSelector("div.comment-content>p"));

                if (author_element.Text == sign_text && comment_element.Text == comment_text)
                {
                    expected_exists = true;
                    break;
                }
            }

            //Check if comment was added
            Assert.True(expected_exists);
            */
        }
    }

    public class WPLogInOut : TestTools, IDisposable
    {
        //zmienna/pole w klasie
        private IWebDriver browser;

        //konstruktor
        public WPLogInOut()
        {
            browser = new ChromeDriver();
        }

        //funkcja zwalniająca obiekt (jeśli jest interfejs IDisposable musi być funkcja Dispose())
        public void Dispose()
        {
            browser.Quit();
        }

        [Fact]
        public void LogInLogOut()
        {
            string login = "automatyzacja";
            string pass = "jesien2018";
            string logout_message = "Wylogowano się.";

            //Set implicit timeouts - rather not use (the same timeout for every element)
            //browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Open login panel
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");

            //Enter login
            browser.FindElement(By.Id("user_login")).SendKeys(login + Keys.Escape);

            //Enter password
            browser.FindElement(By.Id("user_pass")).SendKeys(pass);

            //Click [Zaloguj sie] button
            var submit_button = browser.FindElement(By.Id("wp-submit"));
            WaitForClickable(submit_button, 2, browser);
            submit_button.Click();

            //Check if user was logged in
            var user_name_element = browser.FindElement(By.CssSelector("span.display-name"));
            WaitForClickable(user_name_element, 2, browser);
            Assert.Equal("Jan Automatyczny", user_name_element.Text);

            //Move mouse over user name
            MoveToElement(user_name_element, browser);

            //Click Wyloguj link
            var logout_link = browser.FindElement(By.Id("wp-admin-bar-logout"));
            WaitForClickable(logout_link, 2, browser);
            logout_link.Click();

            //Check if user was loged out
            Assert.Equal(logout_message, browser.FindElement(By.ClassName("message")).Text);
        }
    }

}
