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
    public class MarkowiczTests : IDisposable
    {
        private IWebDriver broswer;

        public  MarkowiczTests()
        {
            broswer = new ChromeDriver();
        }

        [Fact]
        public void Can_markowicz_out_o_transformacjach()
        {
            broswer.Navigate().GoToUrl("http://markowicz.pro");

            var linkdonotki = broswer.FindElement(By.XPath("//a[text()='O transformacjach']"));
            linkdonotki.Click();

            var linkdoautora = broswer.FindElement(By.CssSelector(".byline .author a"));
            Assert.Equal("Rafał", linkdoautora.Text);

            Assert.Equal("http://markowicz.pro/author/rafal-markowicz/", linkdoautora.GetAttribute("href"));
           

        }

        public void Dispose()
        {
            broswer.Quit();
        }
    }
}
