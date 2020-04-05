## TechnicalTest Project
This project is created to be able to run web ui tests for multiple browsers using C# with Selenium and SpecFlow, and also it has been configured with screenshot capability after each step and embeds the screenshot in the final report.

The test automation framework is completely object oriented, and the page object model has been implemented in the project.

Creating automated web tests to test an application in addition to testing the application with unit tests is a good practice. 

SpecFlow supports behaviour driven development and acceptance tests driven development.

### Set up environment build project
- Install visual studio 2017
- Install Nuget
- Install the SpecFlow Visual Studio extension
- .Net core 2.1

### Important parts
#### test-appsettings.json
Browser type and the default url are defined in test-appsettings.json file. Test scripts supports 3 browsers such as Chrome, Explorer and Firefox, which are set with the value as CHROME, IE, FIREFOX 

```
{
  "BaseUrl": "https://www.gumtree.com.au",
  "browser": "CHROME"
}

```
#### GumtreeFeature.feature
Here the test scenarios are defined [here](https://github.com/tmhai7th1/TechnicalTest/blob/master/TestApplication.UiTests/Features/GumtreeFeature.feature).

### Run test
Download the project, and make sure the environment is setup and ready to build the project.
 - Clean and build the project successfully in visual studio
 - Open Test Explorer on visual studio
 - Right click in current project, then choose Run selected test
 - Test project will run with scenario mentioned in the GumtreeFeature.feature 
 
Post execution the test results can be verified in "Report.html" file in TestResults folder.
