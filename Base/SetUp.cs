using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace AutomationProject.Base
{
    public class SetUp
    {
        public IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();        
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
