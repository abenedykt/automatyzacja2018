using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        public void Can_add_and_publish_new_note()
        {
            var loginPage = new LoginPage(_browser); // otwórz stronę logowania w przeglądarce
            var adminPage = loginPage.Login(Config.Url, Config.User, Config.Password); // zaloguj na stronę administracyjną się podając login i hasło 
            adminPage.CreateNewNote(_browser); // stwórz nową notatkę na stronie administracyjnej

            var exampleNote = new Note("abc", "lorem ipsum"); // stwórz nową notatkę z tytułem i treścią i przypisz ją do exampleNote
            adminPage.EditNote(exampleNote); // na stronie administracyjnej edytuj notatkę
            var newNoteUrl = adminPage.PublishNote(); // na stronie administracyjnej opublikuj notatkę, która zwróci URL/URI

            var logoutPage = adminPage.Logout(); // na str. adm. wylogujemy się na stronę logowania
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
