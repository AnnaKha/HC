using System.Collections.Generic;
using System.Linq;
using Core.WebElements;
using OpenQA.Selenium;

namespace Core.Tables
{
	public abstract class TableBase<T>: Element  where T : RowBase
	{
		protected TableBase(By tableLocator) : base(tableLocator) { }
		protected virtual string RowsXpath
		{
			get { return ".//tbody//td/.."; }
		}
		public IList<T> Rows => WebElement.FindElements(By.XPath(RowsXpath)).Select(CreateInstance<T>).ToList();
	}
}