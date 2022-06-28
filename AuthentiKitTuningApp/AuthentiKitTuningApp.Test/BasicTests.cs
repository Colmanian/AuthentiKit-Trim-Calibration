using AuthentiKitTuningApp.Common.Model;

namespace AuthentiKitTuningApp.Test
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void Create_MappingDTO()
        {
            MappingDTO mappingDTO = new MappingDTO();
            Assert.IsNotNull(mappingDTO);
        }
    }
}