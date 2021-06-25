Feature: ManageRequest for Sent Requests
	For the Seller to track the 'Sent requests' sent out to other Sellers
	for certain services, there is a Manage Request module for 'Sent Requests'

@automation
Scenario Outline: Validate Sent Requests in Manage Requests Feature
	Given The Seller has logged in to SkillSwap with <CredentialType>, email as <EmailAddress>, password as <Password>
	And   Seller has sent out a request for a Service <service> to other Seller
	When the Seller Clicks on Sent Requests in Manage Requests
	Then Seller should be able to view the details of Sent Requests

Examples: 
| EmailAddress           | Password | CredentialType                    | service	  |
| zaara6.susan@gmail.com | 12345678 | Valid Username and Valid Password | Agile Coach |