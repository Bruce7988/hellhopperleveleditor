using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace HellHopperLevelEditor.ViewModels
{
    [Export(typeof(AppViewModel))]
    public sealed class AppViewModel : PropertyChangedBase
    {
        public MainViewModel MainViewModel { get; private set; }

        private readonly IWindowManager mWindowManager;

        [ImportingConstructor]
        public AppViewModel(IWindowManager windowManager)
        {
            mWindowManager = windowManager;
            MainViewModel = new MainViewModel();
        }
    }
}
