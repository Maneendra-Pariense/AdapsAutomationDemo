using AutomationNunit.Pages;

namespace AutomationNunit.Tests
{
    public class LoginTest: BasePage
    {
        LoginPage loginPage;
        RegisterPage registerPage;
        public LoginTest() {
            loginPage = new LoginPage();
            registerPage = new RegisterPage();
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
            //Assert.That(actualTitle, Is.EqualTo("Register"));
            Assert.AreEqual("Register", actualTitle);
            registerPage.EnterFirstName("");

        }

        [TearDown]
        public void Teardown()
        {
            Thread.Sleep(2000);
            _driver.Quit();
        }
    }
}
