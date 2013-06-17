using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellHopperLevelEditor.Model.Util
{
    public sealed class ParameterizedEventArgs<T> : EventArgs
    {
        public T Parameter { get; private set; }

        public ParameterizedEventArgs(T parameter)
        {
            Parameter = parameter;
        }
    }
}
