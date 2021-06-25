using SkillSwapSpecflow.Pages;
using SkillSwapSpecflow.Utilities;
using TechTalk.SpecFlow;

namespace SkillSwapSpecflow.StepDefinitions
{
    [Binding]
    public class SignInSteps: CommonDriver
    {
        [Given(@"I am an existing user and I click on Sign In")]
        public void GivenIAmAnExistingUserAndIClickOnSignIn()
        {
            //Create an instance for SignUp page
            SignUp JoinObj = new SignUp(driver);

            JoinObj.ClickSignIn();
        }

        [Given(@"I enter credentials for (.*), (.*)")]
        public void GivenIEnterCredentialsFor(string EmailAddress, string Password)
        {
            //Create an instance for SignUp page
            SignUp JoinObj = new SignUp(driver);

            JoinObj.LoginSteps(EmailAddress, Password);
        }                

        [When(@"I click on Login")]
        public void WhenIClickOnLogin()
        {
            //Create an instance for SignUp page 
            SignUp JoinObj = new SignUp(driver);

            JoinObj.ClickLogin();
        }

        [Then(@"I should not be logged in successfully with (.*)")]
        public void ThenIShouldNotBeLoggedInSuccessfullyWith(string InvalidCredentialType)
        {
            //Create an instance for SignUp page 
            SignUp JoinObj = new SignUp(driver);

            JoinObj.ValidatedLogin(InvalidCredentialType);
        }               

        [Then(@"I should logged in successfully with (.*)")]
        public void ThenIShouldLoggedInSuccessfullyWith(string CredentialType)
        {
            //Create an instance for SignUp page 
            SignUp JoinObj = new SignUp(driver);

            JoinObj.ValidatedLogin(CredentialType);

            //Create an instance for Home page
            HomePage homeObj = new HomePage(driver);

            homeObj.ValidateHomePage();
        }


    }
}
