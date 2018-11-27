using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GoogleTests
{
    public class GoogleSearchTests : IDisposable
    {
        private IWebDriver browser;

        public GoogleSearchTests()
        {
            browser = new ChromeDriver();
        }
            
        [Fact]
        public void Can_google_out_code_sprinters()
        {
            throw new Exception();

            browser.Navigate().GoToUrl("http://google.com");

            var queryBox = browser.FindElement(By.Name("q"));
            queryBox.SendKeys("Code sprinters");
            queryBox.Submit();

            var searchResults = browser.FindElements(By.CssSelector("div.rc"));

            IWebElement expected = null;

            foreach (var result in searchResults)
            {
                var link = result.FindElement(By.CssSelector(".r>a"));
                if (link.GetAttribute("href") == "http://agileszkolenia.pl/")
                {
                    expected = result;
                    break;
                }
                
            }

            browser.Quit();

            Assert.NotNull(expected);
        }
        public void Dispose()
        {
            if (browser == null)
            {
                browser.Quit();
            }
        }
    }
}
