using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SkillSwapSpecflow.Utilities;
using System;
using System.Threading;

namespace SkillSwapSpecflow.Pages
{

    class SignUp
    {
        //Declare the driver            
        IWebDriver driver;

        //Initialise the web elements
        public SignUp(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);          
        }

        //Identify join
        [FindsBy(How = How.XPath, Using = "//button[text()='Join']")]
        private IWebElement Join { get; set; }

        //Identify First Name
        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement FirstName { get; set; }

        //Identify Last Name
        [FindsBy(How = How.Name, Using = "lastName")]
        private IWebElement LastName { get; set; }

        //Identify Email address
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Identify Password
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Idenify Confirm Password
        [FindsBy(How = How.Name, Using = "confirmPassword")]
        private IWebElement CnfrmPswrd { get; set; }

        //Identify the checkbox for terms and conditions
        [FindsBy(How = How.XPath, Using = "//input[@name='terms']")]
        private IWebElement TermsCndtnsChkbox { get; set; }

        //Identify the Join button
        [FindsBy(How = How.XPath, Using = "//*[@id='submit-btn']")]
        private IWebElement JoinButton { get; set; }

        //Identify the registration success pop up
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement PopUp { get; set; }

        //Identify the email validation text
        [FindsBy(How = How.XPath, Using = "//div[text()='This email has already been used to register an account.']")]
        private IWebElement EmailValidation { get; set; }
        
        //Identify signIn
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/a")]
        private IWebElement signIn { get; set; }

        //Identify the Email textbox
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement email { get; set; }

        //Identify the Password textbox
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement pswrd { get; set; }

        //Identify the Login button and click
        [FindsBy(How = How.XPath, Using = "//button[text()='Login']")]
        private IWebElement login { get; set; }

        

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Password must be at least 6 characters')]")]
        private IWebElement PswrdValidationLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Please enter a valid email address')]")]
        private IWebElement EmailValidationLabel { get; set; }


        //Function to Click Join
        public void ClickJoin()
        {            
            //Click Join to sign up for the skill exchange Portal
            Join.Click();
        }

        //Function to register new user
        public void RegisterDetails(string firstname, string lastname, string email, string password, string confirmpassword)
        {
            //Enter the data for First name
            FirstName.SendKeys(firstname);

            //Enter the data for Last name
            LastName.SendKeys(lastname);

            //Enter the data for EmailID
            Email.SendKeys(email);

            //Enter the data for Password
            Password.SendKeys(password);

            //Enter the data for Confirm Password
            CnfrmPswrd.SendKeys(confirmpassword);
        }

        //Function to register new user
        public void CheckTermsConditions()
        {
            //Check on the terms and conditions check box prior to clicking the Join button
            TermsCndtnsChkbox.Click();
        }

        //Function to register new user
        public void ClickJoinButton()
        {
            //Click on the Join button to complete the registration
            JoinButton.Click();
        }

        //Function to register new user
        public void ValidateRegistration(bool newuser)
        {

            //Implicit wait for the registeration pop up to be available
            Wait.wait(2, driver);

            try
            {
                if (newuser)
                {
                    if (PopUp.Text == "Registration Successfull")
                    {                        
                        //Print status in log mentioning that registartion is successful
                        TestContext.WriteLine(PopUp.Text);
                    }

                }
                else
                {
                    String EmailValidationMsg = EmailValidation.Text;
                    if (EmailValidationMsg == "This email has already been used to register an account.")
                        TestContext.WriteLine("The account has already been created with this emailID, Please log in using exisitng account details");
                }

            }
            catch (Exception e)
            {
                Assert.Fail("Registration failed due to 1 or more errors. Make sure that there isn't an existing account", e.Message);
            }

        }

        public void ClickSignIn()
        {
            //Wait for login page to be loaded and 'Sign In' to become visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/a");

            //Click on Sign in button
            signIn.Click();
        }

