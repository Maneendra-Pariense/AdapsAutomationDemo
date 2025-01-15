using AutomationNunit.Pages;

namespace AdapsSpecFlow.Support
{
    [Binding]
    public sealed class SpecFlowInitHooks: BasePage
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
           
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            Setup();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            TearDown();
            
        }
    }
}