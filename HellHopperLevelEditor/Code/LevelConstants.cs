using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellHopperLevelEditor.Code
{
    public static class LevelConstants
    {
        public const double STEP_HEIGHT = 40.0;
        public const double STEP_GRID_HEIGHT = STEP_HEIGHT / 2.0;
        public const double OFFSET_WIDTH = 10.0;

        public const int PLATFORM_WIDTH_OFFSETS = 8;

        public const double PLATFORM_WIDTH = PLATFORM_WIDTH_OFFSETS * OFFSET_WIDTH;
        public const double PLATFORM_HEIGHT = 20.0;

        public const int LEVEL_WIDTH_OFFSETS = 45;
        public const int MAX_PLATFORM_OFFSET = LEVEL_WIDTH_OFFSETS - PLATFORM_WIDTH_OFFSETS;
    }
}
