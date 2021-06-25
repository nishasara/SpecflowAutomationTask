Feature: Chat
User should be able to chat with other users using Chat feature

@automation
Scenario Outline: As a registered user of SkillSwap (SellerOne) I should be able to chat with other Seller (SellerTwo) using Chat feature
Given    As SellerOne I log into the SkillSwap module with <CredentialType>, <SellerOneEmail> as email, <Password> as Password 
And      I search for service <servicename> that I would like to avail
And      I navigate to the SellerTwo's page to access the Chat feature
And      I send chat messages to SellerTwo
When     SellerTwo log into the SkillSwap module with <CredentialType>, <SellerTwoEmail> as email, <Password> as Password 
And      SellerTwo views Chat notifications and navigate to the Chat module
Then     SellerTwo should be able to view SellerOne chat messages with time stamp details


Examples: 
| SellerOneEmail         | SellerTwoEmail           | Password    | CredentialType                    | servicename |
| sara4.susan@ymail.com	 | zaara6.susan@gmail.com   | 12345678    | Valid Username and Valid Password | QA Mentor   |