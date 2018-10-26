using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebDriverForAvBY.PageObject
{
    public class CarsPage : BasePage
    {
        private IWebDriver driver;
        private List<InterestedCar> cars = new List<InterestedCar>();
        private InterestedCar car;

        private string carsInformation = "(//div[@class='listing-item-main'])[{0}]";
        private string markAndModel = "(//div[@class='listing-item-title'])[{0}]";
        private string year = "(//div[@class='listing-item-price']//span[contains(text(), '')])[{0}]";
        private string price = "(//div[@class='listing-item-price']//strong[contains(text(), '')])[{0}]";
        private string city = "(//p[@class='listing-item-location'])[{0}]";
        private string description = "(//div[@class='listing-item-desc'])[{0}]";
        private string ownerDiscription = "(//div[@class='listing-item-message-in'])[{0}]";
        private string reference = "(//div[@class='listing-item-image-in'])[{0}]";
        private string ownerDiscriptionOnCarPage = "(//div[@class='card-description js-card-description'])[{0}]";

        public CarsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private string GetOwnerDescription(int i)
        {
            string carInformation = driver.FindElement(By.XPath(string.Format(carsInformation, i))).Text;
            string ownerDiscriptionText = driver.FindElement(By.XPath(string.Format(ownerDiscription, i))).Text;
            if (carInformation.Contains(ownerDiscriptionText))
            {
                car.OwnerDiscription = ownerDiscriptionText;
            }
            else
            {
                driver.FindElement(By.XPath(string.Format(markAndModel, i))).Click();
                car.OwnerDiscription = driver.FindElement(By.XPath(string.Format(ownerDiscriptionOnCarPage, i))).Text;
                driver.Navigate().Back();
            }
            return car.OwnerDiscription;
        }

        public InterestedCar GetCarInformation(int i)
        {
            car = new InterestedCar();
            car.MarkAndModel = driver.FindElement(By.XPath(string.Format(markAndModel, i))).Text;
            car.MarkAndModel = driver.FindElement(By.XPath(string.Format(markAndModel, i))).Text;
            car.Year = driver.FindElement(By.XPath(string.Format(year, i))).Text;
            car.Price = driver.FindElement(By.XPath(string.Format(price, i))).Text;
            car.City = driver.FindElement(By.XPath(string.Format(city, i))).Text;
            car.Description = driver.FindElement(By.XPath(string.Format(description, i))).Text;
            //car.OwnerDiscription = GetOwnerDescription(i);
            car.Reference = driver.FindElement(By.XPath(string.Format(reference, i))).GetAttribute("href");

            return car;
        }
    }
}
