using MappingManager.Common.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MappingManager.Common.DataProvider
{
    public interface IDataHandler
    {
        IEnumerable<MappingDTO> LoadMappings(ObservableCollection<InputButton> inputButtonsA, ObservableCollection<InputButton> inputButtonsB, ObservableCollection<InputAxis> inputAxes,
            ObservableCollection<OutputChannel> outputAxes, ObservableCollection<OutputChannel> outputButtonsA, ObservableCollection<OutputChannel> outputButtonsB);
        void SaveMappings(IEnumerable<MappingDTO> mappings, ObservableCollection<InputAxis> inputAxes);
        void SaveMappings(IEnumerable<MappingDTO> mappings, string filePath, ObservableCollection<InputAxis> inputAxes);
        MappingDTO GetBlankMapping();
        IEnumerable<MappingDTO> GetDefaultMappings(Preset aircraft, ObservableCollection<InputButton> inputButtonsA, ObservableCollection<InputButton> inputButtonsB,
            ObservableCollection<InputAxis> inputAxes, ObservableCollection<OutputChannel> outputAxes, ObservableCollection<OutputChannel> outputButtonsA, ObservableCollection<OutputChannel> outputButtonsB);
        string GetSaveFilePath();
        string GetLoadDirectory();
        void SetSaveFilePath(string fileName);
        void SetRunOnStartup(bool runOnStartup);
        bool GetRunOnStartup();
        bool GetPersistCalibration();
        void SetPersistCalibration(bool persist);
        bool GetStartAllOnOpen();
        void SetStartAllOnOpen(bool startAllOnOpen);
    }
}
