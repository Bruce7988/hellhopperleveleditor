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
    public sealed class EditorViewModel : PropertyChangedBase
    {
        public RiseSectionPropertiesViewModel RiseSectionPropertiesViewModel { get; private set; }

        public EditorViewModel(RiseSectionData riseSectionData)
        {
            RiseSectionPropertiesViewModel = new RiseSectionPropertiesViewModel(riseSectionData);
        }
    }
}
