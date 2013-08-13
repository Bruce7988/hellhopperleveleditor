using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HellHopperLevelEditor.Model.Platforms;

namespace HellHopperLevelEditor.Model.DataAccess
{
    public static class RiseSectionDataXmlReader
    {
        public static void Read(RiseSectionData riseSectionData, string xml)
        {
            XDocument document = null;
            try
            {
                document = XDocument.Parse(xml);
                GetRiseSectionData(riseSectionData, document);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GetRiseSectionData(RiseSectionData riseSectionData, XDocument document)
        {
            XElement riseSectionElement = document.Element("risesection");
            double height = riseSectionElement.GetDouble("height");
            int difficulty = riseSectionElement.GetInt("difficulty");

            XElement platformsElement = riseSectionElement.Element("platforms");
            IEnumerable<XElement> platformElements = platformsElement.Elements("platform");
            List<PlatformData> platforms = new List<PlatformData>();
            foreach (XElement platformElement in platformElements)
            {
                PlatformData platform = GetPlatformData(platformElement);
                platforms.Add(platform);
            }

            XElement enemiesElement = riseSectionElement.Element("enemies");
            string enemiesXml = enemiesElement != null ? enemiesElement.ToString() : "";

            XElement itemsElement = riseSectionElement.Element("items");
            string itemsXml = itemsElement != null ? itemsElement.ToString() : "";

            riseSectionData.Height = height;
            riseSectionData.Difficulty = difficulty;
            riseSectionData.Platforms = platforms;
            riseSectionData.EnemiesXml = enemiesXml;
            riseSectionData.ItemsXml = itemsXml;
        }

        private static PlatformData GetPlatformData(XElement platformElement)
        {
            int id = platformElement.GetInt("id", -1);
            double x = platformElement.GetDouble("x");
            double y = platformElement.GetDouble("y");
            PlatformType type = platformElement.GetEnum<PlatformType>("type");

            XElement movementElement = platformElement.Element("movement");
            PlatformMovementData movementData = GetPlatformMovementData(movementElement);

            XElement featuresElement = platformElement.Element("features");
            List<PlatformFeatureData> featuresData = GetPlatformFeaturesData(featuresElement);

            PlatformData platformData = new PlatformData(id, x, y, type, movementData, featuresData);

            return platformData;
        }

        private static PlatformMovementData GetPlatformMovementData(XElement movementElement)
        {
            if (movementElement == null)
            {
                return null;
            }

            PlatformMovementType type = movementElement.GetEnum<PlatformMovementType>("type");

            XElement propertiesElement = movementElement.Element("properties");
            Dictionary<string, string> properties = GetPropertiesData(propertiesElement);

            return new PlatformMovementData(type, properties);
        }

        private static List<PlatformFeatureData> GetPlatformFeaturesData(XElement featuresElement)
        {
            if (featuresElement == null)
            {
                return null;
            }

            return featuresElement.Elements("feature")
                .Select(el => GetPlatformFeatureData(el))
                .ToList();
        }

        private static PlatformFeatureData GetPlatformFeatureData(XElement featureElement)
        {
            PlatformFeatureType type = featureElement.GetEnum<PlatformFeatureType>("type");

            XElement propertiesElement = featureElement.Element("properties");

            Dictionary<string, string> properties = null;
            if (propertiesElement != null)
            {
                properties = GetPropertiesData(propertiesElement);
            }

            return new PlatformFeatureData(type, properties);
        }

        private static Dictionary<string, string> GetPropertiesData(XElement propertiesElement)
        {
            IEnumerable<XElement> propertyElements = propertiesElement.Elements("property");
            Dictionary<string, string> properties = new Dictionary<string, string>();
            foreach (XElement propertyElement in propertyElements)
            {
                string name = propertyElement.GetString("name");
                string value = propertyElement.GetString("value");
                properties.Add(name, value);
            }

            return properties;
        }
    }
}
