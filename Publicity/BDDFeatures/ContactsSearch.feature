Feature: Contacts Search
	As a User 
	I want to be able to search for a contact 
	so I can quickly find needed contact 

Scenario: Search for contact is opened with default search criteria 
	Given I have opened Search for Contacts
	Then default search criteria are displayed

Scenario: Search results for three "and" criteria search are correct
	Given I have opened Search for Contacts
	And search criteria for line 1 are entered: Email, eugene, and
	And search criteria for line 2 are entered: Company, springfield, and
	And search criteria for line 3 are entered: Name, simpson, and
	When click on Search button
	Then search results in table satisfy all searching criteria: name - simpson and company name - springfield and email - eugene

Scenario: Search results for three "or" criteria search are correct
	Given I have opened Search for Contacts 
	And search criteria for line 1 are entered: Job Title, developer, or
	And search criteria for line 2 are entered: Job Title, editor, or
	And search criteria for line 3 are entered: Job Title, inspector, or
	When click on Search button
	Then search results in table satisfy all searching criteria: by Job Title - developer, editor, inspector

Scenario: Search results for two "and" and one "or" criteria search are correct
	Given I have opened Search for Contacts 
	And search criteria for line 1 are entered: Company, family, and
	And search criteria for line 2 are entered: Name, marge, or
	And search criteria for line 3 are entered: Name, bart, and
	When click on Search button
	Then search results in table satisfy all searching criteria: company name - family and  name - marge or name - bart

Scenario: Search results for field with boolean search options are correct
	Given I have opened Search for Contacts 
	And search line 1 is removed
	And search line 2 is removed
	And search criteria for line 1 are entered: National USA, No, and
	When click on Search button
	Then search results in table satisfy all searching criteria: by National USA - No

Scenario: Search results for field with predefined search options are correct
	Given I have opened Search for Contacts 
	And search criteria for line 1 are entered: Media Type, Blog, and
	And search criteria for line 2 are entered: Markets, 1 - First, and
	And search line 3 is removed
	When click on Search button
	Then search results in table satisfy all searching criteria: by Media Type - Blog and Markets - 1 - First

