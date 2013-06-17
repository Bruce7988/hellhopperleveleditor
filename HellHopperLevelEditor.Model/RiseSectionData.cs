using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HellHopperLevelEditor.Model.Util;

namespace HellHopperLevelEditor.Model
{
    public sealed class RiseSectionData
    {
        public int StepRange { get; set; }
        public int Difficulty { get; set; }
        public List<PlatformData> Platforms { get; set; }

        public string EnemiesXml { get; set; }

        public event EventHandler<ParameterizedEventArgs<RiseSectionUpdateSource>> DataChanged;
        private void RaiseDataChangedEvent(RiseSectionUpdateSource source)
        {
            var handler = DataChanged;
            if (handler != null)
            {
                handler(this, new ParameterizedEventArgs<RiseSectionUpdateSource>(source));
            }
        }

        public RiseSectionData()
        {
            StepRange = 40;
            Difficulty = 0;
            Platforms = new List<PlatformData>();
            EnemiesXml = "";
        }

        public void Update(RiseSectionUpdateSource source)
        {
            Platforms = Platforms.OrderBy(pd => pd.Step).ToList();
            RaiseDataChangedEvent(source);
        }
    }
}
