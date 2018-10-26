using OpenQA.Selenium;
using System.Collections.Generic;
using WebDriverForAvBY.PageObject;
using WebDriverForAvBY.Utilities;

namespace WebDriverForAvBY
{
    public class CarManager
    {
        private IWebDriver driver;
        private List<Car> carOptions;
        private List<InterestedCar> interestedCar = new List<InterestedCar>();
        private JSONDeSerializer jsonDeSerializer = new JSONDeSerializer();
        private MainPage mainPage;
        private CarSearchPage carSearchPage;
        private List<IWebElement> carsList = new List<IWebElement>();

        private string carsInformation = "//div[@class='listing-item-main']";
        private string nextPage = "//a[contains(text(), 'Следующая страница')]";
        private By page = By.ClassName("pages-arrows-link");
        private string countOfCarsLocator = "//a[@class='button button-primary button-block js-submit-search-link']";

        public CarManager(string file, IWebDriver driver)
        {
            carOptions = jsonDeSerializer.ReadJsonFile(file);
            this.driver = driver;
        }

        private int GetCarsCount()
        {
            string carsCount = string.Empty;
            string[] splitCarsCount = driver.FindElement(By.XPath(countOfCarsLocator)).Text.Split(':', ' ');
            for (int i = 0; i < splitCarsCount.Length; i++)
            {
                for (int j = 0; j < splitCarsCount[i].Length; j++)
                {
                    if (splitCarsCount[i][j] >= '0' || splitCarsCount[i][j] <= '9')
                    {
                        carsCount = splitCarsCount[i];
                    }
                } 
            }
            return int.Parse(carsCount);
        }

        public void SearchCar()
        {
            mainPage = new MainPage(driver);
            mainPage.ClickAdvancedSearch();
            carSearchPage = new CarSearchPage(driver);
            foreach (Car car in carOptions)
            {
                carSearchPage.SelectOptions(carSearchPage.Mark, car.Mark);
                carSearchPage.SelectOptions(carSearchPage.Model, car.Model);
                carSearchPage.SelectOptions(carSearchPage.YearFrom, car.YearFrom);
                carSearchPage.SelectOptions(carSearchPage.YearTo, car.YearTo);
                carSearchPage.SelectOptions(carSearchPage.Button, car.Transmission);
                carSearchPage.SelectOptions(carSearchPage.BodyType, car.BodyType);
                carSearchPage.SelectOptions(carSearchPage.Button, car.Fuel);
                carSearchPage.SelectOptions(carSearchPage.PriceFrom, car.PriceFrom);
                carSearchPage.SelectOptions(carSearchPage.PriceTo, car.PriceTo);
                carSearchPage.ClickFindAdsButton();
            }
        }

        public List<InterestedCar> GetCarsInformation()
        {
            int index = 0;
            int carsCount = GetCarsCount();
            do
            {
                index = driver.FindElements(By.XPath(carsInformation)).Count;
                for (int i = 1; i <= index; i++)
                {
                    interestedCar.Add(new CarsPage(driver).GetCarInformation(i));
                }
                if (interestedCar.Count < carsCount)
                {
                    driver.FindElement(By.XPath(nextPage)).Click();
                }
            }
            while (interestedCar.Count != carsCount);
           
            return interestedCar;
        }

        public void GetExcelFile()
        {
            ExcelFileCreator excelFileCreator = new ExcelFileCreator(interestedCar);
            excelFileCreator.CreateExcelFile();
        }
    }
}