        public void LoginSteps(string Name, string password)
        {
            //Wait for email textbox to be present
            Wait.ElementPresent(driver, "Name", "email");
           
           //Read the emailID data from excel and enter the data into the Email Textbox
           email.SendKeys(Name);

           //Read the Password data from excel and enter the data into the Password Textbox
           pswrd.SendKeys(password);
           
        }

        public void ClickLogin()
        {
            //Click on the Login button
            login.Click();

            Thread.Sleep(1000);
        }

        public void ValidatedLogin(string CredentialType)
        {
            if (CredentialType == "Valid Username and Valid Password")
            {
                //Wait for Home page to be loaded by checking if 'Sign Out' is visible
                Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button");              
                
            }
            else if (CredentialType == "Valid Username and Blank Password")
            {
                //Wait for password validation tag to be visible
                Wait.ElementIsVisible(driver, "XPath", "//div[contains(text(),'Password must be at least 6 characters')]");

                //Strings to store the expected and actual password validation label
                string PswrdValdtnText = PswrdValidationLabel.Text;
                string PswrdValdtnTextExp = "Password must be at least 6 characters";

                //Validate the label for Blank Password
                Assert.That(PswrdValdtnText, Is.EqualTo(PswrdValdtnTextExp));
            }

            else if (CredentialType == "Blank Username and Valid Password")
            {
                //Wait for password validation tag to be visible
                Wait.ElementIsVisible(driver, "XPath", "//div[contains(text(),'Please enter a valid email address')]");

                //Strings to store the expected and actual Email validation label
                String EmailValdtnText = EmailValidationLabel.Text;
                String EmailValdtnTextExp = "Please enter a valid email address";

                //Validate the label for Blank Username
                Assert.That(EmailValdtnText, Is.EqualTo(EmailValdtnTextExp));
            }
            else if (CredentialType == "Blank Username and Blank Password")
            {
                //Wait for password validation tag to be visible
                Wait.ElementIsVisible(driver, "XPath", "//div[contains(text(),'Please enter a valid email address')]");

                //Strings to store the expected and actual Email validation label
                String EmailValdtnText = EmailValidationLabel.Text;
                String EmailValdtnTextExp = "Please enter a valid email address";

                //Strings to store the expected and actual password validation label
                String PswrdValdtnText = PswrdValidationLabel.Text;
                String PswrdValdtnTextExp = "Password must be at least 6 characters";

                //Validate the label for Blank Username and Blank Password
                Assert.That(EmailValdtnText, Is.EqualTo(EmailValdtnTextExp));
                Assert.That(PswrdValdtnText, Is.EqualTo(PswrdValdtnTextExp));

            }
            else if (CredentialType == "Valid Username and InValid Password")
            {
                //Wait for password validation tag to be visible
                Wait.ElementIsVisible(driver, "XPath", "//div[contains(text(),'Password must be at least 6 characters')]");

                //String to hold the password validation label
                String PswrdValdtnText = PswrdValidationLabel.Text;
                String PswrdValdtnTextExp = "Password must be at least 6 characters";

                //Validate the label for password field
                Assert.That(PswrdValdtnText, Is.EqualTo(PswrdValdtnTextExp));
            }
            
        }
                

        public void LoginStepsAfterChangePassword(string emailID, string newpswrd)
        {
            //Wait for login page to be loaded and 'Sign In' to become visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/a");

            //Click on Sign in button
            signIn.Click();

            //Wait for email textbox to be present
            Wait.ElementPresent(driver, "Name", "email");

            //Read the emailID data from excel and enter the data into the Email Textbox
            email.SendKeys(emailID);

            //Read the Password data from excel and enter the data into the Password Textbox
            pswrd.SendKeys(newpswrd);

            //Click on the Login button
            login.Click();            

            try
            {
                //Wait for Home page to be loaded by checking if 'Sign Out' is visible
                Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button");
            }
            catch (Exception e)
            {
                TestContext.WriteLine("Unsuccessfull Login", e.Message);
            }
        }        

        }

    }
