using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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
            _driver.Manage().Window.Maximize();
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
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

        public IWebElement FluentWaitForElement(string target_xpath)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            /* Explicit Wait */
            /*IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(target_xpath))); */
            return fluentWait.Until(x => x.FindElement(By.XPath(target_xpath)));
            
        }

        public IWebElement ExplicitWaitForElement(string target_xpath, int timeout) 
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));

            /* Explicit Wait */

            
            return wait.Until(ExpectedConditions.ElementExists(By.XPath(target_xpath)));

        }
        public IWebElement ExplicitWaitForElement(By target_xpath)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            /* Explicit Wait */

            return wait.Until(ExpectedConditions.ElementExists(target_xpath));

        }
    }
}
