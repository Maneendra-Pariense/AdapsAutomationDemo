using AutomationNunit.Pages;

namespace AutomationNunit.Tests
{
    //[Parallelizable(scope: ParallelScope.Fixtures)]
    [TestFixture]
    public class LoginTest: Hooks.Hooks
    {
        LoginPage loginPage;
        RegisterPage registerPage;
        HomePage homePage;
        public LoginTest() {
            loginPage = new LoginPage();
            registerPage = new RegisterPage();
            homePage = new HomePage(); 
        }

        [Test]
        public void ClickSkipSignInButtonShouldNavigateToRegisterScreen()
        {
            loginPage.ClickOnSkipSignInButton();
            var actualTitle = registerPage.GetRegisterPageTitle();
            Assert.That(actualTitle, Is.EqualTo("Register"));

            homePage.NavigateTo("SwitchTo", "Alerts"); 

        }
       
    }
}
