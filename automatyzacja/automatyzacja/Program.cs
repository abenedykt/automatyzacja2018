using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatyzacja
{
    class Program
    {
        static void Main(string[] args)
        {
            var browser = new ChromeDriver();
            browser.Navigate().GoToUrl("http://google.com");
            var searchbox = browser.FindElement(By.Name("q"));
            searchbox.SendKeys("Code sprinters");
            searchbox.Submit();
            var results = browser.FindElements(By.CssSelector("div.rc"));

            foreach (var result in results)
            {
                result.FindElement(By.CssSelector(".r>a"));
                if (result.GetAttribute("href") == "http://agileszkolenia.pl/")
                    break;
            }

            //publi class var <= do zrobienia (podobno kuku można sobie zrobic)

            browser.Quit();
        }
    }
}
