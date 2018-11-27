using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GoogleTestes
{
    public class GoogleSearchTests : IDisposable
    {
        private IWebDriver browser;

        public GoogleSearchTests()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void Can_google_out_cod_sprinters()
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

        public void Dispose()
        {
            browser.Quit();
        }
    }
}
