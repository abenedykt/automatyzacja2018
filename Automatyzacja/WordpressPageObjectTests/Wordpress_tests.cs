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
            var loginPage = new LoginPage(_browser);
            var adminPage = loginPage.Login(Config.User, Config.Password);
            adminPage.CreateNewNote();

            var exampleNote = new Note("abc", "lorem ipsium");
            adminPage.EditNote(exampleNote);
            var newNoteUrl = adminPage.PublishNote();

            var logoutPage = adminPage.Logout();
            Assert.True(loginPage.IsLoggedOut());

            var newNote = new NotePage(_browser, newNoteUrl);
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
