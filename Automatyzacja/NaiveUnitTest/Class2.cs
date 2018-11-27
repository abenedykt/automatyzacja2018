using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewPageMarkowicz
{
    public class Markowicz : IDisposable
    {
        private IWebDriver browser;
       
        public Markowicz()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void Markowicz_Find_Rafał()
        {
            browser.Navigate().GoToUrl("http://markowicz.pro");

            var row = browser.FindElement(By.XPath("//a[text()='O transformacjach']"));

            Assert.True(row.Text == "O transformacjach");
            row.Click();

            var name = browser.FindElements(By.CssSelector("span > a"));

            IWebElement expected = null;
            foreach (var result in name)
            {                
                if (result.GetAttribute("href") == "http://markowicz.pro/author/rafal-markowicz/")
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
