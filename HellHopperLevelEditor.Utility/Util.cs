using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellHopperLevelEditor.Utility
{
    public static class Util
    {
        public static int LimitInt(int value, int min, int max)
        {
            return value <= min ? min : value >= max ? max : value;
        }

        public static double LimitDouble(double value, double min, double max)
        {
            return value <= min ? min : value >= max ? max : value;
        }
    }
}
