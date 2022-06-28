using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using OpenQA.Selenium.Appium;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace AuthentiKitTuningApp.Test.UI
{
    internal class AuthenitKitTuningAppSession
    {
        private const string WindowsApplicationDriverURL = "http://127.0.0.1:4723";
        protected static WindowsDriver<WindowsElement>? session;
        protected static RemoteTouchScreen? touchScreen;

        public static void Setup([CallerFilePath] string sourceFilePath = "")
        {
            if ((session == null) || (touchScreen == null))
            {
                var path = Path.GetDirectoryName(sourceFilePath);
                if (path != null)
                {
                    Uri pathOfThisFile = new(path, UriKind.Absolute);
                    Uri relativePathToDebugExe = new(@"..\..\AuthentiKitTuningApp\AuthentiKitTuningApp\bin\x86\Debug\net6.0-windows\AuthentiKitTuningApp.exe", UriKind.Relative);
                    string debugExePath = new Uri(pathOfThisFile, relativePathToDebugExe).ToString();
                    //Trace.WriteLine("");

                    TearDown();

                    // Create a new session to bring up the Alarms & Clock application
                    var appiumOptions = new AppiumOptions();
                    appiumOptions.AddAdditionalCapability("app", debugExePath);
                    session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverURL), appiumOptions);
                    Assert.IsNotNull(session);
                    Assert.IsNotNull(session.SessionId);

                    // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                    session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);

                    // Initialize touch screen object
                    touchScreen = new RemoteTouchScreen(session);
                    Assert.IsNotNull(touchScreen);
                }
            }
        }

        public static void TearDown()
        {
            // Cleanup RemoteTouchScreen object if initialized
            touchScreen = null;

            // Close the application and delete the session
            if (session != null)
            {
                var allWindowHandles = session.WindowHandles;
                foreach (var windowHandle in allWindowHandles)
                {
                    session.SwitchTo().Window(windowHandle);
                    session.Quit();
                }
                session = null;
            }
        }
    }
}
