using OpenQA.Selenium;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace WebDriverForAvBY.Mail
{
    public class MailPage : BasePage
    {
        private IWebDriver driver;
        private By writeButton = By.XPath("//div[contains(text(), 'Написать')]");
        private By toField = By.XPath("//textarea[@name='to']");
        private By attachFileButton = By.XPath("//div[@id=':ap']");
        private By addButton = By.XPath("//div[contains(text(), 'Добавить')]");
        private By sendButton = By.XPath("//div[contains(text(), 'Отправить')]");

        public MailPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void CreateMessage(string email, string file)
        {
            //SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
            //client.Credentials = new NetworkCredential();
            //MailMessage message = new MailMessage();
            //Attachment attach = new Attachment(file, MediaTypeNames.Application.Octet);
            //message.Attachments.Add(attach);
            driver.FindElement(writeButton).Click();
            WaitElementToBeVisible(toField);
            driver.FindElement(toField).SendKeys(email);
            driver.FindElement(attachFileButton).Click();
            WaitElementToBeVisible(sendButton);
            driver.FindElement(sendButton).Click();
            //client.Send(message);
        }
    }
}

