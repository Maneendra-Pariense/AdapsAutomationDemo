using AutomationNunit.Pages;

namespace AdapsSpecFlow.StepDefinitions
{
    [Binding]
    public sealed class WindowsSteps
    {       

        [Given(@"User clicks on skip register button")]
        public void GivenUserClicksOnSkipRegisterButton()
        {
           LoginPage loginPage = new LoginPage();
           loginPage.ClickOnSkipSignInButton();
        }

    }
}
