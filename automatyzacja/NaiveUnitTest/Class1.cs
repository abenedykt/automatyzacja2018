using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleTests
{
    public class GoogleSearchTests: IDisposable
    {
        private IWebDriver browser;

        public GoogleSearchTests()
        {
            browser = new ChromeDriver(); 
        }

        [Fact]
        public void Can_google_out_code_sprinters()
        {
            //IWebDriver browser = new ChromeDriver();
            browser.Navigate().GoToUrl("http://google.com");
            var queryBox = browser.FindElement(By.Name("q"));

            //queryBox.SendKeys("code sprinters" + Environment.NewLine);
            queryBox.SendKeys("code sprinters");
            queryBox.Submit();
            var searchResults = browser.FindElements(By.CssSelector("div.rc"));

            IWebElement expected = null;

            foreach (var result in searchResults)
            {
                var link = result.FindElement(By.CssSelector(".r>a"));
                if (link.GetAttribute("href") == "http://agileszkolenia.pl/")
                {
                    expected = result;
                    //Console.WriteLine("Znalazlem");
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
