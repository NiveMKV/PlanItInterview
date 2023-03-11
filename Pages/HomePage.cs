using System;
using OpenQA.Selenium;


namespace PlanItTestProject.Pages
{
    public class HomePage
    {
        #region Fields
        private IWebDriver Driver;
        private string HomePageUrl = "home";
        private string HomePageTitle = "Jupiter Toys";
        private string ContactMnu = ".//*[@class='nav']//a[contains(text(), 'Contact')]";
        private string ShopMnu = ".//*[@class='nav']//a[contains(text(), 'Shop')]";
        private string ShopPageProductsListing = ".//*[contains(@class,'products')]/ul";
        private string CartMnu = ".//*[@id='nav-cart']/a";
        #endregion

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void VerifyHomePage()
        {
            Driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com");
            Assert.That(() => Driver.Title.Contains(HomePageTitle), "The home page isn't loaded correctly!!!");
        }

        public void ClickContactMenu()
        {
            Driver.FindElement(By.XPath(ContactMnu)).Click();
        }

        public void ClickShopMenu()
        {
            Driver.FindElement(By.XPath(ShopMnu)).Click();
            WaitExtension.WaitElementVisible(Driver, By.XPath(ShopPageProductsListing));
        }

        public void ClickCartMenu()
        {
            Driver.FindElement(By.XPath(CartMnu)).Click();
            WaitExtension.WaitElementVisible(Driver, By.XPath(ShopPageProductsListing));
        }

    }
}

