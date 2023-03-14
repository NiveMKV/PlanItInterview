using System;
using OpenQA.Selenium;
using NUnit.Framework;

namespace PlanItTestProject.Pages
{
	public class ShopPage
	{
        #region Fields
        private IWebDriver Driver;
        private string ShopPageProductsListing = ".//*[contains(@class,'products')]/ul";
        private string Product = ".//*[contains(@class,'products')]/ul//li//h4[contains(text(),'PRODUCT_NAME')]";
        private string ProductPrice = "./parent::div//*[contains(@class, 'product-price')]";
        private string BuyBtn = "./parent::div//a";
        private string ColumnHeaders = ".//table[contains(@class,'cart-items')]/thead//th";
        private string ItemInTable = ".//table[contains(@class,'cart-items')]/tbody//td[normalize-space(text())='PRODUCT_NAME']";
        private string ProductsTotal = ".//table[contains(@class,'cart-items')]/tfoot//*[contains(@class,'total')]";
        #endregion


        public ShopPage()
		{
            //parameterless constructor
		}

        public ShopPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void AddItemToCartByClickingBuyButton(string productName, int noOfItems = 1)
        {
            IWebElement product = Driver.FindElement(By.XPath(Product.Replace("PRODUCT_NAME", productName)));
            while (noOfItems != 0)
            {
                product.FindElement(By.XPath(BuyBtn)).Click();
                noOfItems--;
            }
            
        }

        public decimal GetPriceOfProductInProductListing(string productName)
        {
            IWebElement product = Driver.FindElement(By.XPath(Product.Replace("PRODUCT_NAME", productName)));
            string priceText = product.FindElement(By.XPath(ProductPrice)).Text;
            return decimal.Parse(priceText.Replace("$", ""));
        }

    }
}

