using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellHopperLevelEditor.Model.Platforms.Features
{
    public sealed class PlatformFeatureBaseData
    {
        public PlatformFeatureType Type { get; set; }
        public Dictionary<string, string> Properties { get; set; }

        public PlatformFeatureBaseData(PlatformFeatureType type, Dictionary<string, string> properties)
        {
            Type = type;
            Properties = properties;
        }
    }
}
