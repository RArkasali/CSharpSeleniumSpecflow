using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TestApplication.UiTests.Drivers;
using TestApplication.UiTests.Utility;

namespace TestApplication.UiTests.PageObjects
{
    public class SearchResultPage : BasePage
    {
        public SearchResultPage(WebDriver driver) : base(driver) { }

        private List<IWebElement> lstPageNumber;
        private int countImage;
        public string GetLabelResult()
        {
            return  (new SelectElement(FindsBy(By.CssSelector("div.results-per-page-selector select")))).SelectedOption.Text;
        }

        public int GetNumbertOfMostRecentResult()
        {
            var searchResultSpage = FindsBy(By.CssSelector("section[class^='search-results-page__'] div[class*='search-results-page__main-ads-wrapper']"));
            webDriver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.TIMEWAITING);
            return searchResultSpage.FindElements(By.CssSelector("a[id^='user-ad-']")).Count;
        }

        public void ClickPageNumber2()
        {
            lstPageNumber = FindsBys(By.CssSelector("div[class='page-number-navigation'] a"));
            IWebElement element = lstPageNumber[2];
            EnableOfElement(element);
            element.Click();
        }

        public void ClickPageNumber3()
        {
           IWebElement element = lstPageNumber[3];
            EnableOfElement(element);
            element.Click();
        }

        public void ClickPageNumber4()
        {
            IWebElement element = lstPageNumber[4];
            EnableOfElement(element);
            element.Click();
        }

        public void ClickItemTopAdResult()
        {
            var lstItem = FindsBys(By.CssSelector("section[class^='search-results-page__'] div[class*='panel-body--flat-panel-shadow'] a[id^='user-ad-']"));
            Random random = new Random();
            int index = random.Next(0, lstItem.Count -1);
            lstItem[index].Click();
        }

        public void ClickImagesButton()
        {
            var imagesButton = FindsBy(By.CssSelector("div[class='vip-ad-image__main-image-wrapper'] div[class='vip-ad-image__legend'] button"));
            if (imagesButton != null && imagesButton.Text != string.Empty)
            {
                string contentImage = imagesButton.Text.Trim();
                countImage = Int32.Parse(contentImage.Replace("images", "")) - 1;
            }

            EnableOfElement(imagesButton);
            Actions actions = new Actions(webDriver.Current);
            actions.MoveToElement(imagesButton).Click();
            actions.Perform();
        }

        public void ClickButtonNextImage()
        {
            var buttonNextImage = FindsBy(By.CssSelector("div[class='vip-ad-gallery__controls'] button[class$='__nav-btn--next']"));
            for (int i = 0; i < countImage; i++)
            {
                EnableOfElement(buttonNextImage);
                buttonNextImage.Click();
            }
        }
    }
}
