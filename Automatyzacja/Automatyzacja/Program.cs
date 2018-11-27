﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatyzacja
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver browser = new ChromeDriver();
            browser.Navigate().GoToUrl("http://google.com");

            var queryBox = browser.FindElement(By.Name("q"));
            queryBox.SendKeys("codesprinters");
            queryBox.Submit();

            var serchResults = browser.FindElements(By.CssSelector("div.rc"));

            foreach (var result in serchResults)
            {
              var link =  result.FindElement(By.CssSelector(".r>a"));
                if (link.GetAttribute("href") == "http://agileszkolenia.pl/")

                {
                    Console.WriteLine("Znalazłem");
                    break;
                }

            }


            //browser.Quit();

        }
    }
}
