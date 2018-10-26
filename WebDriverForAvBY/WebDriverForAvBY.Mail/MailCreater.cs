using OpenQA.Selenium;
using System;
using System.IO;

namespace WebDriverForAvBY.Mail
{
    public class MailCreater
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private MailPage mailPage;

        private readonly string email = "eroshevichmaria41@gmail.com";
        private readonly string password = "QvJUG2GH";
        //private string filePath = Directory.GetCurrentDirectory() + "Cars.xlsx";
        private string filePath = @"C:\Users\Maryia_Yerashevich\EPAM\RAF18Q2\WebDriverForAvBY\WebDriverForAvBY\bin\Debug\Cars.xlsx";

        public MailCreater(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToMailPage()
        {
            loginPage = new LoginPage(driver);
            loginPage.NavigateToMailPage();
            loginPage.LogIn(email, password);
        }

        public void CreateMessage(string email)
        {
            mailPage = new MailPage(driver);
            mailPage.CreateMessage(email, filePath);
        }
    }
}
