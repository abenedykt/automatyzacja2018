using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WordpressPage;

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
        public void Can_and_and_publish_new_note()
        {
            var loginPage = new LoginPage(_browser);
            var adminPage = loginPage.Login(Config.User, Config.Password);
            adminPage.CreateNewNote();

            var exampleNote = new Note("abc", "loren ipsium");
            adminPage.EditNote(exampleNote);
            var newNoteUrl = adminPage.PublishNote();

            var logoutPage = adminPage.Logout();
            Assert.True(loginPage.IsLoggedOut());

            var newNote = new NotePage(newNoteUrl);
            Assert.Equal(exampleNote.Title, newNote.Title);
            Assert.Equal(exampleNote.Content, newNote.Content);

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
