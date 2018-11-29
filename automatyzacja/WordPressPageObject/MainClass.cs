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
            var loginPage = new LoginPage(_browser);
            var adminPage = loginPage.Login(Config.User, Config.Password);
            var exampleNote = new Note("Tytul notatki M", "Tresc mojej notatki");

            adminPage.CreateNewNote();
            adminPage.EditNote(exampleNote);

            var newNoteUrl = adminPage.PublishNote();

            var logoutPage = adminPage.LogOut();
            Assert.True(loginPage.IsLoggedOut());

            var newNote = new NotePage(_browser, newNoteUrl);
            Assert.Equal(exampleNote.Title, newNote.Title);
            Assert.Equal(exampleNote.Content, newNote.Content);

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
