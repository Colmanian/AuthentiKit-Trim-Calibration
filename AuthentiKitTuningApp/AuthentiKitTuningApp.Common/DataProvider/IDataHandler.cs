using MappingManager.Common.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MappingManager.Common.DataProvider
{
    public interface IDataHandler
    {
        IEnumerable<MappingDTO> LoadMappings(ObservableCollection<InputButton> inputButtonsA, ObservableCollection<InputButton> inputButtonsB, ObservableCollection<InputAxis> inputAxes, ObservableCollection<OutputChannel> outputAxes, ObservableCollection<OutputChannel> outputButtons);
        void SaveMappings(IEnumerable<MappingDTO> mappings);
        void SaveMappings(IEnumerable<MappingDTO> mappings, string filePath);
        MappingDTO GetBlankMapping();
        IEnumerable<MappingDTO> GetDefaultMappings(Preset aircraft, ObservableCollection<InputButton> inputButtonsA, ObservableCollection<InputButton> inputButtonsB, ObservableCollection<OutputChannel> outputAxes, ObservableCollection<OutputChannel> outputButtons);
        string GetSaveFilePath();
        void SetSaveFilePath(string fileName);
        void SetRunOnStartup(bool runOnStartup);
    }
}
