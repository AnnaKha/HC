using NUnit.Framework;
using Core.DriverCore;
using OpenQA.Selenium;
using System;
using Core.Configuration;
using Protractor;

namespace Publicity.Tests
{
	public class TestSetUp
	{
		[SetUp]
		public void SetUp()
		{
			IWebDriver driver = Driver.WedDriver;
			driver.Navigate().GoToUrl(Config.Url);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(20);
			NgWebDriver ngDriver = Driver.Instance;
			ngDriver.WaitForAngular();
			ngDriver.Url = driver.Url;
		}

		[TearDown]
		public void CleanUp()
		{
			Driver.QuitBrowser();
		}
	}
}
