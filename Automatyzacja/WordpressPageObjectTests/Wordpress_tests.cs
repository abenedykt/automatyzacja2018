using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace WordpressPageObjectTests
{
    public class Wordpress_tests : IDisposable
    {
        private IWebDriver _browser;

        public Wordpress_tests()
        {
            _browser = new ChromeDriver();
        }

        [Fact]
        public void Can_add_and_publish_new_note()
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
