using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HellHopperLevelEditor.Model;
using HellHopperLevelEditor.Model.DataAccess;
using HellHopperLevelEditor.Model.Util;

namespace HellHopperLevelEditor.ViewModels
{
    public sealed class LevelXmlViewModel : PropertyChangedBase
    {
        private string mLevelXml;
        public string LevelXml
        {
            get { return mLevelXml; }
            set
            {
                SetLevelXml(value, true);
            }
        }

        private RiseSectionData mRiseSectionData;

        public LevelXmlViewModel(RiseSectionData riseSectionData)
        {
            mRiseSectionData = riseSectionData;
            mRiseSectionData.DataChanged += RiseSectionDataDataChanged;

            UpdateFromModel();
        }

        private void SetLevelXml(string value, bool triggerUpdateModel)
        {
            mLevelXml = value;
            NotifyOfPropertyChange(() => LevelXml);
            if (triggerUpdateModel)
            {
                UpdateModel();
            }
        }

        private void UpdateFromModel()
        {
            SetLevelXml(RiseSectionDataXmlWriter.Write(mRiseSectionData), false);
        }

        private void UpdateModel()
        {
            mRiseSectionData.Update(RiseSectionUpdateSource.LevelXml);
        }

        private void RiseSectionDataDataChanged(object sender, ParameterizedEventArgs<RiseSectionUpdateSource> e)
        {
            if (e.Parameter != RiseSectionUpdateSource.LevelXml)
            {
                UpdateFromModel();
            }
        }
    }
}
