using Core.DriverCore;
using Core.Models;
using FluentAssertions;
using NUnit.Framework;
using Protractor;
using Publicity.Pages;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace Publicity.BDDSteps
{
	[Binding]
	public class CreateContactStepDefinitions
	{
		HomePage landingPage = new HomePage();
		SearchForContacts searchPage = new SearchForContacts();
		CreateEditContact createContactPage = new CreateEditContact();
		Contact createdContact;
		ContactWithRequiredInfo createdContactWithRequiredInfo;

		[Given(@"I have opened Create new Contact")]
		public void GivenIHaveOpenedCreateNewContact()
		{
			landingPage.OpenCreateNewContact();
		}


		[Given(@"entered all information for contact")]
		public void GivenEnteredAllInformationForContact()
		{
			createdContact = createContactPage.EnterAllDataForContact();
		}

		[Given(@"entered only required information for contact")]
		public void GivenEnteredOnlyRequiredlInformationForContact()
		{
			 createdContactWithRequiredInfo = createContactPage.EnterOnlyRequiredDataForContact();
		}

		[Given(@"I press save")]
		[When(@"I press save")]
		public void WhenIPressSave()
		{
			createContactPage.SaveUpdatedContactInfo();
		}

		[Then(@"check created contact is available in search results")]
		public void CheckCreatedContactIsAvailableInSearchResults()
		{
			landingPage.OpenSearchContacts();
			string name=string.Empty;
			if (createdContact != null)
			{ name = createdContact.FirstName; }
			if (createdContactWithRequiredInfo != null)
			{ name = createdContactWithRequiredInfo.FirstName; }
			searchPage.SetSearchLine(1, "Name", name);
			searchPage.RemoveSearchLine(3);
			searchPage.RemoveSearchLine(2);
			searchPage.ApplySearch();
			ScrollTable();
			ContactWithSearchInfo newContact = searchPage.GetContactInfoForRow(1);
			Assert.That(searchPage.ContactsSearch.Rows.Select(i => i.Name.Text.ToLower()).ToList().All(x => x.Contains(createdContact.FirstName.ToLower())));
			newContact.Should().BeEquivalentTo(createdContact);// check when search works
		}


		[Given(@"click on Search button")]
		public void GivenClickOnSearchButton()
		{
			searchPage.ApplySearch();
		}

		[Given(@"click edit icon for created contact on search results")]
		public void GivenClickEditIconForLine()
		{
			landingPage.OpenSearchContacts();
			searchPage.RemoveSearchLine(3);
			searchPage.RemoveSearchLine(2);
			string name = string.Empty;
			if (createdContact != null)
			{ name = createdContact.FirstName; }
			if (createdContactWithRequiredInfo != null)
			{ name = createdContactWithRequiredInfo.FirstName; }
			searchPage.SetSearchLine(1, "Name", name);
			searchPage.ApplySearch();
			searchPage.ContactsSearch.Rows.First().EditIcon.Click();
		}

		[Given(@"add additional address")]
		public void GivenAddAdditionalAddress()
		{
			createContactPage.AddAddressForContact(2);
		}

		[Then(@"check edited contact contains additional address")]
		public void ThenCheckEditedContactContainsNewInformation()
		{
			createContactPage.GetContactAdditionalAddress().Should().BeEquivalentTo(createdContact);
			//check when search works
		}

		private void ScrollTable()
		{
			NgWebDriver ngDriver = Driver.Instance;
			ngDriver.WaitForAngular();
			ngDriver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
			Thread.Sleep(1000);
		}
	}
}