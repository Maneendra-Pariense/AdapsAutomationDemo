namespace AutomationNunit.Pages
{
    public class FramesPage: BasePage
    {
        //locators
        IWebElement multiple => _driver.FindElement(By.XPath("//a[@href='#Multiple']"));
        IWebElement iframeTitle => _driver.FindElement(By.TagName("h5"));
        IWebElement firstIframe => _driver.FindElement(By.XPath("//div[@id = 'Multiple']/iframe"));
        IWebElement secondIframe => _driver.FindElement(By.XPath("//iframe"));

        //methods

        public void SingleIFrame()
        {
            _driver.SwitchTo().Frame("singleframe");

            var title = iframeTitle.Text;
            Console.WriteLine(title);
            _driver.SwitchTo().DefaultContent();
        }

        public void MultipleIFrame()
        {
            multiple.Click();
            _driver.SwitchTo().Frame(firstIframe);
            var title = iframeTitle.Text;
            Console.WriteLine(title);

            _driver.SwitchTo().Frame(secondIframe);
            var title1 = iframeTitle.Text;
            Console.WriteLine(title1);

            _driver.SwitchTo().DefaultContent();
        }


    }
}
