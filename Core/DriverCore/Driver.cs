using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Core.Configuration;
using Protractor;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace Core.DriverCore
{
	public enum Browsers
	{
		Chrome,
		Firefox,
		IE
	}

	public static class Driver
	{
		private static IWebDriver driver;
		private static NgWebDriver ngDriver;
		public static NgWebDriver Instance
		{
			get
			{
				return ngDriver ?? GetNgWebDriver();
			}
		}
		public static IWebDriver WedDriver
		{
			get
			{
				return driver ?? GetWebDriver();
			}
		}
		public static IWebDriver GetWebDriver()
		{
			var browser = Config.BrowserName;

			var browserName = (Browsers)Enum.Parse(typeof(Browsers), browser);

			switch (browserName)
			{
				case Browsers.Chrome:
					return driver = new ChromeDriver();
				case Browsers.Firefox:
					return driver = new FirefoxDriver();
				case Browsers.IE:
					return driver = new InternetExplorerDriver();
				default:
					throw new Exception("Unknown driver: " + browser);
			}
		}

		public static NgWebDriver GetNgWebDriver()
		{
			return ngDriver = new NgWebDriver(driver);
		}

		public static void QuitBrowser()
		{
			if (ngDriver != null)
			{

				Instance.Quit();
				Instance.Dispose();
			}
			ngDriver = null;
			if (driver != null)
			{
				WedDriver.Quit();
				WedDriver.Dispose();
			}
			driver = null;
		}

		public static void WaitForElementIsHidden(By locator, TimeSpan? timeout = null)
		{
			var wait = timeout.HasValue ? new WebDriverWait(driver, timeout.Value) :
				new WebDriverWait(ngDriver, TimeSpan.FromMilliseconds(10000));

			wait.Until(driver =>
			{
				var elements = driver.FindElements(locator);

				try
				{
					return elements.Count == 0 || elements.All(x => !x.Displayed);
				}
				// Once element is deleted from DOM webdriver throws StaleElementReferenceException
				catch (StaleElementReferenceException)
				{
					return driver.FindElements(locator).Any();
				}
			});
		}

		public static IWebElement WaitFor(By locator, TimeSpan? timeout = null)
		{
			var wait = timeout.HasValue ? new WebDriverWait(driver, timeout.Value) :
				new WebDriverWait(ngDriver, TimeSpan.FromMilliseconds(30000));

			return wait.Until(ExpectedConditions.ElementIsVisible(locator));
		}
	}
}
