using System.Data;

namespace AutomationNunit.Pages
{
    public class WebTablePage: BasePage
    {
        List<IWebElement> uiHeaders => _driver.FindElements(By.XPath("//div[@role= 'columnheader']//span[contains(@class, 'header-cell-label')]")).ToList();


        public List<string> GetUiWebTableHeaders()
        {
            List<string> headers = new List<string>();

            uiHeaders.ForEach(x=> headers.Add(x.Text));
            return headers.ToList();
        }

        public bool ValidateHeaders(DataTable table)
        {
            var headers = table.Rows.Cast<DataRow>().Select(x => x.ItemArray[0].ToString()).ToList();
            var uiHeaders = GetUiWebTableHeaders();

            var result = headers.SequenceEqual(uiHeaders);


            return result;

        }
    }
}
