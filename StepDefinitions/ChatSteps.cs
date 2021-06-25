using SkillSwapSpecflow.Pages;
using SkillSwapSpecflow.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SkillSwapSpecflow.StepDefinitions
{
    [Binding]
    public class ChatSteps:CommonDriver
    {
        private string Sellername;

        private string[] ChatDetails = new string[4];

        [Given(@"As SellerOne I log into the SkillSwap module with (.*), (.*) as email, (.*) as Password")]
        public void GivenAsSellerOneILogIntoTheSkillSwapModuleWithAsEmailAsPassword(string credentialType, string email, string pswrd)
        {
            //Create an instance for SignUp page 
            SignUp SignInObj = new SignUp(driver);

            SignInObj.ClickSignIn();

            SignInObj.LoginSteps(email, pswrd);

            SignInObj.ClickLogin();

            SignInObj.ValidatedLogin(credentialType);

            //Wait until the Mars Logo in the HomePage is visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/a");
        }
        
        [Given(@"I search for service (.*) that I would like to avail")]
        public void GivenISearchForServiceThatIWouldLikeToAvail(string servicename)
        {
            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            SkillObj.navigateToProfile();

            Sellername = SkillObj.GetSellerName();

            //Search Skills from Home Page
            SkillObj.SearchSkillFromHomePage(servicename);

            //Create an instance for Search Skill Page
            SearchSkill srchObj = new SearchSkill(driver);

            //Invoke the function to search for the skill
            srchObj.SearchResult(servicename);
        }
        
        [Given(@"I navigate to the SellerTwo's page to access the Chat feature")]
        public void GivenINavigateToTheSellerTwoSPageToAccessTheChatFeature()
        {
            ServiceDetail detailObj = new ServiceDetail(driver);

            detailObj.NavigateToChat();
        }
        
        [Given(@"I send chat messages to SellerTwo")]
        public void GivenISendChatMessagesToSellerTwo()
        {
            Message chatObj = new Message(driver);            

            ChatDetails = chatObj.ChatWithSeller();
        }
        
        [When(@"SellerTwo log into the SkillSwap module with (.*), (.*) as email, (.*) as Password")]
        public void WhenSellerTwoLogIntoTheSkillSwapModuleWithAsEmailAsPassword(string credentialType, string email, string pswrd)
        {
            //Create an instance for SignUp page 
            SignUp SignInObj = new SignUp(driver);

            SignInObj.ClickSignIn();

            SignInObj.LoginSteps(email, pswrd);

            SignInObj.ClickLogin();

            SignInObj.ValidatedLogin(credentialType);

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            SkillObj.ValidateHomePage();

        }
        
        [When(@"SellerTwo views Chat notifications and navigate to the Chat module")]
        public void WhenSellerTwoViewsChatNotificationsAndNavigateToTheChatModule()
        {
           //Create an instance for the HomePage
           HomePage SkillObj = new HomePage(driver);

           SkillObj.navigateToChat();
        }

        [Then(@"SellerTwo should be able to view SellerOne chat messages with time stamp details")]
        public void ThenSellerTwoShouldBeAbleToViewSellerOneChatMessagesWithTimeStampDetails()
        {
           Message chatObj = new Message(driver);

           chatObj.CheckNewChatMessages(Sellername, ChatDetails);
        }

        
    }
}
