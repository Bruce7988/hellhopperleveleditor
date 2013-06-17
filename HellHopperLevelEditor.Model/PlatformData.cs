using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellHopperLevelEditor.Model
{
    public sealed class PlatformData
    {
        public int Step { get; set; }
        public int Offset { get; set; }
        public string Type { get; set; }

        public PlatformData(int step, int offset, string type)
        {
            Step = step;
            Offset = offset;
            Type = type;
        }
    }
}
