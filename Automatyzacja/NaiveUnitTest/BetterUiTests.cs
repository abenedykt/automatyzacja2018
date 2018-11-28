using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NaiveUnitTest
{
    public class BetterUiTests : IDisposable
    {
        private IWebDriver _browser;

        public BetterUiTests()
        {
            _browser = new ChromeDriver();
        }

        [Fact]
        public void Can_login_and_logout()
        {
            var strona_logowania = new StronaLogowania(_browser);
            var strona_administracyjna = strona_logowania.zaloguj(Configuration.UserName,Configuration.Password);
            Assert.True(strona_administracyjna.jest_otwarta());
            var strona_wylogowania = strona_administracyjna.wyloguj();
            Assert.True(strona_wylogowania.jest_otwarta());
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
