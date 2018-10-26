using OpenQA.Selenium;

namespace WebDriverForAvBY.PageObject
{
    public class MainPage
    {
        private IWebDriver driver;
        private IWebElement element;
        private readonly By advancedSearch = By.XPath("//span[contains(text(), 'Расширенный поиск')]");

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickAdvancedSearch()
        {
            element = driver.FindElement(advancedSearch);
            element.Click();
        }
    }
}
