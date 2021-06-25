using SkillSwapSpecflow.Pages;
using SkillSwapSpecflow.Utilities;
using TechTalk.SpecFlow;

namespace SkillSwapSpecflow.StepDefinitions
{
    [Binding]
    public class RegistrationSteps: CommonDriver
    {
        [Given(@"I am a newuser and I click on Join")]
        public void GivenIAmANewuserAndIClickOnJoin()
        {
            //Create an instance for SignUp page
            SignUp JoinObj = new SignUp(driver);

            //Invoke the function for clicking Join
            JoinObj.ClickJoin();
        }
               
        [Given(@"I enter the details (.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterTheDetails(string firstname, string lastname, string email, string password, string confirmpassword)
        {
            //Create an instance for SignUp page
            SignUp JoinObj = new SignUp(driver);

            //Invoke the function for accepting the registration details
            JoinObj.RegisterDetails(firstname,lastname,email,password,confirmpassword);
        }

        [Given(@"I agree to the terms and conditions")]
        public void GivenIAgreeToTheTermsAndConditions()
        {
            //Create an instance for SignUp page
            SignUp JoinObj = new SignUp(driver);

            //Invoke the function for accepting the terms and conditions
            JoinObj.CheckTermsConditions();
        }

        [When(@"I click on Join")]
        public void WhenIClickOnJoin()
        {
            //Create an instance for SignUp page 
            SignUp JoinObj = new SignUp(driver);

            //Invoke the function for submitting details by clicking join button
            JoinObj.ClickJoinButton();
        }

        [Then(@"I should be registered successfully as (.*)")]
        public void ThenIShouldBeRegisteredSuccessfullyAs(bool newuser)
        {
            //Create an instance for SignUp page 
            SignUp JoinObj = new SignUp(driver);

            //Invoke the function for validating the registration
            JoinObj.ValidateRegistration(newuser);
        }

        [Given(@"I am an existing user and I click on Join")]
        public void GivenIAmAnExistingUserAndIClickOnJoin()
        {
            //Create an instance for SignUp page
            SignUp JoinObj = new SignUp(driver);

            //Invoke the function for clicking Join
            JoinObj.ClickJoin();
        }

        [Then(@"I should not be allowed to register successfully as (.*)")]
        public void ThenIShouldNotBeAllowedToRegisterSuccessfullyAs(bool newuser)
        {
            //Create an instance for SignUp page 
            SignUp JoinObj = new SignUp(driver);

            //Invoke the function for validating the registration
            JoinObj.ValidateRegistration(newuser);
        }



    }
}
