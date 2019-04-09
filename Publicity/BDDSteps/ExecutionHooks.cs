using Core.Configuration;
using Core.DriverCore;
using OpenQA.Selenium;
using Protractor;
using System;
using TechTalk.SpecFlow;

namespace Publicity.BDDSteps
{
	[Binding]
	public sealed class ExecutionHooks
	{
		[BeforeScenario]
		public static void BeforeScenario()
		{
			IWebDriver driver = Driver.WedDriver;
			driver.Navigate().GoToUrl(Config.Url);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
			NgWebDriver ngDriver = Driver.Instance;
			ngDriver.WaitForAngular();
			ngDriver.Url = driver.Url;
		}

		[AfterScenario]
		public static void AfterScenario()
		{
			Driver.QuitBrowser();
		}
	}
}
