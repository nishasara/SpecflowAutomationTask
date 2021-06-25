using SkillSwapSpecflow.Pages;
using SkillSwapSpecflow.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SkillSwapSpecflow.StepDefinitions
{
    [Binding]
    public class DeleteProfDetailsSteps: CommonDriver
    {
        [Given(@"I have signed in with (.*), (.*) as Email, (.*) as Password")]
        public void GivenIHaveSignedInWithAsEmailAsPassword(string credentialType, string email, string pswrd)
        {
            //Create an instance for SignUp page
            SignUp SignInObj = new SignUp(driver);

            SignInObj.ClickSignIn();

            SignInObj.LoginSteps(email, pswrd);

            SignInObj.ClickLogin();

            SignInObj.ValidatedLogin(credentialType);
        }
        
        [Given(@"I am able to view the home page")]
        public void GivenIAmAbleToViewTheHomePage()
        {
            //Create an instance for Home page
            HomePage homePgObj = new HomePage(driver);

            homePgObj.ValidateHomePage();
        }
        
        [When(@"I click on Profile, click Languages tab and click delete button")]
        public void WhenIClickOnProfileClickLanguagesTabAndClickDeleteButton()
        {
            HomePage homePgObj = new HomePage(driver);
            homePgObj.navigateToProfile();
            homePgObj.goToLanguageTab();
        }
        
        [Then(@"I should be able to delete the last entry of Languages")]
        public void ThenIShouldBeAbleToDeleteTheLastEntryOfLanguages()
        {

            HomePage deleteDetailsObj = new HomePage(driver);
            deleteDetailsObj.DeleteLanguages();
           
        }
    }
}
