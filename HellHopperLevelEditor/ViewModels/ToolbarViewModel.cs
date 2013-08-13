using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HellHopperLevelEditor.Model;
using HellHopperLevelEditor.Model.Util;

namespace HellHopperLevelEditor.ViewModels
{
    public sealed class ToolbarViewModel : PropertyChangedBase
    {
        public EditorViewModel EditorViewModel { get; private set; }
        public PropertyChangedBase PropertiesViewModel { get; private set; }

        public ToolbarViewModel(RiseSectionData riseSectionData)
        {
            EditorViewModel = new EditorViewModel(riseSectionData);
            PropertiesViewModel = new NoSelectionPropertiesViewModel();
        }
    }
}
