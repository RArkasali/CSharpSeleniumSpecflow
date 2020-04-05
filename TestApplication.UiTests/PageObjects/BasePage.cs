using OpenQA.Selenium;
using System.Collections.Generic;
using TestApplication.UiTests.Drivers;

namespace TestApplication.UiTests.PageObjects
{
    public class BasePage
    {
        protected WebDriver webDriver;
        public BasePage(WebDriver webDriver)
        {
            this.webDriver = webDriver;

        }

        protected IWebElement FindsBy(By locator)
        {
           return webDriver.Wait.Until(d => d.FindElement(locator));
        }

        protected List<IWebElement> FindsBys(By locator)
        {
            return new List<IWebElement>(webDriver.Wait.Until(d => d.FindElements(locator)));
        }

        protected void EnableOfElement(IWebElement element)
        {
            webDriver.Wait.Until<bool>(driver =>
            {
                return element.Enabled;
            });
        }

        protected void DisplayedOfElement(IWebElement element)
        {
            webDriver.Wait.Until<bool>(driver =>
            {
                return element.Displayed;
            });
        }
    }
}
