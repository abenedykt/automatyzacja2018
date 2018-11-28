using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

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
        private void WaitForClickable(By by, int seconds)
        {
            //var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        //Wait for element 2
        private void WaitForClickable(IWebElement element, int seconds)
        {
            //var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
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
            bool expected_exists = false;
            
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
        }
    }
}
