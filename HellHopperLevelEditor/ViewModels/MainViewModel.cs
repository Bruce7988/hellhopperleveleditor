using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace HellHopperLevelEditor.ViewModels
{
    public sealed class MainViewModel : PropertyChangedBase
    {
        public LevelViewModel LevelViewModel { get; private set; }

        public MainViewModel()
        {
            LevelViewModel = new LevelViewModel();
        }
    }
}
