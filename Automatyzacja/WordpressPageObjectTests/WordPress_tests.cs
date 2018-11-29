using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Can_add_and_published_new_note()
        {
            var loginPage = new LoginPage(_browser);
            var adminPage = loginPage.Login(Config.User, Config.Password, Config.Page);
            adminPage.CreateNewNote();

            var exampleNote = new Note("abc", "lorem ipsium");
            adminPage.EditNote(exampleNote);
            var newNoteUrl = adminPage.PublishNote();

            var logoutPage = adminPage.Logout();
            Assert.True(loginPage.IsLoggeOut());

            var newNote = new NotePage(_browser, newNoteUrl);
            Assert.Equal("abc", newNote.Title);
            Assert.Equal("lorem ipsium", newNote.Content);

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
