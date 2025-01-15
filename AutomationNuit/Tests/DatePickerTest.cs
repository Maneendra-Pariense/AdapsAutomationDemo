using AutomationNunit.Pages;

namespace AutomationNunit.Tests
{
    //[Parallelizable(scope: ParallelScope.Fixtures)]
    [TestFixture]
    public class DatePickerTest: Hooks.Hooks
    {
        HomePage homePage;
        LoginPage loginPage;
        DatePickerPage datePickerPage;
        public DatePickerTest() {
            homePage = new HomePage();
            loginPage = new LoginPage();
            datePickerPage = new DatePickerPage();                
        }               

        [Test]
        //[TestCase(2025, 01, 20)]
        //[TestCase(2025, 01, 15)]
        [TestCaseSource("getDate")]
        public void DatePickerValidation(int year, int month, int day)
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("Widgets", " Datepicker ");

            datePickerPage.selectDate(year, month, day );
            Console.WriteLine("year: {0}, month: {1}, day: {2}", year, month, day);

        }

        private static IEnumerable<TestCaseData> getDate()
        {
            yield return new TestCaseData(2025, 01, 10).
                SetName("Date Test 10");
            yield return new TestCaseData(2025, 01, 15).
                SetName("Date Test 15");
            yield return new TestCaseData(2024, 01, 18).
                SetName("Date Test 18");
        }
    }
}
