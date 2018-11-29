using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Textwait
using System.Threading.Tasks;
using Xunit;

namespace NaiveUnitTest
{
    public class BlogAutomatyzacja : IDisposable
    {
        private IWebDriver browser;
        private object _browser;

        public BlogAutomatyzacja()
        {
            browser = new ChromeDriver();
        }

      private string GenerateEmail()
            {
                var user = Guid.NewGuid().ToString();
                return $"{user}@nonexistent.test.com";

            }

        [Fact]
        public void Wpisz_komentarz()
        {
           

            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net");
            var komentarz = browser.FindElement(By.CssSelector("span.comments-link"));
            komentarz.Click();
            var wkoment = browser.FindElement(By.Name("comment"));

            var ktext = Guid.NewGuid().ToString();


            wkoment.SendKeys(ktext);


            wkoment.Click();

            //wkoment.Submit();

            var authorkom = browser.FindElement(By.Name("author"));
            authorkom.SendKeys("ElaK");
            var mailkom = browser.FindElement(By.Name("email"));
            mailkom.SendKeys(GenerateEmail());
            var opublkom = browser.FindElement(By.Name("submit"));
            opublkom.Click();


            var comments = browser.FindElements(By.CssSelector(".comment-content"));

            Assert.NotNull(comments.Single(x=>x.Text == ktext));
              
        }

        public void Dispose()
        {
            browser.Quit();
        }
        private void WaitForClickable(By by, int seconds)
                 {
                     var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
                     wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
                 }
       

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }
        [Fact]
        public void SprLogowanie()
        {
         

            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/wp-admin");
            var logname = browser.FindElement(By.Name("log"));
            logname.SendKeys("automatyzacja");

            var logpwd= browser.FindElement(By.Name("pwd"));
            logpwd.SendKeys(" jesien2018");
            //logpwd.Submit();
            IWebElement logkey= browser.FindElement(By.Name("wp-submit"));
            
            logkey.Submit();
            //logkey.

            IWebElement logkto = browser.FindElement(By.ClassName("display-name"));

            Assert.Equal("Jan Automatyczny", logkto.Text);


            //IWebElement logpopup = browser.FindElement(By.ClassName("menupopwith-avatar"));

            MoveToElement(logkto);

            By logoutlinkselector = By.Id("wp-admin-bar-logout");

            WaitForClickable(logoutlinkselector, 5);


            IWebElement log_out = browser.FindElement(logoutlinkselector);

            log_out.Click();

            logname = browser.FindElement(By.Name("log"));

            Assert.NotNull(logname);






        }


    }
}
