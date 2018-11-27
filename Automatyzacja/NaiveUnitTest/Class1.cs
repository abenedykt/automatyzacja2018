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
}
