using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Automatyzacja_2
{
    public class PublicationOfACommentOnTheWebsiteTest : IDisposable
    {

        private IWebDriver browser;
        public PublicationOfACommentOnTheWebsiteTest()
        {
            browser = new ChromeDriver();
        }
        public void Dispose()
        {
            browser.Quit();
        }
        [Fact]
        public void Cwiczenie2()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net");

            var Comments = browser.FindElement(By.CssSelector(".comments-link>a"));
            Comments.Click();


            var AddComment = browser.FindElement(By.Name("comment"));
            var exampleComment = GenerateComment();
            AddComment.SendKeys(exampleComment);

            var AddEmail = browser.FindElement(By.Name("email"));
            AddEmail.SendKeys(GenerateEmail());

            var Signature = browser.FindElement(By.Name("author"));
            Signature.SendKeys("Mario");

            var PostAComment = browser.FindElement(By.Name("submit"));
            PostAComment.Submit();

            var comments = browser.FindElements(By.CssSelector(".comment-content"));
            Assert.NotNull(comments.Single(x => x.Text == exampleComment));

        }
        private string GenerateEmail()
        {
            var user = Guid.NewGuid().ToString();
            return $"mariola.{user}@nonexistent.test.com";

        }
        private string GenerateComment()
        {
            var AddComment = Guid.NewGuid().ToString();
            return $"Dodaję komentarz.{AddComment}Dodaję komentarz";

        }

    }

    public class LoginToTheWordPressWebsire : IDisposable { 
    
        private IWebDriver browser;
        public LoginToTheWordPressWebsire()
        {
            browser = new ChromeDriver();
        }
        public void Dispose()
        {
            browser.Quit();
        }

        [Fact]
        public void Ćwiczenie3()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");

            var login = browser.FindElement(By.Id("user_login"));
            login.SendKeys("automatyzacja");

            var password = browser.FindElement(By.Name("pwd"));
            password.SendKeys("jesien2018");

            var SignIn = browser.FindElement(By.Name("wp-submit"));
            SignIn.Submit();

            var IamOnTheWebsite = browser.FindElement(By.CssSelector(".display-name"));  
            Assert.Equal("Jan Automatyczny", IamOnTheWebsite.Text);

            var Photo = browser.FindElement(By.CssSelector("#wp-admin-bar-my-account > a > img"));
            MoveToElement(Photo);
            browser.Manage()
               .Timeouts()
               .ImplicitWait = TimeSpan.FromSeconds(5);

            var logOut = browser.FindElement(By.CssSelector("#wp-admin-bar-logout > a"));
            logOut.Click();
        }
        private void MoveToElement(IWebElement photo)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(photo);
            moveTo.Build().Perform();
        }
        
    }
   
}

