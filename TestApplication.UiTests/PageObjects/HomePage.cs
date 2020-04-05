using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using TestApplication.UiTests.Drivers;

namespace TestApplication.UiTests.PageObjects
{
    public class HomePage : BasePage
    {
        private readonly ConfigurationDriver _configurationDriver;
        public HomePage(WebDriver driver, ConfigurationDriver configurationDriver) : base(driver) {
            _configurationDriver = configurationDriver;
            webDriver.Current.Manage().Window.Maximize();
        }

        public void SelectedBoxCategory ()
        {
            var categoryIdwrp = FindsBy(By.Id("categoryId-wrp"));
            categoryIdwrp.Click();
        }

        public void SelectedCategory(string text)
        {
            string[] lstCatelogy = text.Split(';');

            if (lstCatelogy.Length > 0)
            {
                int index = lstCatelogy.Length - 1;
                IWebElement treeCategory = null;
                IWebElement category = null;

                var selectBoxCategory = FindsBy(By.CssSelector("div[id='categoryId-wrpwrapper'] ul[class='j-selectbox__ul']"));
                DisplayedOfElement(selectBoxCategory);

                var lstCategory = selectBoxCategory.FindElements(By.CssSelector("li[class^='j-selectbox__li']"));
                
                foreach (var item in lstCategory)
                {
                    if (item.Text.Trim() == lstCatelogy[0]) {
                        treeCategory = item;
                        break;
                    }
                }

                if (index == 0)
                {
                    DisplayedOfElement(treeCategory);
                    category = webDriver.Wait.Until<IWebElement>(driver =>
                    {
                        return treeCategory.FindElement(By.CssSelector("div[id^='categoryId-wrp-option-']"));
                    });
                }
                else {

                    DisplayedOfElement(treeCategory);
                    var expandIcon = webDriver.Wait.Until<IWebElement>(driver =>
                    {
                        return treeCategory.FindElement(By.CssSelector("span[class$='j-selectbox__down-icon']"));
                    });

                    EnableOfElement(expandIcon);
                    Actions actions = new Actions(webDriver.Current);
                    actions.MoveToElement(expandIcon).Click();
                    actions.Perform();

                    for (int i = 1; i <= index; i++)
                    {
                        DisplayedOfElement(treeCategory);
                        var lstCategoryTemp = treeCategory.FindElements(By.CssSelector("li"));
                        foreach (var item in lstCategoryTemp)
                        {
                            if (item.GetAttribute("textContent").Trim() == lstCatelogy[i])
                            {
                                treeCategory = item;
                                break;
                            }
                        }

                        if (i == index)
                        {
                            category = webDriver.Wait.Until<IWebElement>(driver =>
                            {
                                return treeCategory.FindElement(By.CssSelector("div[id^='categoryId-wrp-option-']"));
                            });
                            break;
                        }
                        else
                        {
                            expandIcon = webDriver.Wait.Until<IWebElement>(driver =>
                            {
                                return treeCategory.FindElement(By.CssSelector("span[class$='j-selectbox__down-icon']"));
                            });

                            EnableOfElement(expandIcon);
                            actions = new Actions(webDriver.Current);
                            actions.MoveToElement(expandIcon).Click();
                            actions.Perform();
                        }
                    }
                }

                EnableOfElement(category);
                Actions actionsCategory = new Actions(webDriver.Current);
                actionsCategory.MoveToElement(category).Click();
                actionsCategory.Perform();
            }

         
        }

        public void EnterSearchQuery(string text)
        {
            var searchQuery = FindsBy(By.Id("search-query"));
            searchQuery.Clear();
            searchQuery.SendKeys(text);
        }

        public void EnterSearchLocation(string text)
        {
            var searchLocation = FindsBy(By.CssSelector("input#search-area"));
            searchLocation.Clear();
            searchLocation.SendKeys(text);
        }

        public void SelectedBoxSearchDistance()
        {
            var boxSearchDistance = FindsBy(By.Id("srch-radius-wrp"));
            boxSearchDistance.Click();
        }

        public void SelectedSearchDistance(string text)
        {
           var numberRadius = text.Replace("KM", "");
           var searchDistance = FindsBy(By.Id("srch-radius-wrp-option-"+ numberRadius.Trim()+""));
            searchDistance.Click();
        }

        public SearchResultPage ClickSearchButton()
        {
            var searchButton = FindsBy(By.ClassName("header__search-button"));
            searchButton.Click();
            return new SearchResultPage(webDriver);
        }
    }
}
