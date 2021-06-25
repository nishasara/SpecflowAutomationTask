Feature: SignIn
This feature enables existing users to sign into the SkillSwap module

 
@automation
Scenario Outline: Sign into the SkillSwap application with invalid credentials
     Given  I am an existing user and I click on Sign In
       And  I enter credentials for <EmailAddress>, <Password>     
      When  I click on Login
      Then  I should not be logged in successfully with <InvalidCredentialType>

Examples: 
| EmailAddress           | Password | InvalidCredentialType               |
| zaara6.susan@gmail.com |          | Valid Username and Blank Password   |
|                        | 12345678 | Blank Username and Valid Password   |
|                        |          | Blank Username and Blank Password   |
| zaara6.susan@gmail.com | 23457    | Valid Username and InValid Password |

@automation
Scenario Outline: Sign into the SkillSwap application with valid credentials
           Given I am an existing user and I click on Sign In
            And  I enter credentials for <EmailAddress>, <Password>     
           When  I click on Login             
           Then  I should logged in successfully with <CredentialType>

Examples: 
| EmailAddress          | Password | CredentialType                    |
|zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |



