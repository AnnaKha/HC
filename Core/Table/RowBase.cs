using System.Linq;
using Core.WebElements;
using OpenQA.Selenium;

namespace Core.Tables
{
	public class RowBase : Element
	{
		public RowBase(IWebElement element) : base(element) { }
		protected string GetTdText(int cellIndex)
		{
			var elements = WebElement.FindElements(By.XPath(".//td"));
			if (!elements.Any()) return null;
			var element = elements.ElementAt(cellIndex);

			return element.Text;
		}

		protected IWebElement GetElement(int cellIndex, string xpath)
		{
			var elements = WebElement.FindElements(By.XPath(".//td"));
			if (!elements.Any()) return null;
			var element = elements.ElementAt(cellIndex).FindElement(By.XPath(xpath));
			return element;
		}
	}
}
