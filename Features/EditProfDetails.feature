Feature: EditProfDetails
	In order to showcase my updated skills to people
	As a seller 
	I would like to edit my existing profile details
	and view the updated details on my profile page


@automation
Scenario Outline: I would like to edit existing Language details in my profile 
	Given I Sign into SkillSwap with <CredentialType>, <EmailAddress> as Email, <Password> as Password
	And  I am able to view my home page
	When I click on my Profile, go to Languages tab and click edit button
	Then I should be able to update details of last row of existing languages

Examples: 
| EmailAddress          | Password | CredentialType                    |
|zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |
