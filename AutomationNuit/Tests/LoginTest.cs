using AutomationNunit.Pages;

namespace AutomationNunit.Tests
{
    public class LoginTest: BasePage
    {
        LoginPage loginPage;
        RegisterPage registerPage;
        HomePage homePage;
        public LoginTest() {
            loginPage = new LoginPage();
            registerPage = new RegisterPage();
            homePage = new HomePage(); 
        }


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Setup();

        }        

        [Test]
        public void ClickSkipSignInButtonShouldNavigateToRegisterScreen()
        {
            loginPage.ClickOnSkipSignInButton();
            var actualTitle = registerPage.GetRegisterPageTitle();
            Assert.That(actualTitle, Is.EqualTo("Register"));

            homePage.NavigateTo("SwitchTo", "Alerts"); 

        }

        [TearDown]
        public void Teardown()
        {
            Thread.Sleep(2000);
            _driver.Quit();
        }
    }
}
