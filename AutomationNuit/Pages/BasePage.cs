using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationNunit.Pages
{
    public class BasePage
    {
        public static IWebDriver _driver;

        public void Setup()
        {
            string browser = "chrome";

            switch (browser.ToLower())
            {
                case "chrome":
                    _driver = InitializeChromeBrowser();
                    break;
                case "edge":
                    _driver = InitializeEdgeBrowser();
                    break;
                case "firefox":
                    _driver =InitializeFirefoxBrowser();
                    break;

            }
            Console.WriteLine("setup method");
            GoToUrl();
        }

        private void GoToUrl()
        {
            _driver.Navigate().GoToUrl("https://demo.automationtesting.in/");
        }

        private IWebDriver InitializeFirefoxBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }

        private IWebDriver InitializeEdgeBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            return new EdgeDriver();
        }

        private IWebDriver InitializeChromeBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }
    }
}
