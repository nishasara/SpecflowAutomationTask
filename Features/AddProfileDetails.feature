Feature: AddProfileDetails
	Inorder to showcase my skills to people
	As a seller 
	I would like to add my profile details
	and view the same on my profile page
 
      
@automation
Scenario Outline:  I would like to add availability details to my profile 	
    Given  I have Signed into SkillSwap with <CredentialType>, <EmailAddress>, <Password>
	And   I am able to view my homepage
	When  I click on Profile
	Then  I should be able to add details in profile like Availability, Hours, Earn Target in my profile
Examples: 
| EmailAddress          | Password | CredentialType                    |
|zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |

@automation
Scenario Outline: I would like to add description details to my profile 
   Given  I have Signed into SkillSwap with <CredentialType>, <EmailAddress>, <Password>
	And   I am able to view my homepage
	When  I click on Profile and click description
	Then  I should be able to add description in my profile
Examples: 
| EmailAddress          | Password | CredentialType                    |
|zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |

@automation
Scenario Outline: I would like to add details of languages to my profile 
	Given  I have Signed into SkillSwap with <CredentialType>, <EmailAddress>, <Password>
	And   I am able to view my homepage
	When  I click on Profile and click languages
	Then  I should be able to add details of languages known and save it
Examples: 
| EmailAddress          | Password | CredentialType                    |
|zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |

@automation
Scenario Outline: I would like to add details of skills to my profile 
	Given  I have Signed into SkillSwap with <CredentialType>, <EmailAddress>, <Password>
	And   I am able to view my homepage
	When  I click on Profile and click Skills
	Then  I should be able to add details of Skills and save it
Examples: 
| EmailAddress          | Password | CredentialType                    |
|zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |

@automation
Scenario Outline: I would like to add details of education to my profile 
	Given  I have Signed into SkillSwap with <CredentialType>, <EmailAddress>, <Password>
	And   I am able to view my homepage
	When I click on Profile and click education
	Then I should be able to add details of Education and save it
Examples: 
| EmailAddress          | Password | CredentialType                    |
|zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |

@automation
Scenario Outline: I would like to add details of Certifications to my profile 
	Given  I have Signed into SkillSwap with <CredentialType>, <EmailAddress>, <Password>
	And   I am able to view my homepage
	When I click on Profile and click Certifications
	Then I should be able to add details of certification and save it
Examples: 
| EmailAddress          | Password | CredentialType                    |
|zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |

@automation
Scenario Outline: I would like to add two same entries of Certifications to my profile 
	Given  I have Signed into SkillSwap with <CredentialType>, <EmailAddress>, <Password>
	And   I am able to view my homepage
	When I click on Profile, click Certifications and add two similar details
	Then I should not be allowed to add 2 similar entries showing a pop up
Examples: 
| EmailAddress          | Password | CredentialType                    |
|zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password |






