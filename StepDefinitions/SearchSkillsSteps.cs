using SkillSwapSpecflow.Pages;
using SkillSwapSpecflow.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SkillSwapSpecflow.StepDefinitions
{
    [Binding]
    public class SearchSkillsSteps: CommonDriver
    {
        [Given(@"I log into SkillSwap with (.*), (.*) as Email, (.*) as Password")]
        public void GivenILogIntoSkillSwapWithAsEmailAsPassword(string credentialType, string email, string pswrd)
        {
            //Create an instance for SignUp page 
            SignUp SignInObj = new SignUp(driver);

            SignInObj.ClickSignIn();

            SignInObj.LoginSteps(email, pswrd);

            SignInObj.ClickLogin();

            SignInObj.ValidatedLogin(credentialType);
        }
        
        [Given(@"I successfully navigate to my home page")]
        public void GivenISuccessfullyNavigateToMyHomePage()
        {
            //Create an instance for Home page
            HomePage homePgObj = new HomePage(driver);

            homePgObj.ValidateHomePage();
        }
        
        [When(@"I search for the (.*) using Search feature available in Home Page")]
        public void WhenISearchForTheUsingSearchFeatureAvailableInHomePage(string TitleForServcToBeSearched)
        {
            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Search for the required service from the home page
            listObj.SearchSkillFromHomePage(TitleForServcToBeSearched);
        }       
        

        [When(@"I apply filter for location type as (.*) on the search results")]
        public void WhenIApplyFilterForLocationTypeAsOnTheSearchResults(string LocationType)
        {
            SearchSkill SrchObj = new SearchSkill(driver);
            SrchObj.ApplyFilterOnSkills(LocationType);
        }

        [Then(@"I should be able to view only results for (.*) with location Type as (.*)")]
        public void ThenIShouldBeAbleToViewOnlyResultsForWithLocationTypeAs(string Skill, string LocationType)
        {
            SearchSkill SrchObj = new SearchSkill(driver);
            SrchObj.ValidateSkills(LocationType, Skill);
        }
                
        [When(@"I search for user as (.*) using Search feature")]
        public void WhenISearchForUserAsUsingSearchFeature(string user)
        {
            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Search for the required service from the home page
            listObj.NavigateToSearchSkill();

            //Create an object for SearchSkill page 
            SearchSkill SrchObj = new SearchSkill(driver);
            SrchObj.SearchUsername(user);
        }


        [When(@"I apply filter for location type as (.*) on the search results with username")]
        public void WhenIApplyFilterForLocationTypeAsOnTheSearchResultsWithUsername(string LocationType)
        {
            //Create an object for SearchSkill page 
            SearchSkill SrchObj = new SearchSkill(driver);

            SrchObj.FilterSkillsOfParticularUser(LocationType);
        }

        [Then(@"I should be able to view results for the skills listed by the (.*) with location Type as (.*)")]
        public void ThenIShouldBeAbleToViewResultsForTheSkillsListedByTheWithLocationTypeAs(string user, string LocationType)
        {
            //Create an object for SearchSkill page 
            SearchSkill SrchObj = new SearchSkill(driver);

            SrchObj.ValidateSkillsOfParticularUser(LocationType, user);
        }

    }
}
