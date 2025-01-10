using AutomationNunit.Pages;

namespace AutomationNunit.Tests
{
    public class WindowsTests: BasePage
    {
        HomePage homePage;
        LoginPage loginPage;
        WindowsPage windowsPage;
        
        public WindowsTests() {
            homePage = new HomePage();
            loginPage = new LoginPage();
            windowsPage = new WindowsPage();
           
        }

        [SetUp]
        public void OneTimeSetup(){ Setup(); }

        [Test]
        public void WindowsTabbedTestValidation()
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("SwitchTo", "Windows");
            windowsPage.ClickOnTab("#Tabbed");
            windowsPage.GetWindowHandleCount();
            var parentWindowName =  windowsPage.GetCurrentWindowName();
            Assert.That(windowsPage.GetWindowHandleCount(), Is.EqualTo(1));
            windowsPage.GetWindowTitle();
            windowsPage.ClickOnClickButton("Tabbed");
            Assert.That(windowsPage.GetWindowHandleCount(), Is.EqualTo(2));
            windowsPage.SwitchToWindow();
            windowsPage.GetWindowTitle();
            windowsPage.SwitchToWindow(parentWindowName);
            windowsPage.GetWindowTitle();




        }

        [Test]
        public void WindowsSeperateTestValidation()
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("SwitchTo", "Windows");           
            windowsPage.ClickOnTab("#Seperate");
            windowsPage.ClickOnClickButton("Seperate");



        }

        [Test]
        public void WindowsMultipleTestValidation()
        {
            loginPage.ClickOnSkipSignInButton();
            homePage.NavigateTo("SwitchTo", "Windows");            
            windowsPage.ClickOnTab("#Multiple");
            windowsPage.ClickOnClickButton("Multiple");


        }

        [TearDown]
        public void Teardown()
        {
            Thread.Sleep(5000);
            _driver.Quit();
        }
    }
}
