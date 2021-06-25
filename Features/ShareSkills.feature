Feature: Add, edit and Delete services using ShareSkills

@automation
Scenario Outline: As a seller I would like to add my services through Share Skill module
	Given I sign into SkillSwap with <CredentialType>, <EmailAddress> as Email, <Password> as Password
	And  I am able to view my home page and Click on Share SKill button
	When I fill the details of the service <ServiceName> and Click Save
	And I navigate to the Manage Listings to view the service <ServiceName>
	Then I should be able to view the <ServiceName> listed with the same details as provided
Examples: 
| EmailAddress           | Password | CredentialType                    | ServiceName      |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |Technical Blogger |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |QA Mentor         |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |Yoga Teacher      |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |Western Music     |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |Western music     |

@automation
Scenario Outline:  As a seller I would like to edit my existing services in Share Skill module
	Given I sign into SkillSwap with <CredentialType>, <EmailAddress> as Email, <Password> as Password
	And  I navigate to the Manage Listings and edit the service <ServiceName>
	When I update the details of the service <ServiceName> and Click Save
	Then I should be able to view the updated <ServiceName> in the Manage Listings	
	
Examples: 
| EmailAddress           | Password | CredentialType                    | ServiceName      |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |Yoga Teacher      |

@automation
Scenario Outline: As a seller I would like to delete my existing services in Share Skill module
Given I sign into SkillSwap with <CredentialType>, <EmailAddress> as Email, <Password> as Password
And   I navigate to the Manage Listings 
When  I choose to delete the service <ServiceName>
Then the service <ServiceName> should no longer exist in the listings

Examples: 
| EmailAddress           | Password | CredentialType                    | ServiceName      |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |Technical Blogger |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |QA Mentor         |