Feature: SearchSkills
Users should be able to Search skills based on either Skillsname or Usrename in the SKillSwap

@automation
Scenario Outline: I should be able to search skills using the Search feature to view the services available in SkillSwap
   Given  I log into SkillSwap with <CredentialType>, <EmailAddress> as Email, <Password> as Password
     And  I successfully navigate to my home page
    When  I search for the <Skill> using Search feature available in Home Page
     And  I apply filter for location type as <LocationType> on the search results
     Then I should be able to view only results for <Skill> with location Type as <LocationType>

Examples: 
| EmailAddress           | Password | CredentialType                    | Skill         | LocationType |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password | Western Music | Online       |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password | Western Music | On-Site      |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password | Western Music | ShowAll      |

@automation
Scenario Outline: I should be able to search skills using the username to view the services available in SkillSwap
   Given  I log into SkillSwap with <CredentialType>, <EmailAddress> as Email, <Password> as Password
     And  I successfully navigate to my home page
    When  I search for user as <Username> using Search feature
     And  I apply filter for location type as <LocationType> on the search results with username
     Then I should be able to view results for the skills listed by the <Username> with location Type as <LocationType>
Examples: 
| EmailAddress           | Password | CredentialType                    | Username      | LocationType |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password | Zaara1 Susan | Online       |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password | Zaara1 Susan | On-Site      |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password | Zaara1 Susan | ShowAll      |