using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace HellHopperLevelEditor.Code.Editor
{
    public sealed class EditorModeData : PropertyChangedBase
    {
        private const string EDITOR_MODE_IMAGE_FORMAT = GeneralConstants.RESOURCES_PATH + "EditorMode/{0}normal.png";

        public EditorMode EditorMode { get; private set; }

        public string ImageSource { get; private set; }

        private bool mIsActive;
        public bool IsActive
        {
            get { return mIsActive; }
            set
            {
                mIsActive = value;
                NotifyOfPropertyChange(() => IsActive);
            }
        }

        public EditorModeData(EditorMode editorMode)
        {
            EditorMode = editorMode;
            ImageSource = GetImageSource();
        }

        private string GetImageSource()
        {
            return string.Format(EDITOR_MODE_IMAGE_FORMAT, EditorMode.ToString().ToLowerInvariant());
        }
    }
}
