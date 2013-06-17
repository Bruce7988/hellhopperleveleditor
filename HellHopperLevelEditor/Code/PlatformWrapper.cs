using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HellHopperLevelEditor.Model;

namespace HellHopperLevelEditor.Code
{
    public sealed class PlatformWrapper
    {
        public double X
        {
            get { return PlatformData.Offset * LevelConstants.OFFSET_WIDTH; }
        }

        public double Y
        {
            get { return PlatformData.Step * LevelConstants.STEP_HEIGHT; }
        }

        public PlatformData PlatformData { get; private set; }

        public PlatformWrapper(PlatformData platformData)
        {
            PlatformData = platformData;
        }
    }
}
