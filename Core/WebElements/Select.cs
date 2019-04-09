using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.WebElements
{
	public class Select : Element
	{
		public Select(By locator) : base(locator) { }
		public Select(IWebElement element) : base(element) { }

		public void SelectByText(string text)
		{
			WaitForDisplayed();
			SelectElement field = new SelectElement(Child(By.XPath("./following-sibling::select")));
			field.SelectByText(text);
		}

		public void SelectByValue(string text)
		{
			WaitForDisplayed();
			SelectElement field = new SelectElement(Child(By.XPath("./following-sibling::select")));
			field.SelectByValue(text);
		}

		public string SelectedOption()
		{
			WaitForDisplayed();
			SelectElement field = new SelectElement(Child(By.XPath("./following-sibling::select")));
			return field.SelectedOption.Text.Trim().ToString();
		}

		public void Click()
		{
			WaitForDisplayed();
			WebElement.Click();
		}
	}
}
