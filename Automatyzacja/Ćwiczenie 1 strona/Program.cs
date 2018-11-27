using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Ćwiczenie_1_strona
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver browser = new ChromeDriver();
            browser.Navigate().GoToUrl("http://markowicz.pro");

            var note = browser.FindElements(By.CssSelector(".entry-title>a"));

            foreach (var notes in note)
            {
                if( notes.Text == "O transformacjach")
                {
                    Console.WriteLine("Udało się");
                    break;
                }
            }
            browser.Quit();
        }
    }
}
