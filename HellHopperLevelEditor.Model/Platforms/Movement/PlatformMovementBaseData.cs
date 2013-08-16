using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellHopperLevelEditor.Model.Platforms.Movement
{
    public sealed class PlatformMovementBaseData
    {
        public PlatformMovementType Type { get; set; }
        public Dictionary<string, string> Properties { get; set; }

        public PlatformMovementBaseData(PlatformMovementType type, Dictionary<string, string> properties)
        {
            Type = type;
            Properties = properties;
        }
    }
}
