using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HellHopperLevelEditor.Model;
using HellHopperLevelEditor.Model.Util;

namespace HellHopperLevelEditor.ViewModels
{
    public sealed class RiseSectionPropertiesViewModel : PropertyChangedBase
    {
        private double mHeight;
        public double Height
        {
            get { return mHeight; }
            set
            {
                SetHeight(value, true);
            }
        }

        private int mDifficulty;
        public int Difficulty
        {
            get { return mDifficulty; }
            set
            {
                SetDifficulty(value, true);
            }
        }

        private RiseSectionData mRiseSectionData;

        public RiseSectionPropertiesViewModel(RiseSectionData riseSectionData)
        {
            mRiseSectionData = riseSectionData;
            mRiseSectionData.DataChanged += RiseSectionDataDataChanged;

            UpdateFromModel();
        }

        private void SetHeight(double value, bool triggerUpdateModel)
        {
            if (mHeight != value)
            {
                mHeight = value;
                NotifyOfPropertyChange(() => Height);
                if (triggerUpdateModel)
                {
                    UpdateModel();
                }
            }
        }

        private void SetDifficulty(int value, bool triggerUpdateModel)
        {
            if (mDifficulty != value)
            {
                mDifficulty = value;
                NotifyOfPropertyChange(() => Difficulty);
                if (triggerUpdateModel)
                {
                    UpdateModel();
                }
            }
        }

        private void UpdateFromModel()
        {
            SetHeight(mRiseSectionData.Height, false);
            SetDifficulty(mRiseSectionData.Difficulty, false);
        }

        private void UpdateModel()
        {
            mRiseSectionData.Height = Height;
            mRiseSectionData.Difficulty = Difficulty;
            mRiseSectionData.Update(RiseSectionUpdateSource.Toolbar);
        }

        private void RiseSectionDataDataChanged(object sender, ParameterizedEventArgs<RiseSectionUpdateSource> e)
        {
            if (e.Parameter != RiseSectionUpdateSource.Toolbar)
            {
                UpdateFromModel();
            }
        }
    }
}
