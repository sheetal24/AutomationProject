using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using FluentAssertions;

namespace AutomationProject.Pages
{
    public class BBCSignIn
    {
        public IWebDriver Driver;
        public BBCSignIn(IWebDriver browser)
        {
            Driver = browser;
            PageFactory.InitElements(Driver, this);
        }

        string ExpectedMessage = "Welcome to the BBC";

       [FindsBy(How = How.LinkText, Using = "Sign in")]
        public IWebElement SigninLink;        

        [FindsBy(How = How.Id, Using = "user-identifier-input")]
        public IWebElement Username;

        [FindsBy(How = How.Id, Using = "password-input")]
        public IWebElement Password;

        [FindsBy(How = How.Id, Using = "submit-button")]
        public IWebElement SignInButton;

        [FindsBy(How = How.CssSelector, Using = "#header-content>div:nth-child(3)>div>div>div>div>div")]
        public IWebElement WelcomeMessage;

        public void NavigateToBBC()
        {
            Driver.Navigate().GoToUrl("https://bbc.co.uk");

        }

        public IWebElement GetElementAndScrollTo(this IWebDriver driver, By by)
        {
            var js = (IJavaScriptExecutor)driver;
            try
            {
                var element = driver.FindElement(by);
                if (element.Location.Y > 200)
                {
                    js.ExecuteScript($"window.scrollTo({0}, {element.Location.Y - 200 })");
                }
                return element;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void ClickSigninLink()
        {
            SigninLink.Click();
        }

        public void UserDetails()
        {
            Username.SendKeys("sheetal_jn@hotmail.com");
            Password.SendKeys("Sheetal123@");
        }

        public void ClickSignButton()
        {
            SignInButton.Click();
        }

        public void VerifyLogin()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            WelcomeMessage.Text.Contains(ExpectedMessage).Should().BeTrue();
        }

    }
}
