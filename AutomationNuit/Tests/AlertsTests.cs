using AutomationNunit.Pages;


namespace AutomationNunit.Tests
{
    //[Parallelizable(scope: ParallelScope.Fixtures)]
    [TestFixture]
    
    public class AlertsTests: Hooks.Hooks
    {
        HomePage homePage;
        LoginPage loginPage;
        AlertsPage alertsPage;
        

        public AlertsTests() {
            homePage = new HomePage();
            loginPage = new LoginPage();
            alertsPage = new AlertsPage();
            
        }
                

        [Test]
        public void AlertsTestValidation()
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("SwitchTo", "Alerts");
            alertsPage.HandleAlertWithOK();

        }
        [Test]
        public void AlertsTestValidationCancel()
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("SwitchTo", "Alerts");
            alertsPage.HandleAlertWithOK();

        }
        [Test]
        public void AlertsTestValidationText()
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("SwitchTo", "Alerts");
            alertsPage.HandleAlertWithText();

        }
        
    }
}
