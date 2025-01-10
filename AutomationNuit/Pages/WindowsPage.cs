
namespace AutomationNunit.Pages
{
    public class WindowsPage: BasePage
    {

        IWebElement clickButton(string btn) => _driver.FindElement(By.XPath($"//div[@id= '{btn}']//button"));
        By clickElementBy => By.XPath("");
        IWebElement tabs(string tabName) => _driver.FindElement(By.XPath($"//ul[@class = 'nav nav-tabs nav-stacked']//li/a[@href = '{tabName}']"));



        public void ClickOnTab(string tabName)
        {
            tabs(tabName).Click();            
        }
        public void ClickOnClickButton(string btn)
        {
            clickButton(btn).Click();
            Thread.Sleep(1000);
        }

        public void SwitchToWindow()
        {
            var handles = _driver.WindowHandles;
            var currentWindow = _driver.CurrentWindowHandle;

            foreach (var handle in handles)
            {
                
                if (currentWindow != handle)
                {
                    _driver.SwitchTo().Window(handle);
                    break;
                }
                    
            }

        }

        public void SwitchToWindow(string windowName)
        {
            var handles = _driver.WindowHandles;
            
            foreach (var handle in handles)
            {

                if (windowName == handle)
                {
                    _driver.SwitchTo().Window(handle);
                    break;
                }
                    
            }

        }

        public string GetCurrentWindowName()
        {
            Console.WriteLine(_driver.CurrentWindowHandle);
            return _driver.CurrentWindowHandle;
        }

        public int GetWindowHandleCount()
        {
            return _driver.WindowHandles.Count;
        }

        public string GetWindowTitle() {

            Console.WriteLine("title: " +  _driver.Title);
            return _driver.Title;
        }
        
    }
}
