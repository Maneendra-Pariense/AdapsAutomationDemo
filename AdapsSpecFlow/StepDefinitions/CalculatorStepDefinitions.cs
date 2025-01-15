using AutomationNunit.Pages;

namespace AdapsSpecFlow.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        { 
            LoginPage loginPage = new LoginPage();
            loginPage.ClickOnSkipSignInButton();
            Console.WriteLine("Test step passed: " + number);
            
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            
            Console.WriteLine("Test step passed: " + number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
           
            Console.WriteLine("Test step passed: ");
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            
            Console.WriteLine("Test step passed: ");
        }
    }
}
