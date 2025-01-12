using AutomationNunit.Pages;

namespace AutomationNunit.Tests
{
    //[Parallelizable(scope: ParallelScope.Fixtures)]
    [TestFixture]
    public class FramesTests: Hooks.Hooks
    {
        HomePage homePage;
        LoginPage loginPage;
        FramesPage framesPage;

        public FramesTests() {
            homePage = new HomePage();
            loginPage = new LoginPage();
            framesPage = new FramesPage();
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

       
    }
}
