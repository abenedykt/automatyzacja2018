using System;
using OpenQA.Selenium;

namespace NaiveUnitTest
{
    internal class StronaWylogowania
    {
        private IWebDriver _browser;

        public StronaWylogowania(IWebDriver browser)
        {
            _browser = browser;
        }

       
        internal bool jest_otwarta()
        {
            // todo am I logged out? 

            return true;
        }
    }
}