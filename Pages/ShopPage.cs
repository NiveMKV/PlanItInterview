using System;
using OpenQA.Selenium;

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
                product.FindElement(By.XPath(BuyBtn));
                noOfItems--;
            }
            
        }

        public decimal GetPriceOfProductInProductListing(string productName)
        {
            IWebElement product = Driver.FindElement(By.XPath(Product.Replace("PRODUCT_NAME", productName)));
            string priceText = product.FindElement(By.XPath(ProductPrice)).Text;
            return decimal.Parse(priceText.Replace("$", ""));
        }

        public int GetColumnIndex(string columnName)
        {
            IList<IWebElement> columnHdrs = Driver.FindElements(By.XPath(ColumnHeaders));
            int indexCount = 0;

            foreach(IWebElement columnHdr in columnHdrs)
            {
                indexCount++;
                if (columnHdr.Text == columnName) return indexCount;
            }
            return indexCount;
        }

        public decimal GetPriceOfProductInCheckoutTable(string productName)
        {
            int priceColIndex = GetColumnIndex("Price");
            IWebElement itemInTheTable = Driver.FindElement(By.XPath(ItemInTable.Replace("PRODUCT_NAME", productName)));
            string priceInString = itemInTheTable.FindElement(By.XPath($"./parent::tr//td[{priceColIndex}]")).Text;
            //return Int32.Parse(priceInString.Substring(1));
            return decimal.Parse(priceInString.Replace("$", ""));
        }

        public decimal GetSubTotalOfProductInCheckoutTable(string productName)
        {
            int priceColIndex = GetColumnIndex("Subtotal");
            IWebElement itemInTheTable = Driver.FindElement(By.XPath(ItemInTable.Replace("PRODUCT_NAME", productName)));
            string priceInString = itemInTheTable.FindElement(By.XPath($"./parent::tr//td[{priceColIndex}]")).Text;
            //return Int32.Parse(priceInString.Substring(1));
            return decimal.Parse(priceInString.Replace("$", ""));
        }

        public decimal GetProductTotal()
        {
            string productsTotInString = Driver.FindElement(By.XPath(ProductsTotal)).Text;
            //return Int32.Parse(productsTotInString.Replace("Total: ", ""));
            return decimal.Parse(productsTotInString.Replace("$", ""));
        }


    }
}

