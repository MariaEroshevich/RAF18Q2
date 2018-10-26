using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverForAvBY.Core.BrowserTools;

namespace WebDriverForAvBY.PageObject
{
    public class CarSearchPage : BasePage
    {
        private IWebDriver driver;        

        private readonly string _mark = "//select[@name='brand_id[0]']//option[contains(text(), '{0}')]";
        private readonly string _model = "//select[@name='model_id[0]']//option[contains(text(), '{0}')]";
        private readonly string _yearFrom = "//select[@name='year_from']//option[contains(text(), '{0}')]";
        private readonly string _yearTo = "//select[@name='year_to']//option[contains(text(), '{0}')]";
        private readonly string _optionsButton = "//span[@class='button button-stylish'][contains(text(), '{0}')]";
        private readonly string _bodyType = "//select[@name='body_id']//option[contains(text(), '{0}')]";
        private readonly string _priceFrom = "//select[@name='price_from']//option[contains(text(), '{0}')]";
        private readonly string _priceTo = "//select[@name='price_to']//option[contains(text(), '{0}')]";
        private readonly string findAdsButton = "//div[@class='b-search-control']//input[@type='submit']";

        public string Mark { get { return _mark; } }
        public string Model { get { return _model; } }
        public string YearFrom { get { return _yearFrom; } }
        public string YearTo { get { return _yearTo; } }
        public string Button { get { return _optionsButton; } }
        public string BodyType { get { return _bodyType; } }
        public string PriceFrom { get { return _priceFrom; } }
        public string PriceTo { get { return _priceTo; } }

        public CarSearchPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void SelectOptions(string xPath, object option)
        {
            By locator = By.XPath(String.Format(xPath, option));
            WaitElementToBeClickable(locator);
            driver.FindElement(locator).Click();
        }

        public void ClickFindAdsButton()
        {
            By locator = By.XPath(String.Format(findAdsButton));
            WaitElementToBeClickable(locator);
            driver.FindElement(locator).Click();
        }
    }
}
