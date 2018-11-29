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
            var loginPage = new LoginPage(_browser);
            var adminPage = loginPage.Login(Config.User, Config.Password);
            adminPage.CreatNewNote();

            var exampleNote = new Note("Nowy Super Tytuł", "Nowa Super Tresc Tresci");
            adminPage.EditNote(exampleNote);
            var newNoteUrl = adminPage.PublisshNote();

            var logoutPage = adminPage.Logout();
            //Assert.True(loginPage.IsloggedOut());

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




