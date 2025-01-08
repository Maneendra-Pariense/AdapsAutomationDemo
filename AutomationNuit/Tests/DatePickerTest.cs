using AutomationNunit.Pages;

namespace AutomationNunit.Tests
{
    public class DatePickerTest: BasePage
    {
        HomePage homePage;
        LoginPage loginPage;
        DatePickerPage datePickerPage;


        public DatePickerTest() {
            homePage = new HomePage();
            loginPage = new LoginPage();
            datePickerPage = new DatePickerPage();
                
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Setup();

        }

        [Test]
        public void DatePickerValidation()
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("Widgets", " Datepicker ");

            datePickerPage.selectDate("", "" , "" );




        }

        [TearDown]
        public void Teardown()
        {
            Thread.Sleep(5000);
            _driver.Quit();
        }
    }
}
