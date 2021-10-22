using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WebAutomationTask.Drivers;
using WebAutomationTask.Pages;
using WebAutomationTask.Support;

namespace WebAutomationTask.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }

        [BeforeScenario]
        public void BeforeScenario(BrowserDriver browserDriver)
        {
            //TODO: implement logic that has to run before executing each scenario
            var homePage = new HomePage(browserDriver.Current);
        }

       

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            
        }
    }
}
