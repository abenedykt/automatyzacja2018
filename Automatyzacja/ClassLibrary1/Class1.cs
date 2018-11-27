using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RafałMarkowiczStrona
{
    public class Transformacje : ElementClickInterceptedException
    {
        private IWebDriver browser;

        public Transformacje
        {
            Browser = new ChromeDriver
        }

            [Fact]

        public void TransformacIje()
        {
            Browser.Navigate().GoToUrl("http://markowicz.pro");

            var querBox = Browser.FindElement(By.LinkText("http://markowicz.pro/o-transformacjach/"));
            querBox.Click("O Transformacjach");
            querBox.Submit();

            var serchResults = Browser.FindElements(By.CssSelector("div.rc"));

            foreach (var result in serchResults)
            {
                var link = result.FindElement(By.CssSelector(".r>a"));
                if (link.GetAttribute("href") == "http://agileszkolenia.pl/")

                {
                    Console.WriteLine("Znalazłem");
                    break;
                }

            }


            //browser.Quit();
        }

    private class Browser
    {
    }
}

}
