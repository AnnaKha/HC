using Core.DriverCore;
using Core.Models;
using Core.WebElements;
using OpenQA.Selenium;
using Publicity.Tables;
using System.Collections.Generic;
using System.Linq;

namespace Publicity.Pages
{
	public class SearchForContacts
	{
		public const string fieldXpath = "(//label[text()='Field'])";
		public const string valueXpath = "(//label[text()='Value'])";
		public const string conditionXpath = "(//label[text()='Condition'])";

		public ClickElement AddSearchLineIcon = new ClickElement(By.XPath("//i[contains(@class,'fa-plus-circle')]"));
		public ClickElement Search = new ClickElement(By.XPath("//button[@type='submit']"));
		public ClickElement Reset = new ClickElement(By.XPath("//button[@type='reset']"));
		public ContactsSearchTable ContactsSearch = new ContactsSearchTable(By.TagName("table"));
		public ClickElement ManageColumns = new ClickElement(By.TagName("app-manage-columns"));
		public Element UserPreferencesSavedMessage = new Element(By.XPath("//div[contains(text(),'User preferences saved')]"));
		public Element UserPreferencesSavingdMessage = new Element(By.XPath("//div[contains(text(),'Saving user preferences')]"));

		public void ApplySearch()
		{
			Search.Click();
			ContactsSearch.WaitForDisplayed();
			AddAllColumnsForSearchResultsTable();
		}

		public void AddOneMoreSearcLine()
		{
			AddSearchLineIcon.Click();
		}

		public void SetSearchLine(int index, string fieldName, string criteria, string conditionValue = "and")
		{
			Select field = new Select(By.XPath($"{fieldXpath}[{index}]"));
			Input value = new Input(By.XPath($"{valueXpath}[{index}]/following-sibling::input"));
			Select condition = new Select(By.XPath($"{conditionXpath}[{index}]"));
			field.SelectByText(fieldName);
			value.SetText(criteria);
			condition.SelectByText(conditionValue);
			field.Click();
		}

		public void SetSearchLineForMultiSelectField(int index, string fieldName, string criteria, string conditionValue = "and")
		{
			Select field = new Select(By.XPath($"{fieldXpath}[{index}]"));
			MultiSelect value = new MultiSelect(By.XPath($"{valueXpath}[{index}]/following-sibling::input"));
			Select condition = new Select(By.XPath($"{conditionXpath}[{index}]"));
			field.SelectByText(fieldName);
			value.SetValue(criteria);
			condition.SelectByText(conditionValue);
			field.Click();
		}

		public void SetSearchLineForNationalField(int index, string fieldName, string criteria, string conditionValue = "and")
		{
			Select field = new Select(By.XPath($"{fieldXpath}[{index}]"));
			ClickElement value = new ClickElement(By.XPath($"//app-radio-group//label[text()=' {criteria} ']/..//span"));
			Select condition = new Select(By.XPath($"{conditionXpath}[{index}]"));
			field.SelectByText(fieldName);
			value.Click();
			condition.SelectByText(conditionValue);
			field.Click();
		}

		public List<string> GetSearchLine(int index)
		{
			Select field = new Select(By.XPath($"{fieldXpath}[{index}]"));
			Input value = new Input(By.XPath($"{valueXpath}[{index}]/following-sibling::input"));
			Select condition = new Select(By.XPath($"{conditionXpath}[{index}]"));
			List<string> searchCriteria = new List<string>
			{
				field.SelectedOption(),
				value.GetValue(),
				condition.SelectedOption()
			};
			return searchCriteria;
		}

		public void RemoveSearchLine(int index)
		{
			ClickElement removeIcon = new ClickElement(By.XPath($"(//i[contains(@class,'fa-minus-circle')])[{index}]"));
			removeIcon.Click();
		}

