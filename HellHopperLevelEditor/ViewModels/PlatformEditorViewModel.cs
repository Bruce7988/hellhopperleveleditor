using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HellHopperLevelEditor.Code.Editor;
using HellHopperLevelEditor.Model;
using HellHopperLevelEditor.Model.Platforms.Movement;

namespace HellHopperLevelEditor.ViewModels
{
    public sealed class PlatformEditorViewModel : PropertyChangedBase
    {
        public PlatformMovementEditorViewModel PlatformMovementEditorViewModel { get; private set; }
        public PlatformFeaturesEditorViewModel PlatformFeaturesEditorViewModel { get; private set; }

        public PlatformEditorViewModel(RiseSectionData riseSectionData, EditorManager editorManager)
        {
            PlatformMovementEditorViewModel = new PlatformMovementEditorViewModel(riseSectionData, editorManager);
            PlatformFeaturesEditorViewModel = new PlatformFeaturesEditorViewModel(riseSectionData, editorManager);
        }
    }
}
