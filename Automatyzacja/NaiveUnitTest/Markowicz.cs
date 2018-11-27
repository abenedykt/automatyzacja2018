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
    public class Markowicz: IDisposable
    {
        private IWebDriver browser;

        public Markowicz()
        {
            browser = new ChromeDriver();

        }

        public void Dispose()
        {
            browser.Quit();
        }

        [Fact]
        public void Zadanie()
        {
            browser.Navigate().GoToUrl("http://markowicz.pro/");

            var articles = browser.FindElements(By.TagName("article"));

            IWebElement title = null;

            foreach (var article in articles)
            {
               var expectedtitle = article.FindElement(By.ClassName("entry-title"));
                if (expectedtitle.Text == "O transformacjach")
                {
                    title = expectedtitle;
                    break;
                }
            }

            Assert.NotNull(title);


            var link = title.FindElement(By.TagName("a"));
            link.Click();
            var author = browser.FindElement(By.CssSelector(".byline .author a"));

            Assert.Equal("Rafał", author.Text);
            Assert.Equal("http://markowicz.pro/author/rafal-markowicz/", author.GetAttribute("href"));




        }

    }
}
