using Core.WebElements;
using OpenQA.Selenium;

namespace Publicity.Pages
{
	public class HomePage
	{
		public ClickElement Contacts = new ClickElement(By.XPath("//a[text()=' Contacts ']"));
		public ClickElement SearchForContact = new ClickElement(By.XPath("//a[text()=' Search for Contact ']"));
		public ClickElement CreateNewContact = new ClickElement(By.XPath("//a[text()=' Create new contact ']"));

		public void OpenSearchContacts()
		{
			Contacts.Click();
			SearchForContact.Click();
		}
		public void OpenCreateNewContact()
		{
			Contacts.Click();
			CreateNewContact.Click();
		}
	}
}
