Feature: ChangePassword
@automation
Scenario Outline: Change Current Password of SkillSwap to a New Password
   Given I Sign In with <ValidCredential>, <EmailAddress>, <CurrentPassword>
     And I Choose Change Password option in Profile
    When I enter <CurrentPassword>, <NewPassword>, <ConfirmPassword>
     And I Click on Save button
    Then I should be able to login with <EmailAddress>, <NewPassword>
    Examples: 
    | ValidCredential                   | EmailAddress           | CurrentPassword | NewPassword | ConfirmPassword |
    | Valid Username and Valid Password | zaara6.susan@gmail.com | 12345678        | 123456      | 123456          |
    | Valid Username and Valid Password | zaara6.susan@gmail.com | 123456          | 12345678    | 12345678        |