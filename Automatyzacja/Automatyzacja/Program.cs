using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Automatyzacja
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver browser = new ChromeDriver();
            browser.Navigate().GoToUrl("http://google.com");

            var queryBox = browser.FindElement(By.Name("q"));
            queryBox.SendKeys("code sprinters");
            queryBox.Submit();

            var searchResult = browser.FindElements(By.CssSelector("div.rc"));
            foreach (var result in searchResult)
            {
                var link = result.FindElement(By.CssSelector(".r>a"));
                if (link.GetAttribute("href") == "http://codesprinters.com/")
                {
                    Console.WriteLine("Znalazłem");
                    break;
                }
            }

            //browser.Quit();
        }
    }
}
