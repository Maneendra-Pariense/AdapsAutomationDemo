using AutomationNunit.Pages;

namespace AutomationNunit.Hooks
{
    [SetUpFixture]
    public class Hooks: BasePage
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {            
            Setup();   
            
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }


    }
}