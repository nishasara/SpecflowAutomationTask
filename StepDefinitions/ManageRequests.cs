using SkillSwapSpecflow.Pages;
using SkillSwapSpecflow.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SkillSwapSpecflow.StepDefinitions
{
    [Binding]
    public class ManageRequestForSentRequestsSteps: CommonDriver
    {
        private string[] reqstDetails = new string[4];

        [Given(@"The Seller has logged in to SkillSwap with (.*), email as (.*), password as (.*)")]
        public void GivenTheSellerHasLoggedInToSkillSwapWithEmailAsPasswordAs(string credentialType, string email, string pswrd)
        {
            // Create an instance for SignUp page 
            SignUp SignInObj = new SignUp(driver);

            SignInObj.ClickSignIn();

            SignInObj.LoginSteps(email, pswrd);

            SignInObj.ClickLogin();

            SignInObj.ValidatedLogin(credentialType);

            //Create an instance for Home page
            HomePage homePgObj = new HomePage(driver);

            homePgObj.ValidateHomePage();
        }

        [Given(@"Seller has sent out a request for a Service (.*) to other Seller")]
        public void GivenSellerHasSentOutARequestForAServiceToOtherSeller(string serviceTitle)
        {            
            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Search Skills from Home Page
            SkillObj.SearchSkillFromHomePage(serviceTitle);

            //Create an instance for Search Skill Page
            SearchSkill srchObj = new SearchSkill(driver);

            srchObj.SearchResult(serviceTitle);
        }

        [When(@"the Seller Clicks on Sent Requests in Manage Requests")]
        public void WhenTheSellerClicksOnSentRequestsInManageRequests()
        {        

            ServiceDetail detailObj = new ServiceDetail(driver);

            //Get the details of the request raised
            detailObj.SentRequestToSeller();                       

            reqstDetails = detailObj.GetDetailsOfSeller();

            //Get the details of the request raised
            detailObj.ClickManageRqst();


        }

        [Then(@"Seller should be able to view the details of Sent Requests")]
        public void ThenSellerShouldBeAbleToViewTheDetailsOfSentRequests()
        {           

            SentRequest rqstObj = new SentRequest(driver);

            //Validate the sent Request
            rqstObj.CheckSentRequests(reqstDetails);
        }

    }
}
