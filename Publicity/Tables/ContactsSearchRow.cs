using Core.Tables;
using OpenQA.Selenium;

namespace Publicity.Tables
{
	public class ContactsSearchRow : RowBase
	{
		public ContactsSearchRow(IWebElement element) : base(element) { }
		public IWebElement Checkbox => GetElement(0, "input");
		public IWebElement Name => GetElement(1, ".//a");
		public string Company => GetTdText(2);
		public string ShowName => GetTdText(3);
		public string JobTitle => GetTdText(4);
		public string MediaType => GetTdText(5);
		public string Markets => GetTdText(6);
		public string Topics => GetTdText(7);
		public string Email => GetTdText(8);
		public string MobileNumber => GetTdText(9);
		public string OfficeNumber => GetTdText(10);
		public string PrimaryAddress => GetTdText(11);
		public string City => GetTdText(12);
		public string State => GetTdText(13);
		public string Zip => GetTdText(14);
		public string Country => GetTdText(15);
		public string ReasonForReturnedPackage => GetTdText(16);
		public string Notes => GetTdText(17);
		public string Facebook => GetTdText(18);
		public string Instagram => GetTdText(19);
		public string Twitter => GetTdText(20);
		public string LinkedIn => GetTdText(21);
		public string ListSpecific => GetTdText(22);
		public string Language => GetTdText(23);
		public string CompanyWebsite => GetTdText(24);
		public string National => GetTdText(25);
		public string CreatedDate => GetTdText(26);
		public string CreatedBy => GetTdText(27);
		public string LastUpdatedDate => GetTdText(28);
		public string LastUpdatedBy => GetTdText(29);
		public IWebElement EditIcon => GetElement(30, ".//i[contains(@class, 'fa-pencil')]");
		public IWebElement RemoveIcon => GetElement(30, ".//i[contains(@class, 'fa-trash')]");
		public IWebElement HistoryIcon => GetElement(30, ".//i[contains(@class, 'fa-history')]");
	}
}
