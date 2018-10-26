using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverForAvBY.Core.BrowserTools;

namespace WebDriverForAvBY.Mail
{
    public class BasePage
    {
        private IWebDriver driver;
        private const int WaitForVisible = 15;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitElementToBeVisible(By locator)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(WaitForVisible))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
