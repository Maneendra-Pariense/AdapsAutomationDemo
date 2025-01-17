using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationNunit.Pages
{
    public class BasePage
    {
        [ThreadStatic] public static IWebDriver _driver;
        public static string browserName;
        public static string baseDir = Directory.GetCurrentDirectory();
        public static string testResultDir = baseDir.Replace("bin\\Debug\\net6.0", "TestResults\\");
        public static string screenshotsDir = baseDir.Replace("bin\\Debug\\net6.0", "TestResults\\Screenshots\\");

        public void Setup()
        {
            string browser = browserName ?? "chrome";

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

        public void TearDown()
        {
            Thread.Sleep(2000);
            _driver.Quit();
            _driver.Dispose();
        }

        public void TakeScreenshot()
        {
            var screenshotPath = screenshotsDir + $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss.fffff}.png";
            _driver.TakeScreenshot().SaveAsFile(screenshotPath);
            TestContext.AddTestAttachment(screenshotPath);
        }
    }
}
