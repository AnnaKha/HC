using OpenQA.Selenium;

namespace Core.WebElements
{
	public class ClickElement : Element
	{
		public ClickElement(By locator) : base(locator) { }
		public ClickElement(IWebElement element) : base(element) { }
		public void Click()
		{
			WaitForDisplayed();
			WebElement.Click();
		}

		public new bool IsSelected => WebElement.FindElement(By.XPath(".//input")).Selected;
	}
}
