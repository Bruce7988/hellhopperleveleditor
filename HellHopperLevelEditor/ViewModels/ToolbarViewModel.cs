using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HellHopperLevelEditor.Code.Editor;
using HellHopperLevelEditor.Model;
using HellHopperLevelEditor.Model.Util;
using HellHopperLevelEditor.Utility;

namespace HellHopperLevelEditor.ViewModels
{
    public sealed class ToolbarViewModel : PropertyChangedBase
    {
        public EditorViewModel EditorViewModel { get; private set; }

        #region PropertiesViewModel
        private PropertyChangedBase mPropertiesViewModel;
        public PropertyChangedBase PropertiesViewModel
        {
            get { return mPropertiesViewModel; }
            private set
            {
                if (mPropertiesViewModel != value)
                {
                    mPropertiesViewModel = value;
                    NotifyOfPropertyChange(() => PropertiesViewModel);
                }
            }
        }
        #endregion

        private EditorManager mEditorManager;

        private Dictionary<Type, PropertyChangedBase> mPropertiesViewModels;

        public ToolbarViewModel(RiseSectionData riseSectionData, EditorManager editorManager)
        {
            mEditorManager = editorManager;
            mEditorManager.PropertyChanged += EditorManagerPropertyChanged;

            CreatePropertiesViewModels(riseSectionData);

            EditorViewModel = new EditorViewModel(riseSectionData, editorManager);
            PropertiesViewModel = new NoSelectionPropertiesViewModel();
        }

        private void CreatePropertiesViewModels(RiseSectionData riseSectionData)
        {
            mPropertiesViewModels = new Dictionary<Type, PropertyChangedBase>();
            mPropertiesViewModels.Add(typeof(NoSelectionPropertiesViewModel), new NoSelectionPropertiesViewModel());
            mPropertiesViewModels.Add(typeof(PlatformEditorViewModel), new PlatformEditorViewModel(riseSectionData, mEditorManager));
        }

        private void SelectPropertiesViewModel()
        {
            if (mEditorManager.SelectedPlatform != null)
            {
                PropertiesViewModel = mPropertiesViewModels[typeof(PlatformEditorViewModel)];
            }
            else
            {
                PropertiesViewModel = mPropertiesViewModels[typeof(NoSelectionPropertiesViewModel)];
            }
        }

        private void EditorManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Util.GetPropertyName(() => mEditorManager.SelectedPlatform))
            {
                SelectPropertiesViewModel();
            }
        }
    }
}
