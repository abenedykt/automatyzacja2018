using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace WordPressPageObject
{
    public class Wrod_Press_Test_Page_Object : IDisposable
    {
        private IWebDriver _browser;

        public Wrod_Press_Test_Page_Object()
        {
            _browser = new ChromeDriver();
        }

        [Fact]

        public void Cann_Add_and_publish_New_nowe()
        {

        }

        public void Dispose()
        {
            try
            {
                _browser.Quit();
                _browser.Dispose();
            }
            catch (Exception)
            {

            }

        }
    }
}




