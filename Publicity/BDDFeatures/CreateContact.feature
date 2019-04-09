Feature: Create New Contact
	As a User I want to
	add new contacts to the system,
	avoiding duplicate creation

Scenario: New contact with all information can be created
	Given I have opened Create new Contact
	And entered all information for contact
	When I press save 
	Then check created contact is available in search results

Scenario: New contact with only required information can be created
	Given I have opened Create new Contact
	And entered only required information for contact
	When I press save 
	Then check created contact is available in search results

Scenario: Edit created contact by adding additional address
	Given I have opened Create new Contact
	And entered only required information for contact
	And I press save
	And click edit icon for created contact on search results
	And add additional address
	And I press save 
	When click edit icon for created contact on search results
	Then check edited contact contains additional address
