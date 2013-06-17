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
    public sealed class ToolbarViewModel : PropertyChangedBase
    {
        private int mStepRange;
        public int StepRange
        {
            get { return mStepRange; }
            set
            {
                SetStepRange(value, true);
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

        public ToolbarViewModel(RiseSectionData riseSectionData)
        {
            mRiseSectionData = riseSectionData;
            mRiseSectionData.DataChanged += RiseSectionDataDataChanged;

            UpdateFromModel();
        }
        
        private void SetStepRange(int value, bool triggerUpdateModel)
        {
            if (mStepRange != value)
            {
                mStepRange = value;
                NotifyOfPropertyChange(() => StepRange);
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
            SetStepRange(mRiseSectionData.StepRange, false);
            SetDifficulty(mRiseSectionData.Difficulty, false);
        }

        private void UpdateModel()
        {
            mRiseSectionData.StepRange = StepRange;
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
