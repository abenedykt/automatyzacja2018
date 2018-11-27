using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstUnitTest
{
    public class MarkowiczTest : IDisposable
    {
        private IWebDriver browser;

        public MarkowiczTest()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void Test1()
        {
            browser.Navigate().GoToUrl("http://markowicz.pro");

            var searchResults = browser.FindElements(By.CssSelector(".entry-title > a"));

            foreach (var result in searchResults)
            {
                var href = result.GetAttribute("href");
                if (href == "http://markowicz.pro/o-transformacjach/")
                {
                    result.Click();
                    break;
                }
            }

            var searchText = browser.FindElements(By.CssSelector("span > a"));

            IWebElement expected = null;

            foreach (var search in searchText)
            {
                if (search.GetAttribute("href") == "http://markowicz.pro/author/rafal-markowicz/")
                {
                    expected = search;
                    break;
                }
            }
            Assert.NotNull(expected);
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
