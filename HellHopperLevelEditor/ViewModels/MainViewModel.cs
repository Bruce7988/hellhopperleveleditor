using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HellHopperLevelEditor.Model;

namespace HellHopperLevelEditor.ViewModels
{
    public sealed class MainViewModel : PropertyChangedBase
    {
        public LevelViewModel LevelViewModel { get; private set; }
        public LevelXmlViewModel LevelXmlViewModel { get; private set; }

        public MainViewModel()
        {
            RiseSectionData riseSectionData = new RiseSectionData();

            LevelViewModel = new LevelViewModel(riseSectionData);
            LevelXmlViewModel = new LevelXmlViewModel(riseSectionData);
        }
    }
}
