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
            get { return mPlatformData.Offset * LevelConstants.OFFSET_WIDTH; }
        }

        public double Y
        {
            get { return mPlatformData.Step * LevelConstants.STEP_HEIGHT; }
        }

        private PlatformData mPlatformData;

        public PlatformWrapper(PlatformData platformData)
        {
            mPlatformData = platformData;
        }
    }
}
