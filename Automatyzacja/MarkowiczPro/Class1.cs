using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Net.WebRequestMethods;

namespace MarkowiczPro
{
    public class GoogleSearchTest : IDisposable
    {
        private IWebDriver browser;

        public GoogleSearchTest()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void Can_Markowicz_Go()
        {
            //throw new Exception();

            browser.Navigate().GoToUrl("http://markowicz.pro");

            var Articles = browser.FindElement(By.LinkText("O transformacjach"));
            Articles.Click();
            Articles.Submit();

            var link = title.FindElements(By.TagName("a"));

            IWebElement expected = null;

            foreach (var expectedtitle in link)
            {
                var link = expectedtitle.FindElement(By.CssSelector(""));
                if (expectedtitle.FindElement(By.CssSelector("")).GetAttribute("href") == "http://markowicz.pro/author/rafal-markowicz/")

                {
                    link = expectedtitle;
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

        private class title
        {
            internal static object FindElements(By by)
            {
                throw new NotImplementedException();
            }
        }
    }
}



