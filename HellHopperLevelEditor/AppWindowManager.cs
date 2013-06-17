using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace HellHopperLevelEditor
{
    public sealed class AppWindowManager : WindowManager
    {
        protected override Window CreateWindow(object rootModel, bool isDialog, object context, IDictionary<string, object> settings)
        {
            dynamic customSettings = new ExpandoObject();
            //customSettings.WindowStyle = WindowStyle.SingleBorderWindow;
            customSettings.ResizeMode = ResizeMode.NoResize;

            var window = base.CreateWindow(rootModel, isDialog, context, (IDictionary<string, object>)customSettings);

            return window;
        }
    }
}
