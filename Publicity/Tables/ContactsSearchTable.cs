using Core.Tables;
using OpenQA.Selenium;

namespace Publicity.Tables
{
	public class ContactsSearchTable : TableBase<ContactsSearchRow>
	{
		public ContactsSearchTable(By tableLocator) : base(tableLocator) { }
	}
}
