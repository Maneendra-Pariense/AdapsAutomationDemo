using AutomationNunit.Pages;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using AngleSharp.Text;

namespace AdapsSpecFlow.Support
{
    [Binding]
    public sealed class SpecFlowInitHooks: BasePage
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario("@tag1", Order =0), Scope(Tag ="")]
        [BeforeScenario(Order = 1)]
        //[Scope(Tag = "@tag1")]
        public void BeforeScenarioWithTag(ScenarioContext scenarioContext)
        {
            var tags = scenarioContext.ScenarioInfo.Tags;
            Console.WriteLine("Before Scenario Tag: " + tags[0]);
        }
        
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext) {
            var featureTitle = featureContext.FeatureInfo.Title;
            var featureDescription = featureContext.FeatureInfo.Description;
            var error = featureContext.TestError;
            Console.WriteLine("Feature Title: {0}",  featureTitle);
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(FeatureContext fc)
        {            
            var tags = fc.FeatureInfo.Tags;
            bool isChrome = tags.Contains("chrome", StringComparison.InvariantCultureIgnoreCase);
            bool isfirefox = tags.Contains("firefox", StringComparison.InvariantCultureIgnoreCase);
            if (isChrome)
            {
                browserName = "chrome";
            }
            else if (isfirefox)
            {
                browserName = "Firefox";
            }
            Setup();
        }

        [BeforeScenario(Order = 2)]
        public void SecondBeforeScenario(ScenarioContext scenarioContext)
        {
           
            var scenarioName = scenarioContext.ScenarioInfo.Title;
            Console.WriteLine("Scenario Name: {0}", scenarioName);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext) {

            var stepName = scenarioContext.StepContext.StepInfo.Text;
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType;
            Console.WriteLine("Scenario Name: {0}", stepName);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                TakeScreenshot();
            }
            TearDown();
            
        }        

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("After Feature");
        }
    }
}