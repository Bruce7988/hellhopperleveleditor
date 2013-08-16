using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HellHopperLevelEditor.Model.Platforms.Features;
using HellHopperLevelEditor.Model.Platforms.Movement;

namespace HellHopperLevelEditor.Model.Platforms
{
    public sealed class PlatformData
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public PlatformType Type { get; set; }
        public PlatformMovementBaseData MovementData { get; set; }
        public List<PlatformFeatureBaseData> FeaturesData { get; set; }

        public PlatformData(int id, double x, double y, PlatformType type, PlatformMovementBaseData movementData, List<PlatformFeatureBaseData> featuresData)
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