		public ContactWithSearchInfo GetContactInfoForRow(int index)
		{
			string[] fullName = ContactsSearch.Rows[index - 1].Name.Text.Split(',');
			ContactWithSearchInfo row = new ContactWithSearchInfo();
			row.LastName = fullName[0].Trim();
			row.FirstName = fullName[1].Trim().Split(' ')[0].Trim();
			if (fullName.Contains(" "))
			{ row.MiddleName = fullName[1].Trim().Split(' ')[1].Trim(); }
			else { row.MiddleName = string.Empty; }
			row.CompanyName = ContactsSearch.Rows[index - 1].Company;
			row.ShowName = ContactsSearch.Rows[index - 1].ShowName;
			row.JobTitle = ContactsSearch.Rows[index - 1].JobTitle;
			row.MediaType = ContactsSearch.Rows[index - 1].MediaType;
			row.Markets = ContactsSearch.Rows[index - 1].Markets;
			row.Topics = ContactsSearch.Rows[index - 1].Topics;
			row.Email = ContactsSearch.Rows[index - 1].Email;
			row.Mobile = ContactsSearch.Rows[index - 1].MobileNumber;
			row.Office = ContactsSearch.Rows[index - 1].OfficeNumber;
			row.AddressType = ContactsSearch.Rows[index - 1].PrimaryAddress;
			row.City = ContactsSearch.Rows[index - 1].City;
			row.State = ContactsSearch.Rows[index - 1].State;
			row.Zip = ContactsSearch.Rows[index - 1].Zip;
			row.Country = ContactsSearch.Rows[index - 1].Country;
			row.ReasonOfReturnedPackages = ContactsSearch.Rows[index - 1].ReasonForReturnedPackage;
			row.Facebook = ContactsSearch.Rows[index - 1].Facebook;
			row.Instagram = ContactsSearch.Rows[index - 1].Instagram;
			row.Twitter = ContactsSearch.Rows[index - 1].Twitter;
			row.LinkedIn = ContactsSearch.Rows[index - 1].LinkedIn;
			row.CompanyWebsite = ContactsSearch.Rows[index - 1].CompanyWebsite;
			row.Language = ContactsSearch.Rows[index - 1].Language;
			switch (ContactsSearch.Rows[index - 1].National)
			{
				case "No":
					row.National = "False";
					break;
				case "Yes":
					row.National = "True";
					break;
				default:
					row.National = "False";
					break;
			}
			switch (ContactsSearch.Rows[index - 1].ListSpecific)
			{
				case "No":
					row.ListSpecific = "Public";
					break;
				case "Yes":
					row.ListSpecific = "List Specific";
					break;
				default:
					row.ListSpecific = string.Empty;
					break;
			};
			if (row.Mobile == string.Empty)
			{ row.Mobile = "+___-___-____"; }
			if (row.Office == string.Empty)
			{ row.Office = "+___-___-____"; }
			return row;
		}

		public void EditColumnsSelectionForSearchResultsTable(string columnName)
		{
			ManageColumns.Click();
			ClickElement column = new ClickElement(By.XPath($"//div[contains(@class, 'manage-columns-alert')]//div[text()='{columnName}']/ancestor::div[contains(@class, 'manage-columns-alert')]"));
			column.Child(By.XPath("./following-sibling::div[contains(@class, 'manage-columns-alert')]//input")).Click();
		}

		public void AddAllColumnsForSearchResultsTable()
		{
			ManageColumns.Click();
			var columns = Driver.Instance.FindElements(By.XPath("//div[@class='modal-body']//app-checkbox//input"));
			foreach (IWebElement field in columns)
			{
				if (!field.Selected)
				{
					field.FindElement(By.XPath("./ancestor::app-checkbox//span")).Click();
					if (field == columns[12])
					((IJavaScriptExecutor)Driver.Instance).ExecuteScript($"document.querySelector('ngb-modal-window').scrollTop=450");
				}
			}
			ClickElement Save = new ClickElement(By.XPath("//ngb-modal-window//button[text()='Save']"));
			Save.Click();
			UserPreferencesSavingdMessage.WaitForNotDisplayed();
			UserPreferencesSavedMessage.WaitForNotDisplayed();
		}

		public List<string> NameValuesInTable()
		{
			return ContactsSearch.Rows.Select(i => i.Name.Text.ToLower()).ToList();
		}

		public List<string> CompanyValuesInTable()
		{
			return ContactsSearch.Rows.Select(i => i.Company.ToLower()).ToList();
		}
		public List<string> EmailValuesInTable()
		{
			return ContactsSearch.Rows.Select(i => i.Email.ToLower()).ToList();
		}
	}
}