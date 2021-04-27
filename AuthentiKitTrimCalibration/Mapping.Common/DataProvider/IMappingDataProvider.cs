using MappingManager.Common.Model;
using System.Collections.Generic;

namespace MappingManager.Common.DataProvider
{
  public interface IMappingDataProvider
  {
    IEnumerable<Mapping> LoadMappings();

    void ApplyMapping(Mapping mapping);

    IEnumerable<InputDevice> LoadDevices();
  }
}
