Feature: Notifications

@automation
Scenario Outline: User should be able to select and unselect certain number of notifications
Given     As an existing user I sign into SkillSwap with <CredentialType>, <EmailAddress>, <Password>
And       I click on notifications tab in Homepage 
And       I click on See all notifications and Navigate to notifications Dashboard
When      I click on the respective checkboxes of <count> notifications
Then      <count> notifications should appear as selected 
Then      <count> notifications should appear as unselected when clicked again

Examples: 
| EmailAddress           | Password | CredentialType                    | count  |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password | 3      |

@automation
Scenario Outline: User should be able to mark all notifications as Read using Select All
Given     As an existing user I sign into SkillSwap with <CredentialType>, <EmailAddress>, <Password>
And       I click on notifications tab in Homepage 
And       I click on See all notifications and Navigate to notifications Dashboard
When      I click on Select all notifications
Then      all notifications should appear as unhighlighted

Examples: 
| EmailAddress           | Password | CredentialType                    |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |

@automation
Scenario Outline: User should be able to delete the required number of notifications
Given     As an existing user I sign into SkillSwap with <CredentialType>, <EmailAddress>, <Password>
And       I click on notifications tab in Homepage 
And       I click on See all notifications and Navigate to notifications Dashboard
When      I select the latest <count> notifications and click on Delete selection
Then      The selected notifications should be deleted

Examples: 
| EmailAddress           | Password | CredentialType                    | count  |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password | 2      |


