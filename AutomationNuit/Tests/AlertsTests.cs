using AutomationNunit.Pages;

namespace AutomationNunit.Tests
{
    public class AlertsTests: BasePage
    {
        HomePage homePage;
        LoginPage loginPage;
        AlertsPage alertsPage;
        

        public AlertsTests() {
            homePage = new HomePage();
            loginPage = new LoginPage();
            alertsPage = new AlertsPage();
            
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Setup();

        }

        [Test]
        public void AlertsTestValidation()
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("SwitchTo", "Alerts");

        }

        [TearDown]
        public void Teardown()
        {
            Thread.Sleep(5000);
            _driver.Quit();
        }
    }
}
