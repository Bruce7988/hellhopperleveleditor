using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellHopperLevelEditor.Model
{
    public sealed class PlatformData
    {
        public int Id { get; set; }
        public int Step { get; set; }
        public int Offset { get; set; }
        public string Type { get; set; }
        public string MovementXml { get; set; }
        public string FeaturesXml { get; set; }

        public PlatformData(int id, int step, int offset, string type, string movementXml, string featuresXml)
        {
            Id = id;
            Step = step;
            Offset = offset;
            Type = type;
            MovementXml = movementXml;
            FeaturesXml = featuresXml;
        }
    }
}
