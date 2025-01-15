using AutomationNunit.Pages;
[assembly: LevelOfParallelism(3)]
[assembly: Parallelizable(scope: ParallelScope.Fixtures)]

namespace AutomationNunit.Hooks
{
    
    [TestFixture]
    public class Hooks: BasePage
    {
        [SetUp]
        public void OneTimeSetup()
        {            
            Setup();   
            
        }

        [TearDown]
        public void TearDownHook()
        {
           TearDown();
        }


    }
}