using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellHopperLevelEditor.Model
{
    public sealed class RiseSectionData
    {
        public int StepRange { get; set; }
        public int Difficulty { get; set; }
        public List<PlatformData> Platforms { get; private set; }

        public RiseSectionData()
        {
            StepRange = 40;
            Difficulty = 0;
            Platforms = new List<PlatformData>();
        }
    }
}
