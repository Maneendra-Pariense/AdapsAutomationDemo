

using WebDriverManager.Clients;

namespace AutomationNunit.Pages
{
    public class RegisterPage: BasePage
    {
        #region Locators
        IWebElement registerPageTitleElement => _driver.FindElement(By.TagName("h2"));
        IWebElement firstNameInput => _driver.FindElement(By.XPath("//input[@placeholder = 'First Name']"));

        IWebElement lastNameInput => _driver.FindElement(By.XPath("//input[@placeholder = 'Last Name']"));
        IWebElement addressTextArea => _driver.FindElement(By.XPath("//textarea[@ng-model = 'Adress']"));

        IWebElement email => _driver.FindElement(By.XPath("//input[@ng-model = 'EmailAdress']"));
        IWebElement phone => _driver.FindElement(By.XPath("//input[@ng-model = 'Phone']"));
        IWebElement maleRadio => _driver.FindElement(By.XPath("//input[@value = 'Male']"));

        IWebElement feMaleRadio => _driver.FindElement(By.XPath("//input[@value = 'FeMale']"));

        IWebElement genderRadio(string g) => _driver.FindElement(By.XPath($"//input[@value = '{g}']"));

        IWebElement hobbies(string hobby) => _driver.FindElement(By.XPath($"//label[text() = 'Hobbies']/../div//input[@value='{hobby}']"));

        List<IWebElement> hobbies1 => _driver.FindElements(By.XPath("//label[text() = 'Hobbies']/../div//input")).ToList();

        #endregion

        #region Methods

        public string GetRegisterPageTitle()
        {
            return registerPageTitleElement.Text;
        }

        public void EnterFirstName(string value)
        {
            firstNameInput.SendKeys(value);
        }

        public void EnterLastName(string value)
        {
            lastNameInput.SendKeys(value);
        }

        public void EnterAddress(string value)
        {
            addressTextArea.SendKeys(value);
        }

        public void EnterEmail(string value)
        {
            email.SendKeys(value);
        }

        public void EnterPhone(string value)
        {
            phone.SendKeys(value);
        }

        public void SelectGender(string gender)
        {
            //genderRadio(gender).Click();


            // 1
            if (gender == "Male")
            {
                maleRadio.Click();
            }
            else
            {
                feMaleRadio.Click();
            }

            //2

            //switch (gender)
            //{
            //    case "Male": maleRadio.Click(); break;
            //    case "Female": feMaleRadio.Click(); break;
            //}


        }

        public void SelectHobby(string hobby)
        {
            hobbies(hobby).Click();


        }

        public void SelectHobby1(string hobby)
        {
            foreach(IWebElement h in hobbies1)
            {
                var hobbyValue = h.GetAttribute("value");
                if (hobbyValue.Equals(hobby))
                {
                    h.Click();
                    break;

                }
                   
            }


        }

        public void SelectHobby(string[] hobby)
        {

            foreach(var h in hobby)
            {
                hobbies(h).Click();
            }
            


        }

        #endregion

    }
}
