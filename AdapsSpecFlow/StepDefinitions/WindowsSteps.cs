using AutomationNunit.Pages;

namespace AdapsSpecFlow.StepDefinitions
{
    [Binding]
    public sealed class WindowsSteps
    {
        //Page Object for Calculator
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;
        private readonly WindowsPage windowsPage;
        private readonly DatePickerPage datePickerPage;

        public WindowsSteps()
        {
            loginPage = new LoginPage();
            homePage = new HomePage();
            windowsPage = new WindowsPage();
            datePickerPage = new DatePickerPage();
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
            homePage.NavigateTo("SwitchTo", "Windows");
        }

        [Then(@"User should see ""([^""]*)"" screen")]
        public void ThenUserShouldSeeScreen(string windows)
        {
            throw new PendingStepException();
        }

        [Then(@"User clicks on the Tab ""([^""]*)""")]
        public void ThenUserClicksOnTheTab(string tabName)
        {
            windowsPage.ClickOnTab(tabName);
        }

        [When(@"User selects the year (.*) month (.*) and day (.*)")]
        public void WhenUserSelectsTheYearMonthAndDay(int year, int month, int day)
        {
            datePickerPage.selectDate(year, month, day);
            Console.WriteLine("year: {0}, month: {1}, day: {2}", year, month, day);
        }



    }
}
