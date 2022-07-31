using AuthentiKitTuningApp.Common.Model;
using System.Collections.ObjectModel;

namespace AuthentiKitTuningApp.Test.Common
{
    [TestClass]
    public class Create_Objects
    {
        [TestMethod]
        public void Create_MappingDTO()
        {
            MappingDTO mappingDTO = new();
            Assert.IsNotNull(mappingDTO);
        }

        [TestMethod]
        public void Create_CalibrationDTO()
        {
            CalibrationDTO calibrationDTO = new();
            Assert.IsNotNull (calibrationDTO);
        }

        [TestMethod]
        public void Create_Preset()
        {
            Preset preset = new();
            Assert.IsNotNull(preset);
        }

        [TestMethod]
        public void Create_InputAxis()
        {
            InputAxis inputAxis = new();
            Assert.IsNotNull(inputAxis);
        }

        [TestMethod]
        public void Create_InputButton()
        {
            InputButton inputButton = new();
            Assert.IsNotNull(inputButton);
        }

        [TestMethod]
        public void Create_MappingTypes()
        {
            int EXPECTED_NUMBER_OF_TYPES = 5;
            ObservableCollection<MappingType> mappingTypes = MappingType.GetMappingTypes();
            Assert.AreEqual(EXPECTED_NUMBER_OF_TYPES, mappingTypes.Count);    
        }

        [TestMethod]
        public void Create_OutputChannel()
        {
            OutputChannel outputChannel = new();
            Assert.IsNotNull(outputChannel);
        }
    }
}