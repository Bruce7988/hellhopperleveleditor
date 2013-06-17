using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HellHopperLevelEditor.Model;
using HellHopperLevelEditor.Model.DataAccess;

namespace HellHopperLevelEditor.ViewModels
{
    public sealed class LevelXmlViewModel : PropertyChangedBase
    {
        private string mLevelXml;
        public string LevelXml
        {
            get { return mLevelXml; }
            private set
            {
                mLevelXml = value;
                NotifyOfPropertyChange(() => LevelXml);
            }
        }

        private RiseSectionData mRiseSectionData;

        public LevelXmlViewModel(RiseSectionData riseSectionData)
        {
            mRiseSectionData = riseSectionData;
            mRiseSectionData.DataChanged += RiseSectionDataDataChanged;

            UpdateFromModel();
        }

        private void UpdateFromModel()
        {
            LevelXml = RiseSectionDataXmlWriter.Write(mRiseSectionData);
        }

        private void RiseSectionDataDataChanged(object sender, EventArgs e)
        {
            UpdateFromModel();
        }
    }
}
