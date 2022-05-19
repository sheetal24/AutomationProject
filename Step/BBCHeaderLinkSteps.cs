using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using AutomationProject.Pages;
using AutomationProject.Base;

namespace AutomationProject.Step
{
    [Binding]
    [Scope(Tag = "BBCHeaderlink")]
    public class BBCHeaderLinkSteps : SetUp
    {
        public IWebDriver Browser;
        public BBCHeaderLinks header;
        [Given(@"I navigate to BBC")]
        public void GivenINavigateToBBC()
        {
            Browser = driver;
            header = new BBCHeaderLinks(Browser);
            header.NavigateToBBC();
        }
        
        [When(@"I click on (.*)")]
        public void WhenIClickOn(string link)
        {
            header.ClickLinks(link);
        }
        
        [Then(@"I can see (.*) page")]
        public void ThenICanSeePage(string link)
        {
            header.VerifyLinks(link);
        }
    }
}
