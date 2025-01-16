using AutomationNunit.Pages;

namespace AdapsSpecFlow.StepDefinitions
{
    [Binding]
    public sealed class WindowsSteps
    {
        //Page Object for Calculator
        private readonly LoginPage loginPage;

        public WindowsSteps()
        {
            loginPage = new LoginPage();
        }


        [Given(@"User clicks on skip register button")]
        public void GivenUserClicksOnSkipRegisterButton()
        {           
           loginPage.ClickOnSkipSignInButton();
        }

    }
}
