using AdapsSpecFlow.Support;
using AutomationNunit.Pages;
using NUnit.Framework;
using System.Data;
namespace AdapsSpecFlow.StepDefinitions
{
    [Binding]
    public sealed class WindowsSteps
    {
        private ScenarioInfo _scenarioInfo;
        private ScenarioContext _scenarioContext;

        private readonly LoginPage loginPage;
        private readonly HomePage homePage;
        private readonly WindowsPage windowsPage;
        private readonly DatePickerPage datePickerPage;
        private readonly WebTablePage webTablePage;

        public WindowsSteps(ScenarioInfo scenarioInfo, ScenarioContext scenarioContext)
        {
            loginPage = new LoginPage();
            homePage = new HomePage();
            windowsPage = new WindowsPage();
            datePickerPage = new DatePickerPage();
            webTablePage = new WebTablePage();
            _scenarioInfo = scenarioInfo;
            _scenarioContext = scenarioContext;
        }


        [Given(@"User clicks on skip register button")]
        public void GivenUserClicksOnSkipRegisterButton()
        {           
           loginPage.ClickOnSkipSignInButton();
        }

        [When(@"User should click on Menu ""([^""]*)"" and then ""([^""]*)""")]
        public void WhenUserShouldClickOnMenuAndThen(string mainMenu, string subMenu)
        {
            homePage.NavigateTo(mainMenu, subMenu);
        }

        [Then(@"User should see ""([^""]*)"" screen")]
        public void ThenUserShouldSeeScreen(string title)
        {
           Assert.That(homePage.GetTitle(), Is.EqualTo(title));
        }

        [Then(@"User clicks on the Tab ""([^""]*)""")]
        public void ThenUserClicksOnTheTab(string tabName)
        {
            windowsPage.ClickOnTab(tabName);
        }

        [Then("User should click {string} button")]
        public void ThenUserShouldClickButton(string btn)
        {
            windowsPage.ClickOnClickButton(btn);
        }

        [Then("User should see {int} windows")]
        public void ThenUserShouldSeeWindows(int count)
        {
            Assert.That(windowsPage.GetWindowHandleCount(), Is.EqualTo(count));
        }

        [Then("User should switch to windows")]
        public void ThenUserShouldSwitchToWindows()
        {
            windowsPage.SwitchToWindow();
        }

        [Then("User should see new window with title {string}")]
        public void ThenUserShouldSeeNewWindowWithTitle(string title)
        {
            var actualTitle = windowsPage.GetWindowTitle();
            Assert.That(actualTitle, Is.EqualTo(title));

        }


        [When(@"User selects the year {int} month {int} and day {int}")]
        public void WhenUserSelectsTheYearMonthAndDay(int year, int month, int day)
        {
            datePickerPage.selectDate(year, month, day);
            Console.WriteLine("year: {0}, month: {1}, day: {2}", year, month, day);
        }

        [When(@"I use examples in my scenario")]
        public void IUseExamplesInMyScenario() {
            
        }

        [Then(@"the examples are available in ScenarioInfo")]
        public void TheExamplesAreAvailableInScenarioInfo()
        {           
            var currentArguments = _scenarioInfo.Arguments;
            var currentSport = currentArguments["Sport"];
            var currentTeamSize = currentArguments["TeamSize"];
            Console.WriteLine($"The current sport is {currentSport}");
            Console.WriteLine($"The current sport allows teams of {currentTeamSize} players");
        }

        [When(@"User enter credentials")]
        public void WhenUserEnterCredentials(Table table)
        {
            var dt = table.ToDataTable();
            Console.WriteLine("Rows count" + dt.Rows.Count);
            foreach ( DataRow row in dt.Rows )
            {
                Console.WriteLine("username: " + row["Username"]);
                Console.WriteLine("password: " + row["Password"]);
            }

        }

        [Then("User should see following headers in the grid")]
        public void ThenUserShouldSeeFollowingHeadersInTheGrid(Table table)
        {
            var t = table.ToDataTable();            
            Assert.That(webTablePage.ValidateHeaders(t));

        }

        [Then("user should see the {string} screen title")]
        public void ThenUserShouldSeeTheScreenTitle(string title)
        {
            var actualTitle = homePage.GetTitle();
            Assert.That(actualTitle, Is.EqualTo(title));
        }

        [Given("User navigates to the screen {string}")]
        public void GivenUserNavigatesToTheScreen(string menu)
        {
            homePage.NavigateTo(menu);
        }





    }
}
