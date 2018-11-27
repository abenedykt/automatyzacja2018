using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FinallUnitTest
{
    public class MarkowiczTest : IDisposable
    {
        private ChromeDriver browser;

        public MarkowiczTest()
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
        public void MarkowiczTransformacjaTest()
        {
            browser.Navigate().GoToUrl("http://markowicz.pro");
            //var articleTitle = browser.FindElement(By.XPath("//*[@id='post-261']//*[@class='entry-title']"));
            //var articleTitle = browser.FindElement(By.Id("post-261"));

            var articles = browser.FindElementsByCssSelector(".entry-title > a");
            foreach (var article in articles)
            {
                var href = article.GetAttribute("href");
                if (href == "http://markowicz.pro/o-transformacjach/")
                {
                    
                }
            }

            IWebElement expected = null;
            //var userName = browser.FindElementByClassName("author vcard");

            var results = browser.FindElementsByCssSelector("span > a");
            foreach (var result in results)
            {
                if (result.GetAttribute("href") == "http://markowicz.pro/author/rafal-markowicz/")
                {
                    expected = result;
                    break;
                }
            }

               

            Assert.NotNull(expected);
        }
    }
}
