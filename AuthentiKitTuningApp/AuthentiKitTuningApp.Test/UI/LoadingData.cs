using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;

namespace AuthentiKitTuningApp.Test.UI
{
    [TestClass]
    public class LoadingData
    {
        // Note that you need to install and have running WinAppDriver for this Test Class to work.
        // See https://github.com/microsoft/WinAppDriver

        [TestMethod]
        public void App_Starts()
        {
            AuthenitKitTuningAppSession.Setup();

            Assert.AreEqual(false, AppHasThrownException());
            Assert.AreEqual(true, AppIsRunning());
            AuthenitKitTuningAppSession.TearDown();
        }

        [TestMethod]
        public void Clear_All_Mappings()
        {
            AuthenitKitTuningAppSession.Setup();

            var session = AuthenitKitTuningAppSession.session;
            if (session != null)
            {
                session.FindElementByName("New Mapping").Click();
                session.FindElementByName("menuStrip").SendKeys("%p");
                session.FindElementByName("Clear All").Click();
                session.FindElementByName("Delete").Click();
                session.FindElementByName("Delete").Click();
                session.FindElementByName("Delete").Click();
            }

            Assert.AreEqual(false, AppHasThrownException());
            Assert.AreEqual(true, AppIsRunning());
            AuthenitKitTuningAppSession.TearDown();
        }



        [TestMethod]
        public void Start_With_Non_Exsisting_Save_File()
        {
            const string TEMP_FILE_NAME = "TempTestFile.xml";
            AuthenitKitTuningAppSession.Setup();
            var session = AuthenitKitTuningAppSession.session;
            if (session != null)
            {
                // Create a new save file
                session.FindElementByName("menuStrip").SendKeys("%p");
                session.FindElementByName("Clear All").Click();
                session.FindElementByName("File").Click();
                session.FindElementByName("Save As").Click();
                Actions actions = new Actions(session);
                actions.SendKeys(TEMP_FILE_NAME).Perform();
                session.FindElementByName("Save").Click();
                actions = new Actions(session);
                actions.SendKeys("y{enter}").Perform();

                // Delete the save file from the filesystem
                session.FindElementByName("File").Click();
                session.FindElementByName("Load").Click();
                session.FindElementByName(TEMP_FILE_NAME).Click();
                actions = new Actions(session);
                actions.ContextClick().SendKeys("d").Perform();
                session.FindElementByName("Cancel").Click();
            }
            else
            {
                Assert.IsNotNull(session);
            }

            // Restart the app
            AuthenitKitTuningAppSession.TearDown();
            AuthenitKitTuningAppSession.Setup();

            // Verify all is well
            Assert.AreEqual(false, AppHasThrownException());
            Assert.AreEqual(true, AppIsRunning());
            AuthenitKitTuningAppSession.TearDown();
        }

        // Checks to see if any of the windows associated with the app are exeception boxes
        private bool AppHasThrownException()
        {
            var session = AuthenitKitTuningAppSession.session;
            if (session != null)
            {
                var allWindowHandles = session.WindowHandles;
                foreach (var windowHandle in allWindowHandles)
                {
                    session.SwitchTo().Window(windowHandle);
                    //Trace.WriteLine(i + ". " +session.Title);
                    if (session.Title != null)
                        if (session.Title.Contains("Error"))
                            return true;
                }
            }
            return false;
        }
        private bool AppIsRunning()
        {
            var session = AuthenitKitTuningAppSession.session;
            if (session != null)
            {
                var allWindowHandles = session.WindowHandles;
                foreach (var windowHandle in allWindowHandles)
                {
                    session.SwitchTo().Window(windowHandle);
                    //Trace.WriteLine(i + ". " +session.Title);
                    if (session.Title != null)
                        if (session.Title.Contains("AuthentiKit"))
                            return true;
                }
            }
            return false;
        }
    }
}

