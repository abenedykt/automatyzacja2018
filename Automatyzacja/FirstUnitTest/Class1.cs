using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FirstUnitTest
{
    public class GoogleSearchTest : IDisposable 
    {
        private IWebDriver browser;

        public GoogleSearchTest()
        {
         browser = new ChromeDriver();
        }

        [Fact]
        public void Can_Google_out_code_Sprinters()
        {
            //throw new Exception();

            browser.Navigate().GoToUrl("http://google.com");

            var queryBox = browser.FindElement(By.Name("q"));
            queryBox.SendKeys("codesprinters");
            queryBox.Submit();

            var serchResults = browser.FindElements(By.CssSelector("div.rc"));

            IWebElement expected = null;

            foreach (var result in serchResults)
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
