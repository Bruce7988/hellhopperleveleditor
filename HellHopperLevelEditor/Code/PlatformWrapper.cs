using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HellHopperLevelEditor.Model;
using HellHopperLevelEditor.Model.Platforms;

namespace HellHopperLevelEditor.Code
{
    public sealed class PlatformWrapper
    {
        public const double PLATFORM_WIDTH = 2.0f;
        public const double PLATFORM_HEIGHT = 0.5f;

        public const double MAX_PLATFORM_X = LevelConstants.GAME_AREA_WIDTH - PLATFORM_WIDTH;

        private const double PLATFORM_PIXEL_WIDTH = PLATFORM_WIDTH * LevelConstants.METER_TO_PIXEL;
        private const double PLATFORM_PIXEL_HEIGHT = PLATFORM_HEIGHT * LevelConstants.METER_TO_PIXEL;

        private const string PLATFORM_RESOURCES_PATH = GeneralConstants.RESOURCES_PATH + "Graphics/Platforms/";
        private const string NORMAL_PLATFORM_FORMAT = PLATFORM_RESOURCES_PATH + "normalplatform{0:00}.png";
        private const string CRUMBLE_PLATFORM_FORMAT = PLATFORM_RESOURCES_PATH + "crumbleplatform{0:00}.png";

        private const int NUM_CRUMBLE_IMAGES = 2;
        private const int NUM_NORMAL_IMAGES = 5;

        public double PixelX
        {
            get { return PlatformData.X * LevelConstants.METER_TO_PIXEL; }
        }

        public double PixelY
        {
            get { return PlatformData.Y * LevelConstants.METER_TO_PIXEL; }
        }

        public double PixelWidth
        {
            get { return PLATFORM_PIXEL_WIDTH; }
        }

        public double PixelHeight
        {
            get { return PLATFORM_PIXEL_HEIGHT; }
        }

        public string ImageSource { get; private set; }

        public PlatformData PlatformData { get; private set; }

        private static Random mRandom = new Random();

        public PlatformWrapper(PlatformData platformData)
        {
            PlatformData = platformData;

            ImageSource = GetImageSource();
        }

        private string GetImageSource()
        {
            List<PlatformFeatureData> featuresData = PlatformData.FeaturesData;

            string imageSource;
            if (featuresData != null && featuresData.Any(fd => fd.Type == PlatformFeatureType.Crumble))
            {
                imageSource = string.Format(CRUMBLE_PLATFORM_FORMAT, mRandom.Next(NUM_CRUMBLE_IMAGES));
            }
            else
            {
                imageSource = string.Format(NORMAL_PLATFORM_FORMAT, mRandom.Next(NUM_NORMAL_IMAGES));
            }

            return imageSource;
        }

        public bool IsHit(Point pixelPosition)
        {
            return PixelX <= pixelPosition.X && pixelPosition.X <= PixelX + PixelWidth &&
                PixelY <= pixelPosition.Y && pixelPosition.Y <= PixelY + PixelHeight;
        }
    }
}
