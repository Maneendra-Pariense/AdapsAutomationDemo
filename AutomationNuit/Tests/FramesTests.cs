using AutomationNunit.Pages;

namespace AutomationNunit.Tests
{
    public class FramesTests: BasePage
    {
        HomePage homePage;
        LoginPage loginPage;
        FramesPage framesPage;

        public FramesTests() {
            homePage = new HomePage();
            loginPage = new LoginPage();
            framesPage = new FramesPage();
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Setup();

        }

        [Test]
        public void FramesTestValidation()
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("SwitchTo", "Frames");
            framesPage.SingleIFrame();
            homePage.NavigateTo("SwitchTo", "Frames");



        }
        [Test]
        public void FramesTestMultipleValidation()
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("SwitchTo", "Frames");
            framesPage.MultipleIFrame();
            //homePage.NavigateTo("SwitchTo", "Frames");



        }

        [TearDown]
        public void Teardown()
        {
            Thread.Sleep(5000);
            _driver.Quit();
        }
    }
}
