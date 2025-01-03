namespace AutomationNunit.Pages
{
    public class LoginPage: BasePage
    {
        // locators
        #region Locators
        IWebElement skipSignInButton => _driver.FindElement(By.Id("btn2"));
        


        #endregion


        // methods
        #region Methods
        public void ClickOnSkipSignInButton()
        {
            skipSignInButton.Click();
        }

        #endregion


    }
}
