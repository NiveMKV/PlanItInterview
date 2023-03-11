using System;
using OpenQA.Selenium;
using PlanItTestProject.Pages;

namespace PlanItTestProject.Tests
{
    [TestFixture]
	public class BaseTest: DriverFactory
	{

        public PageFactory PgFactory { get; set; }

        public BaseTest()
        {
            PgFactory = new PageFactory();
        }

        //[SetUp]
        //public void InitialSetup()
        //{
        //    Driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
        //    Assert.That(() => Driver.Title.Equals("Jupiter Toys"), "The page isn't landed on a correct page");
        //}

        //[TearDown]
        //public void AfterTest()
        //{
        //    try
        //    {
        //        Driver.Close();
        //        Driver.Quit();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Driver instance is not closed properly : {ex.Message}");

        //    }
        //}
    }
}

