using SkillSwapSpecflow.Utilities;
using SkillSwapSpecflow.Pages;
using TechTalk.SpecFlow;

namespace SkillSwapSpecflow.StepDefinitions
{
    [Binding]
    public class AddProfileDetailsSteps: CommonDriver
    {
        [Given(@"I have Signed into SkillSwap with (.*), (.*), (.*)")]
        public void GivenIHaveSignedIntoSkillSwapWith(string credentialType, string email, string pswrd)
        {
            //Create an instance for SignUp page
            SignUp SignInObj = new SignUp(driver);

            SignInObj.ClickSignIn();

            SignInObj.LoginSteps(email, pswrd);

            SignInObj.ClickLogin();

            SignInObj.ValidatedLogin(credentialType);
        }
        
        [Given(@"I am able to view my homepage")]
        public void GivenIAmAbleToViewMyHomepage()
        {
            //Create an instance for Home page
            HomePage homePgObj = new HomePage(driver);

            homePgObj.ValidateHomePage();
        }
        
        [When(@"I click on Profile")]
        public void WhenIClickOnProfile()
        {
            //Create an instance for Home page
            HomePage addDetailsObj = new HomePage(driver);
            addDetailsObj.navigateToProfile();
        }
        
        [Then(@"I should be able to add details in profile like Availability, Hours, Earn Target in my profile")]
        public void ThenIShouldBeAbleToAddDetailsInProfileLikeAvailabilityHoursEarnTargetInMyProfile()
        {
            //Create an instance for Home page
            HomePage addDetailsObj = new HomePage(driver);
            addDetailsObj.addDetails();
        }

        [When(@"I click on Profile and click description")]
        public void WhenIClickOnProfileAndClickDescription()
        {
            //Create an instance for Home page
            HomePage addDescObj = new HomePage(driver);
            addDescObj.navigateToProfile();

            addDescObj.ClickDescription();
        }


        [Then(@"I should be able to add description in my profile")]
        public void ThenIShouldBeAbleToAddDescriptionInMyProfile()
        {
            //Create an instance for Home page
            HomePage addDescObj = new HomePage(driver);
            addDescObj.AddDescription();
        }

        [When(@"I click on Profile and click languages")]
        public void WhenIClickOnProfileAndClickLanguages()
        {
            //Create an instance for Home page
            HomePage addLang = new HomePage(driver);
            addLang.navigateToProfile();

            addLang.goToLanguageTab();
        }

        [Then(@"I should be able to add details of languages known and save it")]
        public void ThenIShouldBeAbleToAddDetailsOfLanguagesKnownAndSaveIt()
        {
            //Create an instance for Home page
            HomePage addLang = new HomePage(driver);

            addLang.addLanguages();
        }

        [When(@"I click on Profile and click Skills")]
        public void WhenIClickOnProfileAndClickSkills()
        {
            //Create an instance for Home page
            HomePage addSkills = new HomePage(driver);

            addSkills.goToSkillsTab();

        }

        [Then(@"I should be able to add details of Skills and save it")]
        public void ThenIShouldBeAbleToAddDetailsOfSkillsAndSaveIt()
        {
            //Create an instance for Home page
            HomePage addSkills = new HomePage(driver);

            addSkills.addSkills();
        }

        [When(@"I click on Profile and click education")]
        public void WhenIClickOnProfileAndClickEducation()
        {
            //Create an instance for Home page
            HomePage educationObj = new HomePage(driver);

            educationObj.goToEducationTab();
        }

        [Then(@"I should be able to add details of Education and save it")]
        public void ThenIShouldBeAbleToAddDetailsOfEducationAndSaveIt()
        {
            //Create an instance for Home page
            HomePage educationObj = new HomePage(driver);

            educationObj.addEducation();
        }

        [When(@"I click on Profile and click Certifications")]
        public void WhenIClickOnProfileAndClickCertifications()
        {
            HomePage certificationObj = new HomePage(driver);
            certificationObj.goToCertificationTab();
           
        }

        [Then(@"I should be able to add details of certification and save it")]
        public void ThenIShouldBeAbleToAddDetailsOfCertificationAndSaveIt()
        {
            HomePage addCertificationObj = new HomePage(driver);
            addCertificationObj.addCertifications();
        }

        [When(@"I click on Profile, click Certifications and add two similar details")]
        public void WhenIClickOnProfileClickCertificationsAndAddTwoSimilarDetails()
        {
            HomePage certSimilarEntryObj = new HomePage(driver);

            certSimilarEntryObj.goToCertificationTab();
        }

        [Then(@"I should not be allowed to add (.*) similar entries showing a pop up")]
        public void ThenIShouldNotBeAllowedToAddSimilarEntriesShowingAPopUp(int p0)
        {

            HomePage similarEntryObj = new HomePage(driver);

            similarEntryObj.checkDuplicateEntries();
        }


    }
}
