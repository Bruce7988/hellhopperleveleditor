using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using HellHopperLevelEditor.Code;
using HellHopperLevelEditor.Code.Editor;
using HellHopperLevelEditor.Model;
using HellHopperLevelEditor.Model.Platforms;
using HellHopperLevelEditor.Model.Util;
using HellHopperLevelEditor.Utility;

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

        public LevelViewModel(RiseSectionData riseSectionData, EditorManager editorManager)
        {
            mRiseSectionData = riseSectionData;
            mRiseSectionData.DataChanged += RiseSectionDataDataChanged;

            UpdateFromModel();
        }

        public void MouseDown(Point pixelPosition)
        {
            pixelPosition.Y = PixelHeight - pixelPosition.Y;
            for (int i = 0; i < Platforms.Count; i++)
            {
                PlatformWrapper platform = Platforms[i];
                if (platform.IsHit(pixelPosition))
                {
                    Platforms.RemoveAt(i);
                    Platforms = new List<PlatformWrapper>(Platforms);
                    UpdateModel();
                    return;
                }
            }

            Point position = GetGameAreaPosition(pixelPosition);

            double x = Util.LimitDouble(position.X - PlatformWrapper.PLATFORM_WIDTH / 2.0f, 0.0f, PlatformWrapper.MAX_PLATFORM_X);
            double y = Math.Max(position.Y - PlatformWrapper.PLATFORM_HEIGHT / 2.0f, 0.0f);

            x = Math.Round(x, 2);
            y = Math.Round(y, 2);

            Platforms.Add(new PlatformWrapper(new PlatformData(-1, x, y, PlatformType.Normal, null, null)));
            Platforms = new List<PlatformWrapper>(Platforms);
            UpdateModel();
        }

        private static Point GetGameAreaPosition(Point pixelPosition)
        {
            return new Point(
                pixelPosition.X * LevelConstants.PIXEL_TO_METER,
                pixelPosition.Y * LevelConstants.PIXEL_TO_METER);
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
