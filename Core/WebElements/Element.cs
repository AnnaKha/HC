using Core.DriverCore;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace Core.WebElements
{
	public class Element
	{
		private IWebElement _webElement;
		protected By Locator { get; set; }

		public bool IsEnabled => WebElement.Enabled;
		public bool IsSelected => WebElement.Selected;
		public string GetValue()
		{
			string value = WebElement.GetAttribute("value").Trim();
			if (value == null)
			{
				return string.Empty;
			}
			else
			{ return value; }
		}
		public IWebElement Child(By locator) => WebElement.FindElement(locator);

		public bool IsDisplayed()
		{
			try
			{
				bool state = WebElement.Displayed;
				return state;
			}
			catch (NotFoundException)
			{ return false; }
		}

		protected T CreateInstance<T>(IWebElement element) where T : Element
		{
			return Activator.CreateInstance(typeof(T), element) as T;
		}

		public T Child<T>(By locator) where T : Element
		{
			var element = WebElement.FindElement(locator);
			return CreateInstance<T>(element);
		}

		protected ReadOnlyCollection<IWebElement> Children(By locator)
		{
			return WebElement.FindElements(locator);
		}

		public Element(By locator)
		{
			Locator = locator;
		}

		protected Element(IWebElement element)
		{
			WebElement = element;
		}

		public By GetSelector()
		{
			return Locator;
		}

		protected IWebElement WebElement
		{
			get { return _webElement ?? Driver.Instance.FindElement(Locator); }
			private set { _webElement = value; }
		}

		public void WaitForNotDisplayed()
		{
			Driver.WaitForElementIsHidden(Locator);
		}

		public void WaitForDisplayed()
		{
			for(int i=0; i<5; i++)
			{
				try { Driver.WaitFor(Locator); break; }
				catch (StaleElementReferenceException) {//do nothing
				}
			}
		}
	}
}
