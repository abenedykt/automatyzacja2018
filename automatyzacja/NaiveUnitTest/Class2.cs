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
    public class SprawdzTransform : IDisposable
    {


        private IWebDriver browser;

        public SprawdzTransform()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void Czy_strona_Rafal_transform()
        {
            //IWebDriver browser = new ChromeDriver();
            browser.Navigate().GoToUrl("http://markowicz.pro");
            var notki = browser.FindElements(By.CssSelector(".entry-title > a"));


            foreach (var notka in notki)
            {
                var tytul = notka.Text;
                if (tytul == "O transformacjach")
                {
                    notka.Click();
                    break;
                }
            }
            
            var autor = browser.FindElement(By.CssSelector(".author a"));

            Assert.Equal("Rafał", autor.Text);
            Assert.Equal("http://markowicz.pro/author/rafal-markowicz/", autor.GetAttribute("href"));

            
        }

        public void Dispose()
        {
            browser.Quit();
        }
    }
}
