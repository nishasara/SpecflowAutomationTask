using SkillSwapSpecflow.Pages;
using SkillSwapSpecflow.Utilities;
using TechTalk.SpecFlow;

namespace SkillSwapSpecflow.StepDefinitions
{
    [Binding]
    public class ChangePasswordSteps: CommonDriver
    {
        [Given(@"I Sign In with (.*), (.*), (.*)")]
        public void GivenISignInWith(string ValidCredential, string EmailAddress, string Password)
        {
            //Create an instance for SignUp page
            SignUp JoinObj = new SignUp(driver);

            //Invoke the function for clicking Sign In
            JoinObj.ClickSignIn();

            JoinObj.LoginSteps(EmailAddress, Password);

            JoinObj.ClickLogin();

            JoinObj.ValidatedLogin(ValidCredential);
        }                    
        
        [Given(@"I Choose Change Password option in Profile")]
        public void GivenIChooseChangePasswordOptionInProfile()
        {
            //Create an instance for Home page
            HomePage homeObj = new HomePage(driver);

            homeObj.GoToChangePassword();
        }
        
        [When(@"I enter (.*), (.*), (.*)")]
        public void WhenIEnter(string currentpassword, string newpassword, string confirmpassword)
        {
            //Create an instance for Home page
            HomePage homeObj = new HomePage(driver);

            homeObj.DetailsForChangePassword(currentpassword,newpassword,confirmpassword);
        }
        
        [When(@"I Click on Save button")]
        public void WhenIClickOnSaveButton()
        {
            //Create an instance for Home page
            HomePage homeObj = new HomePage(driver);

            homeObj.ClickSaveForChangePswrd();
        }

        [Then(@"I should be able to login with (.*), (.*)")]
        public void ThenIShouldBeAbleToLoginWith(string EmailAddress, string newpassword)
        {
            //Create an instance for SignUp page
            SignUp SignInObj = new SignUp(driver);

            SignInObj.LoginStepsAfterChangePassword(EmailAddress, newpassword);

            //Create an instance for Home page
            HomePage homeObj = new HomePage(driver);

            homeObj.ValidateHomePage();         
        }
    }
}
