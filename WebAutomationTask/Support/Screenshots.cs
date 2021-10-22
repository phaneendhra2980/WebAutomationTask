using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using WebAutomationTask.Drivers;

namespace WebAutomationTask.Support
{
    [Binding]
    class Screenshots
    {
        private readonly BrowserDriver _browserDriver;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;


        public Screenshots(ISpecFlowOutputHelper specFlowOutputHelper, BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [AfterStep()]
        public void MakeScreenshotAfterStep()
        {
            

            if (_browserDriver.Current is ITakesScreenshot takesScreenshot)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".png";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Png);
                _specFlowOutputHelper.AddAttachment(tempFileName);
                Console.WriteLine($"SCREENSHOT[ {tempFileName} ]SCREENSHOT");
            }
        }
    }
}
