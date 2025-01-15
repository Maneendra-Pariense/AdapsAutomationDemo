namespace AutomationNunit.Pages
{
    public class AlertsPage: BasePage
    {
        // locators
        IWebElement okTab => _driver.FindElement(By.XPath("//a[@href ='#OKTab']"));
        IWebElement cancelTab => _driver.FindElement(By.XPath("//a[@href ='#CancelTab']"));
        IWebElement textbox => _driver.FindElement(By.XPath("//a[@href ='#Textbox']"));

        IWebElement okTabAlertButton => _driver.FindElement(By.XPath("//div[@id ='OKTab']/button"));
        IWebElement cancelTabAlertButton => _driver.FindElement(By.XPath("//div[@id ='CancelTab']/button"));

        IWebElement textTabAlertButton => _driver.FindElement(By.XPath("//div[@id ='Textbox']/button"));


        public void HandleAlertWithOK()
        {
            okTab.Click();
            okTabAlertButton.Click();
            Thread.Sleep(1000);
            var myAlert = _driver.SwitchTo().Alert();
            var actualText = myAlert.Text;
            Console.WriteLine(actualText);
            //myAlert.Accept();
            myAlert.Dismiss();
        }

        public void HandleAlertWithOKAndCancel()
        {

        }

        public void HandleAlertWithText()
        {
            textbox.Click();
            textTabAlertButton.Click();
            Thread.Sleep(2000);
            var myAlert = _driver.SwitchTo().Alert();
            myAlert.SendKeys("verify sending text in the alert");
            myAlert.Accept();
        }
    }
}
