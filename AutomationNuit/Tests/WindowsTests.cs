using AutomationNunit.Pages;

namespace AutomationNunit.Tests
{
    public class WindowsTests: BasePage
    {
        HomePage homePage;
        LoginPage loginPage;
        WindowsPage windowsPage;
        
        public WindowsTests() {
            homePage = new HomePage();
            loginPage = new LoginPage();
            windowsPage = new WindowsPage();
           
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Setup();

        }

        [Test]
        public void WindowsTestValidation()
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("SwitchTo", "Windows");

        }

        [TearDown]
        public void Teardown()
        {
            Thread.Sleep(5000);
            _driver.Quit();
        }
    }
}
