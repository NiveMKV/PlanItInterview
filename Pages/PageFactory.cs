using System;
using NUnit.Framework.Internal;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;

namespace PlanItTestProject.Pages
{
    public class PageFactory : DriverFactory
    {
        public void VerifyHomePageIsLoaded()
        {
            homePage.VerifyHomePage();
        }

        public void CloseDriver()
        {
            try
            {
                Driver.Close();
                Driver.Quit();

            }
            catch (Exception ex)
            {
                throw new Exception($"Driver instance is not closed properly : {ex.Message}");

            }
        }

        public HomePage homePage => new HomePage(Driver);
        public ContactPage contactPage => new ContactPage(Driver);
        public ShopPage shopPage => new ShopPage(Driver);


        #region Browser Page Methods
        public bool ElementExists(IWebElement element, By byLocator)
        {
            bool value = false;
            IWebElement aElement = WaitExtension.WaitElementExists(Driver, byLocator);

            try
            {
                value = aElement.Displayed;
            }
            catch (Exception ex)
            {
                throw new Exception($"The Element is not found: {ex.Message}");
            }

            return value;
        }

        public void WaitTillTheElementIsClickable(IWebElement element, By byLocator)
        {
            WaitExtension.WaitElementToBeClickable(Driver, byLocator).Click();
        }
        #endregion
    }
}

