using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Automatyzacja_2
{
    public class SearchTitleTest : IDisposable { 

        private IWebDriver browser;
    public SearchTitleTest()
        { 

        browser = new ChromeDriver();
        }
    public void Dispose()
    {
        browser.Quit();
    }
        
        [Fact]
        public void Cwiczenie1()
        {
           browser.Navigate().GoToUrl("http://markowicz.pro");

            var notes = browser.FindElements(By.CssSelector(".entry-title>a"));

            foreach (var note in notes)
            {
                if (note.Text == "O transformacjach")
                {
                    note.Click();
                    break;
                }
            }
            Assert.Equal("O transformacjach – Rafał Markowicz", browser.Title);

            var autor = browser.FindElement(By.CssSelector(".byline a"));

            Assert.Equal("Rafał", autor.Text);
            Assert.Equal("http://markowicz.pro/author/rafal-markowicz/", autor.GetAttribute("href"));
        }
    

        }





    }

