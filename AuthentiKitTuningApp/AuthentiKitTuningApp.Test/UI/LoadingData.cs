using System.Diagnostics;

namespace AuthentiKitTuningApp.Test.UI
{
    [TestClass]
    public class LoadingData
    {
        [TestMethod]
        public void Open_App()
        {
            // Note that you need to install and have running WinAppDriver for this Test Class to work.
            // See https://github.com/microsoft/WinAppDriver
            AuthenitKitTuningAppSession.Setup();
            Assert.AreEqual(false, AppHasThrownException());
        }

        [ClassCleanup]
        public static void Close_App()
        {
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
                        if(session.Title.Contains("Error"))
                            return true;
                }
            }
            return false;
        }
    }
}

