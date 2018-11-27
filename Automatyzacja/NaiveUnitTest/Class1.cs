using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace GoogleTest
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
}
