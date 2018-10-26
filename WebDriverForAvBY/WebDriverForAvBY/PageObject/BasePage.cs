using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverForAvBY.Core.BrowserTools;

namespace WebDriverForAvBY.PageObject
{
    public class BasePage
    {
        private IWebDriver driver;
        private const int WaitForVisible = 15;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitElementToBeClickable(By locator)
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(WaitForVisible))
                .Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
