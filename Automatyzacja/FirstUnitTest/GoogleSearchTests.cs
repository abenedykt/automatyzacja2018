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
    public class GoogleSearchTests : IDisposable
    {
        private IWebDriver browser; //pole prywatne na poziomie każdej klasy

        public GoogleSearchTests()
        {
            browser = new ChromeDriver();
        }

        public void Dispose()
        {
            if (browser != null)
            {
                browser.Quit();
            }
        }

        [Fact]
        public void ExampleTest()
        {
            browser.Navigate().GoToUrl("http://google.com");

            var queryBox = browser.FindElement(By.Name("q"));
            queryBox.SendKeys("code sprinters");
            queryBox.Submit();

            var searchResults = browser.FindElements(By.CssSelector("div.rc"));

            IWebElement expected = null;

            foreach (var result in searchResults)
            {
                var link = result.FindElement(By.CssSelector(".r > a"));
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
