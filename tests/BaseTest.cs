using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System.Net;

namespace alttrashcat_tests_csharp.tests
{
    public class BaseTest
    {
       AndroidDriver<AndroidElement> appiumDriver;
       //IOSDriver<IOSElement> appiumDriver;

        [OneTimeSetUp]
        public void SetupAppium()
        {
        

            AppiumOptions capabilities = new AppiumOptions();
           capabilities.AddAdditionalCapability("device", "Android");
           //capabilities.AddAdditionalCapability("device", "iOS");

           //capabilities.AddAdditionalCapability("deviceName", "12271JEC211509");
            capabilities.AddAdditionalCapability("platformName", "Android");
            //capabilities.AddAdditionalCapability("platformName", "iOS");
            capabilities.AddAdditionalCapability("appActivity", "com.unity3d.player.UnityPlayerActivity");
            //capabilities.AddAdditionalCapability("appPackage", "fi.altom.trashcat");
            //capabilities.AddAdditionalCapability("autoAcceptAlerts" ,true);


            Console.WriteLine("WebDriver request initiated. Waiting for response, this typically takes 2-3 mins");
            var appiumUri = new Uri("http://localhost:4723/wd/hub");
            //appiumDriver = new IOSDriver<IOSElement>(appiumUri, capabilities, TimeSpan.FromSeconds(300));
            appiumDriver = new AndroidDriver<AndroidElement>(appiumUri, capabilities, TimeSpan.FromSeconds(300));
            Thread.Sleep(30000);
            Console.WriteLine("Appium driver started");
        }

        [OneTimeTearDown]
        public void DisposeAppium()
        {
            Console.WriteLine("Ending");
            appiumDriver.Quit();
        }

    }
}