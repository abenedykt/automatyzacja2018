using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewTestAddCommnet
{
    public class NewComment: IDisposable
    {
        private IWebDriver browser;

        public NewComment()
        {
            browser = new ChromeDriver();
        } 

        private string GenerateEmail() //generator unikatowego adresu email
        {
            var user = Guid.NewGuid().ToString();
            return $"{user}@nonexistent.test.com";
        }


        [Fact]
        public void Comment()
        {
            var TextKomentarza = Guid.NewGuid().ToString(); //generator unikatowego tekstu komentarza

            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net");

            var comment = browser.FindElement(By.CssSelector("span.comments-link"));
            comment.Click();

            var queryBox = browser.FindElement(By.Name("comment"));
            queryBox.SendKeys(TextKomentarza);

            var name = browser.FindElement(By.Name("author"));
            name.SendKeys("Justyna");

            var email = browser.FindElement(By.Name("email"));
            email.SendKeys(GenerateEmail());

            var add = browser.FindElement(By.Name("submit"));
            add.Click();

            var comments = browser.FindElements(By.XPath("//*[@class='comment-content'] /p"));

            var checkcommnet = comments.Where(x => x.Text == TextKomentarza); //zapis z foreach przy uzyciu linq
            Assert.Single(checkcommnet);

            //IWebElement expected = null;
            // foreach (var result in komentarze)
            // {
            //     if (result.Text == TextKomentarza)
            //     { 
            //         expected = result;
            //         break;
            //     }
            // }
            // Assert.NotNull(expected);

        }

        public void Dispose()
        {
           if (browser != null)
            {
                browser.Quit();
            }
        }

        private void MoveToElement(By selector)

        {

            var element = browser.FindElement(selector);

            MoveToElement(element);

        }

        private void MoveToElement(IWebElement element)

        {

            Actions builder = new Actions(browser);

            Actions moveTo = builder.MoveToElement(element);

            moveTo.Build().Perform();

        }

        [Fact]
        public void Login()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); //czekanie po kazdej aksji 5s

            //Zalogowanie

            var username = browser.FindElement(By.Name("log"));
            username.SendKeys("automatyzacja");

            var password = browser.FindElement(By.Name("pwd"));
            password.SendKeys("jesien2018");

            var ClickToLogin = browser.FindElement(By.Name("wp-submit"));
            ClickToLogin.Click();

            //Sprawdzenie czy zalogowano

            var CheckIfLogin = browser.FindElement(By.CssSelector(".wrap > h1"));
            Assert.True(CheckIfLogin.Text == "Kokpit");

            //Wylogowanie

            var LoginName = browser.FindElement(By.CssSelector(".display-name"));
            Assert.True(LoginName.Text == "Jan Automatyczny"); 
            MoveToElement(LoginName);

            var logout = browser.FindElement(By.Id("wp-admin-bar-logout"));
            logout.Click();

            //Sprawdzenie czy wylogowano

            var CheckIfLogout = browser.FindElement(By.CssSelector("p.message"));
            Assert.True(CheckIfLogout.Text == "Wylogowano się.");

            var LoginPage = browser.FindElement(By.XPath ("//*[@id='loginform']/p[1]/label"));
            Assert.Equal("Nazwa użytkownika lub e-mail", LoginPage.Text);

        }
    }
}
