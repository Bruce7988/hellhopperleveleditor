using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellHopperLevelEditor.Model.Platforms
{
    public sealed class PlatformData
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public PlatformType Type { get; set; }
        public PlatformMovementData MovementData { get; set; }
        public List<PlatformFeatureData> FeaturesData { get; set; }

        public PlatformData(int id, double x, double y, PlatformType type, PlatformMovementData movementData, List<PlatformFeatureData> featuresData)
        {
            Id = id;
            X = x;
            Y = y;
            Type = type;
            MovementData = movementData;
            FeaturesData = featuresData;
        }
    }
}
