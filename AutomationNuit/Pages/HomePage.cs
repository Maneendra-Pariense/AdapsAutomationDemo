namespace AutomationNunit.Pages
{
    public class HomePage: BasePage
    {

        // locators
        #region Locators

        IWebElement mainMenuElement(string mm) => _driver.FindElement(By.XPath($"//ul[@class = 'nav navbar-nav']/li/a[text()='{mm}']"));

        IWebElement subMenuElement(string mm, string sm) => _driver.FindElement(By.XPath($"//ul[@class = 'nav navbar-nav']/li/a[text()='{mm}']/..//li/a[text() = '{sm}']"));
        
        #endregion


        // methods
        #region Methods

        // create a method named NavigateTo which takes 2 arguments, 1 Main menu Item, 2nd subMenu Item

        public void NavigateTo(string mainMenu, string? subMenu = null) {

            mainMenuElement(mainMenu).Click();            

            if (!string.IsNullOrWhiteSpace(subMenu))
            {
                subMenuElement(mainMenu, subMenu).Click();
            }
        
        }


        #endregion
    }
}
