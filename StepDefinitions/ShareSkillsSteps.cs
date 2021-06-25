using NUnit.Framework;
using SkillSwapSpecflow.Pages;
using SkillSwapSpecflow.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SkillSwapSpecflow.StepDefinitions
{
    [Binding]
    public class ShareSkillsSteps : CommonDriver
    {
        [Given(@"I sign into SkillSwap with (.*), (.*) as Email, (.*) as Password")]
        public void GivenISignIntoSkillSwapWithAsEmailAsPassword(string credentialType, string email, string pswrd)
        {
            // Create an instance for SignUp page 
            SignUp SignInObj = new SignUp(driver);

            SignInObj.ClickSignIn();

            SignInObj.LoginSteps(email, pswrd);

            SignInObj.ClickLogin();

            SignInObj.ValidatedLogin(credentialType);
        }

        [Given(@"I am able to view my home page and Click on Share SKill button")]
        public void GivenIAmAbleToViewMyHomePageAndClickOnShareSKillButton()
        {
            //Create an instance for Home page
            HomePage homePgObj = new HomePage(driver);

            homePgObj.ValidateHomePage();

            homePgObj.navigateToShareSkill();

        }

        [When(@"I fill the details of the service (.*) and Click Save")]
        public void WhenIFillTheDetailsOfTheServiceAndClickSave(string ServiceTitle)
        {
            int rownumber = ServiceData.GetRownNum(ServiceTitle);
            if (rownumber == 0)
                Assert.Fail("The details of the service doesn't exist");
            else
            {
                //Create an instance for the ShareSkillPage
                ShareSkillPage Obj = new ShareSkillPage(driver, rownumber);

                Obj.FillDetailsOfServiceProvided();
            }
        }

        [When(@"I navigate to the Manage Listings to view the service (.*)")]
        public void WhenINavigateToTheManageListingsToViewTheService(string ServiceTitle)
        {
            int rownumber = ServiceData.GetRownNum(ServiceTitle);
            if (rownumber == 0)
                Assert.Fail("The details of the service doesn't exist");
            else
            {
                //Create an instance for the Listing Management page
                ListingManagement listObj = new ListingManagement(driver, rownumber);

                //Invoke the funtion to navigate to Manage Listings
                listObj.ManageListing();

                listObj.ViewListings();
            }
        }

        [Then(@"I should be able to view the (.*) listed with the same details as provided")]
        public void ThenIShouldBeAbleToViewTheListedWithTheSameDetailsAsProvided(string ServiceTitle)
        {
            int rownumber = ServiceData.GetRownNum(ServiceTitle);
            if (rownumber == 0)
                Assert.Fail("The details of the service doesn't exist");
            else
            {
                //Create an instance for the Listing Management page
                ListingManagement listObj = new ListingManagement(driver, rownumber);

                //Invoke the funtion to navigate to Manage Listings
                listObj.NavigateToViewAddedDetails();

                //Create an instance for the Service Detail page
                ServiceDetail ViewDetailObj = new ServiceDetail(driver, rownumber);

                //Invoke the funtion to validate the details of services
                ViewDetailObj.ValidateServiceDetail();
            }
        }

        [Given(@"I navigate to the Manage Listings and edit the service (.*)")]
        public void GivenINavigateToTheManageListingsAndEditTheService(string ServiceTitle)
        {

            bool editMatchFound = false;

            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Invoke the funtion to navigate to Manage Listings
            listObj.navigateToManageListings();

            {
              //Create an instance for the Listing Management page
              ListingManagement obj = new ListingManagement(driver);

              //Invoke the function to check if the service to be edited is available in the Manage Listings
              editMatchFound = obj.NavigateToEditDetails(ServiceTitle);
              if (!editMatchFound)
                Assert.Fail("The service to be edited is not found in Manage Listings");
            }         
                     
        }

        [When(@"I update the details of the service (.*) and Click Save")]
        public void WhenIUpdateTheDetailsOfTheServiceAndClickSave(string ServiceTitle)
        {
            int rownumber = ServiceData.GetRownNumForEdit(ServiceTitle);
            if (rownumber == 0)
                Assert.Fail("The details for updating doesn't exist");
            else
            {
                //Create an instance for the Listing Management page
                ListingManagement obj = new ListingManagement(driver, rownumber);

                //Create instances for ServiceListing Page and SearchSkill Page 
                ServiceListing editObj = new ServiceListing(driver, rownumber);

                SearchSkill SrchObj = new SearchSkill(driver, rownumber);

                //Invoke the function to Edit services
                editObj.EditServices();

                //Implicit wait
                Wait.wait(2, driver);

                //Invoke the function to search for service after edit
                obj.SearchSkillsAfterEdit();

                //Invoke the function to validate the search result
                SrchObj.SkillSrchResult();                
            }
        
    }

        [Then(@"I should be able to view the updated (.*) in the Manage Listings")]
        public void ThenIShouldBeAbleToViewTheUpdatedInTheManageListings(string ServiceTitle)
        {
            int rownumber = ServiceData.GetRownNumForEdit(ServiceTitle);
            if (rownumber == 0)
                Assert.Fail("The details for updating doesn't exist");
            else
            {
                //Create an instance for ServiceDetail Page
                ServiceDetail ViewEditdDetailObj = new ServiceDetail(driver, rownumber);

                //Invoke the function to validate the edited details
                ViewEditdDetailObj.ValidateServiceDetail();

            }
        }

        [Given(@"I navigate to the Manage Listings")]
        public void GivenINavigateToTheManageListings()
        {
            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Invoke the funtion to navigate to Manage Listings
            listObj.navigateToManageListings();

            //Implicit wait
            Wait.wait(2, driver);
        }


        [When(@"I choose to delete the service (.*)")]
        public void WhenIChooseToDeleteTheService(string ServiceTitle)
        {
            //Create an instance for ListingManagement
            ListingManagement DeletelistObj = new ListingManagement(driver, ServiceTitle);

            //Invoke Delete Operation
            DeletelistObj.DeleteDetails();
        }

        [Then(@"the service (.*) should no longer exist in the listings")]
        public void ThenTheServiceShouldNoLongerExistInTheListings(string ServiceTitle)
        {
            //Create an instance for ListingManagement
            ListingManagement DeletelistObj = new ListingManagement(driver, ServiceTitle);

            //Invoke a function to search for the service after deletion
            DeletelistObj.SearchSkillsAfterDelete();

            SearchSkill SrchObj = new SearchSkill(driver);

            //Invoke a function for search
            SrchObj.SrchResultAfterDel();
        }



    }
}
