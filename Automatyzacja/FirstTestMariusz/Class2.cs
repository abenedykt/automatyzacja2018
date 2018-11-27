using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace FirstTestMariusz
{
    public class RafalSearchTest :IDisposable
    {
        private IWebDriver browser;
        public RafalSearchTest()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void SearchTransformationAndAssert()
        {
            browser.Navigate().GoToUrl("https://markowicz.pro");

            var row = browser.FindElement(By.XPath("//a[text()='O transformacjach']"));
            Assert.True(row.Text == "O transformacjach");
            row.Click();

            var user = browser.FindElements(By.CssSelector("span > a"));

            IWebElement expected = null;
            foreach (var result in user)
            {
                if (result.GetAttribute("href") == "https://markowicz.pro/author/rafal-markowicz/")
                {
                    expected = result;
                    break;
                }
            }
            Assert.NotNull(expected);
        }
        public void Dispose()
        {
            if (browser != null)
            {
                browser.Quit();
            }
        }
    }
}
