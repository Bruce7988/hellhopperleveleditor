using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellHopperLevelEditor.Model.Platforms
{
    public sealed class PlatformMovementData
    {
        public PlatformMovementType Type { get; set; }
        public Dictionary<string, string> Properties { get; set; }

        public PlatformMovementData(PlatformMovementType type, Dictionary<string, string> properties)
        {
            Type = type;
            Properties = properties;
        }
    }
}
