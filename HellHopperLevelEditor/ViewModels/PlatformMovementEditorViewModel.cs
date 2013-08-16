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
    public sealed class PlatformMovementEditorViewModel : PropertyChangedBase
    {
        public IEnumerable<PlatformMovementType> MovementTypes { get; private set; }

        public PlatformMovementEditorViewModel(RiseSectionData riseSectionData, EditorManager editorManager)
        {
            MovementTypes = Enum.GetValues(typeof(PlatformMovementType)).Cast<PlatformMovementType>();
        }
    }
}
