using OpenQA.Selenium;
using WebDriverForAvBY.Core.BrowserTools;
using WebDriverForAvBY.Mail;

namespace WebDriverForAvBY
{
    public class EntryPoint
    {
        static void Main(string[] args)
        {
            string emailForMessage = "m.eroshevich97@gmail.com";
            Browser browser;
            IWebDriver driver;
            browser = Browser.Instance;
            driver = Browser.GetDriver();
            Browser.WindowMaximise();
            Browser.NavigateTo(Configuration.StartUrl);
            CarManager manager = new CarManager("../../CarOptions.json", driver);
            manager.SearchCar();
            manager.GetCarsInformation();
            manager.GetExcelFile();
            MailCreater mailCreater = new MailCreater(driver);
            mailCreater.NavigateToMailPage();
            mailCreater.CreateMessage(emailForMessage);
            Browser.Quit();
        }
    }
}
 