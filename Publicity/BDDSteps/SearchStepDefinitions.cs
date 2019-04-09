using Core.DriverCore;
using NUnit.Framework;
using Protractor;
using Publicity.Pages;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace Publicity.BDDSteps
{
	[Binding]
	public class SearchStepDefinitions
	{
		HomePage landingPage = new HomePage();
		SearchForContacts searchPage = new SearchForContacts();

		[When(@"I have opened Search for Contacts")]
		[Given(@"I have opened Search for Contacts")]
		public void GivenIHaveOpenedSearchForContacts()
		{
			landingPage.OpenSearchContacts();
		}

		[Given(@"search criteria for line (.*) are entered: (.*), (.*), (.*)")]
		public void GivenSearchCriteria__ForLine_AreEntered(int index, string field, string value, string condtion = "and")
		{
			switch (field)
			{
				case "Media Type":
					searchPage.SetSearchLineForMultiSelectField(index, field, value, condtion);
					break;
				case "Markets":
					searchPage.SetSearchLineForMultiSelectField(index, field, value, condtion);
					break;
				case "Topics":
					searchPage.SetSearchLineForMultiSelectField(index, field, value, condtion);
					break;
				case "Language":
					searchPage.SetSearchLineForMultiSelectField(index, field, value, condtion);
					break;
				case "National USA":
					searchPage.SetSearchLineForNationalField(index, field, value, condtion);
					break;
				default:
					searchPage.SetSearchLine(index, field, value, condtion);
					break;
			}
		}

		[Given(@"search line (.*) is removed")]
		public void GivenSearchLineIsRemoved(int index)
		{
			searchPage.RemoveSearchLine(index);
		}

		[When(@"click on Search button")]
		public void WhenClickOnSearchButton()
		{
			searchPage.ApplySearch();
		}

		[Then(@"default search criteria are displayed")]
		public void ThenDefaultSearchCriteriaAreDisplayed()
		{
			Assert.AreEqual(searchPage.GetSearchLine(1).First(), "Media Type");
			Assert.AreEqual(searchPage.GetSearchLine(1)[1], string.Empty);
			Assert.AreEqual(searchPage.GetSearchLine(1).Last(), "and");

			Assert.AreEqual(searchPage.GetSearchLine(2).First(), "Company");
			Assert.AreEqual(searchPage.GetSearchLine(2)[1], string.Empty);
			Assert.AreEqual(searchPage.GetSearchLine(2).Last(), "and");

			Assert.AreEqual(searchPage.GetSearchLine(3).First(), "Name");
			Assert.AreEqual(searchPage.GetSearchLine(3)[1], string.Empty);
			Assert.AreEqual(searchPage.GetSearchLine(3).Last(), "and");
		}

		[Then(@"search results in table satisfy all searching criteria: name - (.*) and company name - (.*) and email - (.*)")]
		public void ThenSearchResultsInTableSatisfyThreeAndSearchingCriteria(string firstCriteriaInLowerCase, string secondCriteriaInLowerCase, string thirdCriteriaInLowerCase)
		{
			Assert.That(searchPage.NameValuesInTable().All(x => x.Contains(firstCriteriaInLowerCase)));
			Assert.That(searchPage.CompanyValuesInTable().All(x => x.Contains(secondCriteriaInLowerCase)));
			Assert.That(searchPage.EmailValuesInTable().All(x => x.Contains(thirdCriteriaInLowerCase)));
		}

		[Then(@"search results in table satisfy all searching criteria: by Job Title - (.*), (.*), (.*)")]
		public void ThenSearchResultsInTableSatisfyThreeOrSearchingCriteria(string firstCriteriaInLowerCase, string secondCriteriaInLowerCase, string thirdCriteriaInLowerCase)
		{
			ScrollTable();
			Assert.That(searchPage.ContactsSearch.Rows.Select(i => i.JobTitle.ToLower()).ToList().All(x => x.Contains(firstCriteriaInLowerCase) || x.Contains(secondCriteriaInLowerCase) || x.Contains(thirdCriteriaInLowerCase)));
		}

		[Then(@"search results in table satisfy all searching criteria: company name - (.*) and  name - (.*) or name - (.*)")]
		public void ThenSearchResultsInTableSatisfyOneOrAndTwoAndSearchingCriteria(string firstCriteriaInLowerCase, string secondCriteriaInLowerCase, string thirdCriteriaInLowerCase)
		{
			ScrollTable();
			ScrollTable();
			Assert.That(searchPage.CompanyValuesInTable().All(x => x.Contains(firstCriteriaInLowerCase.ToLower())));
			Assert.That(searchPage.ContactsSearch.Rows.Select(i => i.Name.Text.ToLower()).Distinct().ToList().Any(x => x.Contains(secondCriteriaInLowerCase.ToLower()) && x.Contains(thirdCriteriaInLowerCase.ToLower())));
		}

		[Then(@"search results in table satisfy all searching criteria: by National USA - (.*)")]
		public void ThenSearchResultsInTableSatisfyAllSearchingCriteriaByNationalUSA_No(string value)
		{
		searchPage.AddAllColumnsForSearchResultsTable();
		ScrollTable();
		Assert.That(searchPage.ContactsSearch.Rows.Select(i => i.National.ToLower()).ToList().All(x => x.Contains(value.ToLower())));

		}

		[Then(@"search results in table satisfy all searching criteria: by Media Type - (.*) and Markets - (.*)")]
		public void ThenSearchResultsInTableSatisfyAllSearchingCriteriaByMediaType_BlogAndMarkets_First(string mediaType, string markets)
		{
			ScrollTable();
			Assert.That(searchPage.ContactsSearch.Rows.Select(i => i.MediaType.ToLower()).ToList().All(x => x.Contains(mediaType.ToLower())));
			Assert.That(searchPage.ContactsSearch.Rows.Select(i => i.Markets.ToLower()).ToList().All(x => x.Contains(markets.ToLower())));
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