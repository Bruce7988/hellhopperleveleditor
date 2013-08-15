using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace HellHopperLevelEditor.Code.Editor
{
    public sealed class EditorManager : PropertyChangedBase
    {
        private EditorMode mEditorMode;
        public EditorMode EditorMode
        {
            get { return mEditorMode; }
            set
            {
                if (mEditorMode != value)
                {
                    mEditorMode = value;
                    NotifyOfPropertyChange(() => EditorMode);
                }
            }
        }

        private PlatformWrapper mSelectedPlatform;
        public PlatformWrapper SelectedPlatform
        {
            get { return mSelectedPlatform; }
            set
            {
                if (mSelectedPlatform != value)
                {
                    mSelectedPlatform = value;
                    NotifyOfPropertyChange(() => SelectedPlatform);
                }
            }
        }

        public EditorManager()
        {
            EditorMode = EditorMode.Select;
        }
    }
}
