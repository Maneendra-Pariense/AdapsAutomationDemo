
namespace AutomationNunit.Pages
{
    public class DatePickerPage: BasePage
    {

        IWebElement datePicker1 => _driver.FindElement(By.Id("datepicker1"));
        // //div[@id = 'ui-datepicker-div']//table/tbody/tr/td/a[text() = '5']
        IWebElement selectDate(string day) => _driver.FindElement(By.XPath($"//div[@id = 'ui-datepicker-div']//table/tbody/tr/td/a[text() = '{day}']"));





        public void selectDate(int year, int month, int day)
        {
            datePicker1.Click();
            Thread.Sleep(1000);

            DateTime date = new DateTime(year, month, day);

            var todaysDate = DateTime.UtcNow;
            var futureDate = todaysDate.AddDays(2);           

            selectDate(futureDate.Day.ToString()).Click();
            
            


        }
    }
}
