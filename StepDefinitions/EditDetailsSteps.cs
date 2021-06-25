using SkillSwapSpecflow.Pages;
using SkillSwapSpecflow.Utilities;
using TechTalk.SpecFlow;

namespace SkillSwapSpecflow.StepDefinitions
{
    [Binding]
    public class EditProfDetailsSteps:CommonDriver
    {
        [Given(@"I Sign into SkillSwap with (.*), (.*) as Email, (.*) as Password")]
        public void GivenISignIntoSkillSwapWithAsEmailAsPassword(string credentialType, string email, string pswrd)
        {
            //Create an instance for SignUp page
            SignUp SignInObj = new SignUp(driver);

            SignInObj.ClickSignIn();

            SignInObj.LoginSteps(email, pswrd);

            SignInObj.ClickLogin();

            SignInObj.ValidatedLogin(credentialType);
        }

        [Given(@"I am able to view my home page")]
        public void GivenIAmAbleToViewMyHomePage()
        {
            //Create an instance for Home page
            HomePage homePgObj = new HomePage(driver);

            homePgObj.ValidateHomePage();
        }


        [When(@"I click on my Profile, go to Languages tab and click edit button")]
        public void WhenIClickOnMyProfileGoToLanguagesTabAndClickEditButton()
        {
            HomePage homePgObj = new HomePage(driver);
            homePgObj.navigateToProfile();
            homePgObj.goToLanguageTab();
        }
        
        [Then(@"I should be able to update details of last row of existing languages")]
        public void ThenIShouldBeAbleToUpdateDetailsOfLastRowOfExistingLanguages()
        {
            HomePage editDetailsObj = new HomePage(driver);
            editDetailsObj.editLanguages();
        }
    }
}
