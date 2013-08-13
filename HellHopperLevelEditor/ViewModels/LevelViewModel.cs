using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using HellHopperLevelEditor.Code;
using HellHopperLevelEditor.Model;
using HellHopperLevelEditor.Model.Util;

namespace HellHopperLevelEditor.ViewModels
{
    public sealed class LevelViewModel : PropertyChangedBase
    {
        private double mHeight;
        public double Height
        {
            get { return mHeight; }
            set
            {
                if (mHeight != value)
                {
                    mHeight = value;
                    NotifyOfPropertyChange(() => Height);
                    NotifyOfPropertyChange(() => PixelHeight);
                    GenerateGridPoints();
                }
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

        public double PixelHeight
        {
            get { return Height * LevelConstants.METER_TO_PIXEL; }
        }

        public List<Point> GridPoints { get; private set; }

        private RiseSectionData mRiseSectionData;

        public LevelViewModel(RiseSectionData riseSectionData)
        {
            mRiseSectionData = riseSectionData;
            mRiseSectionData.DataChanged += RiseSectionDataDataChanged;

            UpdateFromModel();
        }

        public void MouseDown(Point position)
        {
            //position.Y = PixelHeight - position.Y;
            //for (int i = 0; i < Platforms.Count; i++)
            //{
            //    PlatformWrapper platform = Platforms[i];
            //    if (platform.X <= position.X && position.X <= platform.X + LevelConstants.PLATFORM_WIDTH &&
            //        platform.Y <= position.Y && position.Y <= platform.Y + LevelConstants.PLATFORM_HEIGHT)
            //    {
            //        Platforms.RemoveAt(i);
            //        Platforms = new List<PlatformWrapper>(Platforms);
            //        UpdateModel();
            //        return;
            //    }
            //}

            //double stepFraction = position.Y / LevelConstants.STEP_HEIGHT;
            //double offsetFraction = position.X / LevelConstants.OFFSET_WIDTH;

            //int step = (int)stepFraction;
            //int offset = (int)offsetFraction;

            //if (CanPlacePlatform(stepFraction, step, offset))
            //{
            //    Platforms.Add(new PlatformWrapper(new PlatformData(-1, step, offset, "normal", "", "")));
            //    Platforms = new List<PlatformWrapper>(Platforms);
            //    UpdateModel();
            //}
        }

        private bool CanPlacePlatform(double stepFraction, int step, int offset)
        {
            //if (stepFraction % 1.0 <= 0.5 &&
            //    0 <= step && step < Height &&
            //    0 <= offset && offset <= LevelConstants.MAX_PLATFORM_OFFSET)
            //{
            //    foreach (PlatformData platform in mRiseSectionData.Platforms)
            //    {
            //        if (platform.Step == step &&
            //            offset > platform.Offset - LevelConstants.PLATFORM_WIDTH_OFFSETS &&
            //            offset < platform.Offset + LevelConstants.PLATFORM_WIDTH_OFFSETS)
            //        {
            //            return false;
            //        }
            //    }

            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return false;
        }

        private void UpdateFromModel()
        {
            Height = mRiseSectionData.Height;
            Platforms = mRiseSectionData.Platforms
                .Where(pd => pd.Y < Height)
                .Select(pd => new PlatformWrapper(pd))
                .ToList();
        }

        private void UpdateModel()
        {
            mRiseSectionData.Platforms = Platforms.Select(pw => pw.PlatformData).ToList();
            mRiseSectionData.Update(RiseSectionUpdateSource.Level);
        }

        private void GenerateGridPoints()
        {
            GridPoints = null;
            //GridPoints = new List<Point>();
            //for (int i = 0; i < Height; i++)
            //{
            //    for (int j = 0; j < LevelConstants.LEVEL_WIDTH_OFFSETS; j++)
            //    {
            //        GridPoints.Add(new Point(j * LevelConstants.OFFSET_WIDTH, i * LevelConstants.STEP_HEIGHT));
            //    }
            //}

            NotifyOfPropertyChange(() => GridPoints);
        }

        private void RiseSectionDataDataChanged(object sender, ParameterizedEventArgs<RiseSectionUpdateSource> e)
        {
            if (e.Parameter != RiseSectionUpdateSource.Level)
            {
                UpdateFromModel();
            }
        }
    }
}
