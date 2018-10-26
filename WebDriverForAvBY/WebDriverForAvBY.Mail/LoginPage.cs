using OpenQA.Selenium;

namespace WebDriverForAvBY.Mail
{
    public class LoginPage : BasePage
    {
        private IWebDriver driver;
        private string url = "https://accounts.google.com/";
        private By changeAccount = By.XPath("//p[contains(text(), 'Сменить аккаунт')]");
        private By emailField = By.XPath("//input[@type='email']");
        private By next = By.XPath("//span[contains(text(), 'Далее')]");
        private By passwordField = By.XPath("//input[@type='password']");
        private By mailButton = By.ClassName("WaidBe");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void NavigateToMailPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void LogIn(string email, string password)
        {
            WaitElementToBeVisible(emailField);
            driver.FindElement(emailField).SendKeys(email);
            driver.FindElement(next).Click();
            WaitElementToBeVisible(passwordField);
            driver.FindElement(passwordField).SendKeys(password);
            driver.FindElement(next).Click();
            WaitElementToBeVisible(mailButton);
            driver.FindElement(mailButton).Click();
        }
    }
}
