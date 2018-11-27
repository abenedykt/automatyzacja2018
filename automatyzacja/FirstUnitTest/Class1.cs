using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NaiveUnitTest
{
    /* doinstalovany xunit i xunit.runner.visualstudio */
    public class GoogleTests : IDisposable
    {
        private IWebDriver browser;

        public GoogleTests()
        {
            browser = new ChromeDriver();
        }

        public void Dispose() //wykonuje się niezależnie od zakończenia metody <= poczytać o tym
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
            var searchbox = browser.FindElement(By.Name("q"));
            searchbox.SendKeys("Code sprinters");
            searchbox.Submit();
            var results = browser.FindElements(By.CssSelector("div.rc"));

            IWebElement expected = null;

            foreach (var result in results)
            {
                var link = result.FindElement(By.CssSelector(".r>a"));
                if (link.GetAttribute("href") == "http://agileszkolenia.pl/")
                {
                    expected = result;
                    break;
                }      
            }

            Assert.NotNull(expected);

            //publi class var <= do zrobienia (podobno kuku można sobie zrobic)
        }
    }
}
