using AutomationNunit.Pages;

namespace AutomationNunit.Tests
{
    public class LoginTest: BasePage
    {

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Setup();

        }        

        [Test]
        public void ClickSignInButtonShouldNavigateToRegisterScreen()
        {            
          

        }

        [TearDown]
        public void Teardown()
        {
            Thread.Sleep(2000);
            _driver.Quit();
        }
    }
}
