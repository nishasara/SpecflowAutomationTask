Feature: Registration
This feature enables new users to register an account in the SkillSwap

@automation
Scenario Outline: I would like to register an account in Skill Swap as a new user
   Given I am a newuser and I click on Join
   And   I enter the details <Firstname>,<Lastname>,<EmailAddress>,<Password>,<ConfirmPassword>
   And   I agree to the terms and conditions
   When  I click on Join
   Then  I should be registered successfully as <newuser>

   Examples: 
   | newuser | Firstname | Lastname | EmailAddress			 | Password | ConfirmPassword |
   | True    | Zaaran    | Susan    | zaara12.susan@gmail.com |12345678  |12345678         |
   

@automation
Scenario Outline: I would like to register an account in Skill Swap with existing EmailID
   Given I am an existing user and I click on Join
   And   I enter the details <Firstname>,<Lastname>,<EmailAddress>,<Password>,<ConfirmPassword>
   And   I agree to the terms and conditions
   When  I click on Join
   Then  I should not be allowed to register successfully as <newuser>


   Examples: 
   | newuser | Firstname  | Lastname  | EmailAddress		  | Password | ConfirmPassword |
   | False   | Zaaran     | Susan    | zaara12.susan@gmail.com |12345678  |12345678         |
