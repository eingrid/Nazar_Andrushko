using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nazzar.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IWebDriver Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            _scenarioContext.Set(driver, "WebDriver");
                
            return driver;
        }
    }
}
