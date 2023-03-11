using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


	
	public class DriverFactory
	{

		public static IWebDriver Driver { get; set; }


		public DriverFactory()
		{
			//string outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			IWebDriver dvr = new ChromeDriver();
			dvr.Manage().Window.Maximize();
			Driver = dvr;
		}

	}


