using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public static class WaitExtension
{
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(5);

    public static IWebElement WaitElementExists(IWebDriver driver, By by)
    {
        return new WebDriverWait(driver, Timeout).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
    }

    public static IWebElement WaitElementVisible(IWebDriver driver, By by)
    {
        return new WebDriverWait(driver, Timeout).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
    }

    public static IWebElement WaitElementToBeClickable(IWebDriver driver, By by)
    {
        return new WebDriverWait(driver, Timeout).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
    }

    /// <summary>
    /// Wait untill the element is invisible.
    /// </summary>
    /// <param name="driver">Driver instance</param>
    /// <param name="by">By locator</param>
    /// <param name="timeInSeconds">TimeSpan in seconds(Optional)</param>
    /// <returns></returns>
    public static bool WaitInvisibilityOfElement(IWebDriver driver, By by, TimeSpan? timeInSeconds = null)
    {
        TimeSpan timeout = timeInSeconds ?? Timeout;
        return new WebDriverWait(driver, timeout).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
    }


}


