using AutomationNunit.Pages;

namespace AutomationNunit.Tests
{    
    [TestFixture]
    public class RegisterPageTest: Hooks.Hooks
    {
        public LoginPage loginPage;
        public RegisterPage registerPage;

        public RegisterPageTest() { 
            loginPage = new LoginPage();
            registerPage = new RegisterPage();
        }

        
        [Test]
        public void AddRegistration()
        {
            loginPage.ClickOnSkipSignInButton();
            var actualTitle = registerPage.GetRegisterPageTitle();
            Assert.That(actualTitle, Is.EqualTo("Register"));
            registerPage.EnterFirstName("Maneendra");
            registerPage.EnterLastName("BH");
            registerPage.EnterAddress("Address");
            registerPage.EnterEmail("123@gmail.com");
            registerPage.EnterPhone("1234567890");
            registerPage.SelectGender("Male");
            //registerPage.SelectHobby("Cricket");
            //registerPage.SelectHobby("Hockey");

            string[] hobbies = { "Hockey", "Cricket" };

            registerPage.SelectHobby(hobbies);
            //registerPage.SelectHobby1("Movies");

            registerPage.SelectSkill("Android");


            registerPage.SelectLanguages("Croatian");
            registerPage.SelectLanguages("Danish");

            Thread.Sleep(2000); 
            registerPage.DeSelectLanguages("Croatian");
            registerPage.SelectDateOfBirth("", "", "");





        }
    }
}
