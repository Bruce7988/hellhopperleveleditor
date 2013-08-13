using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellHopperLevelEditor.Model.Platforms
{
    public sealed class PlatformFeatureData
    {
        public PlatformFeatureType Type { get; set; }
        public Dictionary<string, string> Properties { get; set; }

        public PlatformFeatureData(PlatformFeatureType type, Dictionary<string, string> properties)
        {
            Type = type;
            Properties = properties;
        }
    }
}
