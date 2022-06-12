using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using FluentAssertions;
//added extra line to test1

namespace AutomationProject.Pages
{
    public class BBCHeaderLinks
    {
       public IWebDriver Driver;
       public string url = "https://www.bbc.co.uk";
       public BBCHeaderLinks(IWebDriver browser)
       {
          Driver = browser;
          PageFactory.InitElements(Driver, this);
       }
        public void NavigateToBBC()
       {
          Driver.Navigate().GoToUrl("https://bbc.co.uk");
       }
        [FindsBy(How = How.LinkText, Using = "News")]
        public IWebElement NewsLink;
        [FindsBy(How = How.LinkText, Using = "Sport")]
        public IWebElement SportLink;
        [FindsBy(How = How.LinkText, Using = "Weather")]
        public IWebElement WeatherLink;

        string NewsUrl = "https://www.bbc.co.uk/news";
        string SportUrl = "https://www.bbc.co.uk/sport";
        string WeatherUrl = "https://www.bbc.co.uk/weather";

        public void ClickLinks(string link)
        {
            switch(link)
            {
                case "News": 
                    NewsLink.Click();
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                    break;
                case "Sport": SportLink.Click();
                    break;
                case "Weather": WeatherLink.Click();
                    break;
                default: Console.WriteLine("No link match");
                    break;
            }
        }
       
        public void VerifyLinks(string link)
        {
            switch (link)
            {
                case "News":
                    Driver.Url.Contains(NewsUrl).Should().BeTrue();
                    break;
                case "Sport":
                    Driver.Url.Contains(SportUrl).Should().BeTrue();
                    break;
                case "Weather":
                    Driver.Url.Contains(WeatherUrl).Should().BeTrue();
                    break;
               default:
                    Console.WriteLine("No link match");
                    break;
            }
        }

    }
}
