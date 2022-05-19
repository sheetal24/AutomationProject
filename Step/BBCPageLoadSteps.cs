using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using AutomationProject.Pages;
using AutomationProject.Base;

namespace AutomationProject.Step
{
    [Binding]
    [Scope(Tag = "BBCPageLoad")]
    public class BBCPageLoadSteps : SetUp
    {
        public IWebDriver Browser;
        public BBCPageLoad pageload;

        [Given(@"I navigate to BBC")]
        public void GivenINavigateToBBC()
        {
            Browser = driver;
            pageload = new BBCPageLoad(Browser);
            pageload.NavigateToBBC();
        }
        
        [Then(@"I am able to see BBC page loads")]
        public void ThenIAmAbleToSeeBBCPageLoads()
        {
            pageload.CheckUrl();
        }
    }
}
