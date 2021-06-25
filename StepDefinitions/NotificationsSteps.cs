using SkillSwapSpecflow.Pages;
using SkillSwapSpecflow.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SkillSwapSpecflow.StepDefinitions
{
    [Binding]
    public class NotificationsSteps: CommonDriver
    {
        [Given(@"As an existing user I sign into SkillSwap with (.*), (.*), (.*)")]
        public void GivenAsAnExistingUserISignIntoSkillSwapWith(string credentialType, string email, string pswrd)
        {
            //Create an instance for SignUp page 
            SignUp SignInObj = new SignUp(driver);

            SignInObj.ClickSignIn();

            SignInObj.LoginSteps(email, pswrd);

            SignInObj.ClickLogin();

            SignInObj.ValidatedLogin(credentialType);
        }
        
        [Given(@"I click on notifications tab in Homepage")]
        public void GivenIClickOnNotificationsTabInHomepage()
        {
            //Create an instance for Home page
            HomePage homePgObj = new HomePage(driver);

            homePgObj.ValidateHomePage();
        }
        
        [Given(@"I click on See all notifications and Navigate to notifications Dashboard")]
        public void GivenIClickOnSeeAllNotificationsAndNavigateToNotificationsDashboard()
        {
            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Invoke function to see all notifications
            listObj.SeeAllNotifications();
        }
        
        [When(@"I select the latest (.*) notifications and click on Delete selection")]
        public void WhenISelectTheLatestNotificationsAndClickOnDeleteSelection(int Count)
        {
            //Create an instance for the HomePage
            Dashboard obj = new Dashboard(driver);

            obj.SelectNotifications(Count);
        }
        
        [Then(@"The selected notifications should be deleted")]
        public void ThenTheSelectedNotificationsShouldBeDeleted()
        {
            //Create an instance for the HomePage
            Dashboard obj = new Dashboard(driver);

            obj.DeleteSelectedNotifications();
        }

        [When(@"I click on the respective checkboxes of (.*) notifications")]
        public void WhenIClickOnTheRespectiveCheckboxesOfNotifications(int count)
        {
            //Create an instance for the HomePage
            Dashboard obj = new Dashboard(driver);

            //Invoke the function to select the notifications
            obj.SelectNotifications(count);
        }

        [Then(@"(.*) notifications should appear as selected")]
        public void ThenNotificationsShouldAppearAsSelected(int count)
        {
            //Create an instance for the HomePage
            Dashboard obj = new Dashboard(driver);

            //Invoke function to check selected notifications
            obj.CheckSelectNotifications(count);
        }

        [Then(@"(.*) notifications should appear as unselected when clicked again")]
        public void ThenNotificationsShouldAppearAsUnselectedWhenClickedAgain(int count)
        {
            //Create an instance for the HomePage
            Dashboard obj = new Dashboard(driver);

            obj.UncheckSelectNotifications(count);
        }      


        [When(@"I click on Select all notifications")]
        public void WhenIClickOnSelectAllNotifications()
        {
            //Create an instance for the HomePage
            Dashboard obj = new Dashboard(driver);

            obj.SelectAllNotifications();
        }

        [Then(@"all notifications should appear as unhighlighted")]
        public void ThenAllNotificationsShouldAppearAsUnhighlighted()
        {
            //Create an instance for the HomePage
            Dashboard obj = new Dashboard(driver);

            obj.ValidateAllNotificationsRead();
        }


    }
}
