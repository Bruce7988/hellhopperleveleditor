using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HellHopperLevelEditor.Code.Editor;

namespace HellHopperLevelEditor.ViewModels
{
    public sealed class EditorModeViewModel : PropertyChangedBase
    {
        private EditorManager mEditorManager;

        public List<EditorModeData> EditorModes { get; private set; }

        private bool mIsEditorModesChanging;

        public EditorModeViewModel(EditorManager editorManager)
        {
            mEditorManager = editorManager;

            EditorModes = Enum.GetValues(typeof(EditorMode)).Cast<EditorMode>().Select(em => new EditorModeData(em)).ToList();

            foreach (var editorMode in EditorModes)
            {
                if (editorMode.EditorMode == mEditorManager.EditorMode)
                {
                    editorMode.IsActive = true;
                }
                editorMode.PropertyChanged += EditorModePropertyChanged;
            }

            mIsEditorModesChanging = false;
        }

        private void EditorModePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (mIsEditorModesChanging)
            {
                return;
            }

            mIsEditorModesChanging = true;

            EditorModeData changedEditorModeData = (EditorModeData)sender;
            if (!changedEditorModeData.IsActive)
            {
                changedEditorModeData.IsActive = true;
            }
            else
            {
                foreach (var editorModeData in EditorModes)
                {
                    if (editorModeData != changedEditorModeData)
                    {
                        editorModeData.IsActive = false;
                    }
                }
            }

            mEditorManager.EditorMode = EditorModes.First(em => em.IsActive).EditorMode;

            mIsEditorModesChanging = false;
        }
    }
}
