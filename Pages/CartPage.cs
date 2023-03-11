using System;
using OpenQA.Selenium;

namespace PlanItTestProject.Pages
{
	public class CartPage
	{
        #region Fields
        private IWebDriver Driver;
        private string ColumnHeaders = ".//table[contains(@class,'cart-items')]/thead//th";
        private string ItemInTable = ".//table[contains(@class,'cart-items')]/tbody//td[normalize-space(text())='PRODUCT_NAME']";
        private string ProductsTotal = ".//table[contains(@class,'cart-items')]/tfoot//*[contains(@class,'total')]";

        #endregion

        public CartPage()
		{
            //paramterless constrctor.
		}

        public CartPage(IWebDriver driver)
        {
            Driver = driver;
        }

        #region Methods
        
        public int GetColumnIndex(string columnName)
        {
            WaitExtension.WaitElementVisible(Driver, By.XPath(ColumnHeaders));
            IList<IWebElement> columnHdrs = Driver.FindElements(By.XPath(ColumnHeaders));
            int indexCount = 0;

            foreach (IWebElement columnHdr in columnHdrs)
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
            return decimal.Parse(productsTotInString.Replace("Total: ", ""));
        }
        #endregion
    }
}

