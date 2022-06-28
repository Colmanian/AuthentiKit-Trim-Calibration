namespace AuthentiKitTuningApp.Test.UI
{
    [TestClass]
    public class Run_Clean_App
    {
        [TestMethod]
        public void Open_App()
        {
            AuthenitKitTuningAppSession.Setup();
        }

        [ClassCleanup]
        public static void Close_App()
        {
            AuthenitKitTuningAppSession.TearDown();
        }
    }
}

