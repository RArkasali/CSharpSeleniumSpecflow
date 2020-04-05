using FluentAssertions;
using TechTalk.SpecFlow;
using TestApplication.UiTests.PageObjects;


namespace TestApplication.UiTests.Steps
{
    [Binding]
    public class GumtreeFeatureSteps
    {
        private readonly HomePage _homePage;
        private SearchResultPage _searchResultPage;

        public GumtreeFeatureSteps(HomePage homePage)
        {
            _homePage = homePage;
        }

        [When(@"I search Categories '(.*)' and Keywords '(.*)' and Location '(.*)' and  Radius '(.*)'")]
        public void WhenISearchCategoriesAndKeywordsAndLocationAndRadius(string categories, string keywords, string location, string radius)
        {
            _homePage.SelectedBoxCategory();
            _homePage.SelectedCategory(categories);
            _homePage.EnterSearchQuery(keywords.Trim());
            _homePage.EnterSearchLocation(location.Trim());
            _homePage.SelectedBoxSearchDistance();
            _homePage.SelectedSearchDistance(radius);
            _searchResultPage = _homePage.ClickSearchButton();
        }
        
        [When(@"The number of results under Most Recent for page and the number of results show in label should  be '(.*)'")]
        public void WhenTheNumberOfResultsUnderMostRecentForPageAndTheNumberOfResultsShowInLabelShouldBe(string result)
        {
            string contentLabel = _searchResultPage.GetLabelResult();
            contentLabel.Should().Contain(result);
            int numberResult = int.Parse(result.Trim());
            _searchResultPage.GetNumbertOfMostRecentResult().Should().Be(numberResult);
            _searchResultPage.ClickPageNumber2();
            _searchResultPage.GetNumbertOfMostRecentResult().Should().Be(numberResult);
            _searchResultPage.ClickPageNumber3();
            _searchResultPage.GetNumbertOfMostRecentResult().Should().Be(numberResult);
            _searchResultPage.ClickPageNumber4();
            _searchResultPage.GetNumbertOfMostRecentResult().Should().Be(numberResult);
        }
        
        [When(@"I click on a random advert on  this page")]
        public void WhenIClickOnARandomAdvertOnThisPage()
        {
            _searchResultPage.ClickItemTopAdResult();
        }
        
        [When(@"I click on Images button on   advert")]
        public void WhenIClickOnImagesButtonOnAdvert()
        {
            _searchResultPage.ClickImagesButton();
        }
        
        [Then(@"I cycle through all available images by clicking the  right slider")]
        public void ThenICycleThroughAllAvailableImagesByClickingTheRightSlider()
        {
            _searchResultPage.ClickButtonNextImage();
        }
    }
}
