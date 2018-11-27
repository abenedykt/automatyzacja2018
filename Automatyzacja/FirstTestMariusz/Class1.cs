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
    public class Class1
    {
        [Fact]
        public void ExampleTest()
        {
            IWebDriver browser = new ChromeDriver();
            browser.Navigate().GoToUrl("https://google.com");

            var queryBox = browser.FindElement(By.Name("q"));
            queryBox.SendKeys("code sprinters");
            queryBox.Submit();

            var searchResults = browser.FindElements(By.CssSelector("div.rc"));

            foreach (var result in searchResults)
            {
                var link = result.FindElement(By.CssSelector(".r>a"));
                if (link.GetAttribute("href") == "http://agileszkolenia.pl/")
                {
                    
                    break;
                }
            }
            browser.Quit();
        }
    }
}
