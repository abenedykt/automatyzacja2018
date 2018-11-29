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

            var exampleNote = new Note("abc", "lorem ipsum");
            adminPage.EditNote(exampleNote);
            var newNoteUrl = adminPage.PublishNote();

            var logutPage = adminPage.Logut();
            Assert.True(loginPage.IsLoggedOut());

            var newNote = new NotePage(newNoteUrl);
            Assert.Equal("abc", newNote.Title);
            Assert.Equal("lorem ipsum", newNote.Content);

        }

        public void Dispose()
        {
            try //po to, żeby posprzątać :)
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
