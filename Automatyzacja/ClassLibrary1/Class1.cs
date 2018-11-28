using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace rafal
{
   
        public class GoogleSearchTests : IDisposable
        {
            private IWebDriver browser;

            public GoogleSearchTests()
            {
                browser = new ChromeDriver();
            }

            [Fact]
            public void Ca()
            {
                //throw new Exception();

                browser.Navigate().GoToUrl("http://google.com");

                var queryBox = browser.FindElement(By.Name(""));
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

            Xunit.Assert.NotNull(expected);
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

