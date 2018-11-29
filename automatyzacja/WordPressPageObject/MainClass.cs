using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace WordPressPageObject
{
    public class WordPressTests : IDisposable
    {
        private IWebDriver _browser;

        [Fact]
        public void CanAddAndPublishNewNote()
        {

        }

        public WordPressTests()
        {
            _browser = new ChromeDriver();
        }

        public void Dispose()
        {
            try
            {
                _browser.Quit();
                _browser.Dispose(); //wywalenie procesu Chrome.exe
            }
            catch (Exception) //wylapuje wyjatek
            {
            }
        }
    }
}
