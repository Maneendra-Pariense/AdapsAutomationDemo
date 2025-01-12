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
        public void DatePickerValidation()
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("Widgets", " Datepicker ");

            datePickerPage.selectDate(2024, 10 , 10 );


        }
       
    }
}
