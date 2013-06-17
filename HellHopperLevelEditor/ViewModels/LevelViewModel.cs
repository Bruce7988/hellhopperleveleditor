using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using HellHopperLevelEditor.Code;
using HellHopperLevelEditor.Model;

namespace HellHopperLevelEditor.ViewModels
{
    public sealed class LevelViewModel : PropertyChangedBase
    {
        private int mStepRange;
        public int StepRange
        {
            get { return mStepRange; }
            set
            {
                if (mStepRange != value)
                {
                    mStepRange = value;
                    NotifyOfPropertyChange(() => StepRange);
                    NotifyOfPropertyChange(() => Height);
                    GenerateGridPoints();
                }
            }
        }

        private int mDifficulty;
        public int Difficulty
        {
            get { return mDifficulty; }
            set
            {
                mDifficulty = value;
                NotifyOfPropertyChange(() => Difficulty);
            }
        }

        private List<PlatformWrapper> mPlatforms;
        public List<PlatformWrapper> Platforms
        {
            get { return mPlatforms; }
            private set
            {
                mPlatforms = value;
                NotifyOfPropertyChange(() => Platforms);
            }
        }

        public double Height
        {
            get { return StepRange * LevelConstants.STEP_HEIGHT; }
        }

        public List<Point> GridPoints { get; private set; }

        private RiseSectionData mRiseSectionData;

        public LevelViewModel()
        {
            mRiseSectionData = new RiseSectionData();
            UpdateFromModel();
        }

        public void MouseDown(Point position)
        {
            position.Y = Height - position.Y;
            for (int i = 0; i < Platforms.Count; i++)
            {
                PlatformWrapper platform = Platforms[i];
                if (platform.X <= position.X && position.X <= platform.X + LevelConstants.PLATFORM_WIDTH &&
                    platform.Y <= position.Y && position.Y <= platform.Y + LevelConstants.PLATFORM_HEIGHT)
                {
                    mRiseSectionData.Platforms.RemoveAt(i);
                    UpdateFromModel();
                    return;
                }
            }

            double stepFraction = position.Y / LevelConstants.STEP_HEIGHT;
            double offsetFraction = position.X / LevelConstants.OFFSET_WIDTH;

            int step = (int)stepFraction;
            int offset = (int)offsetFraction;

            if (CanPlacePlatform(stepFraction, step, offset))
            {
                mRiseSectionData.Platforms.Add(new PlatformData(step, offset, "normal"));
                UpdateFromModel();
            }
        }

        private bool CanPlacePlatform(double stepFraction, int step, int offset)
        {
            if (stepFraction % 1.0 <= 0.5 &&
                0 <= step && step < StepRange &&
                0 <= offset && offset <= LevelConstants.MAX_PLATFORM_OFFSET)
            {
                foreach (PlatformData platform in mRiseSectionData.Platforms)
                {
                    if (platform.Step == step &&
                        offset > platform.Offset - LevelConstants.PLATFORM_WIDTH_OFFSETS &&
                        offset < platform.Offset + LevelConstants.PLATFORM_WIDTH_OFFSETS)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateFromModel()
        {
            StepRange = mRiseSectionData.StepRange;
            Difficulty = mRiseSectionData.Difficulty;
            Platforms = mRiseSectionData.Platforms.Select(pd => new PlatformWrapper(pd)).ToList();
        }

        private void GenerateGridPoints()
        {
            GridPoints = new List<Point>();
            for (int i = 0; i < StepRange; i++)
            {
                for (int j = 0; j < LevelConstants.LEVEL_WIDTH_OFFSETS; j++)
                {
                    GridPoints.Add(new Point(j * LevelConstants.OFFSET_WIDTH, i * LevelConstants.STEP_HEIGHT));
                }
            }

            NotifyOfPropertyChange(() => GridPoints);
        }
    }
}
