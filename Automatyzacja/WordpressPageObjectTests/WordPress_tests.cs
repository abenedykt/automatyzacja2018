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
            var adminPage = loginPage.Login(Config.User, Config.Password);
            adminPage.OpenNewNoteEditor();

            var exampleNote = new Note("abc", "lorem ipsium");
            adminPage.CreateNewNote(exampleNote);
            var newNoteUrl = adminPage.PublishNote();

            var logaoutPage = adminPage.Logaout();
            Assert.True(loginPage.IsLoggeOut());

            var newNote = new NotePage(newNoteUrl);
            Assert.Equal("abc", newNote.Title);
            Assert.Equal("lorem ipsium", newNote.Contente);

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
