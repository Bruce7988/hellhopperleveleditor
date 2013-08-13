using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HellHopperLevelEditor.Model.Platforms;

namespace HellHopperLevelEditor.Model.DataAccess
{
    public static class RiseSectionDataXmlWriter
    {
        public static string Write(RiseSectionData riseSectionData)
        {
            XDocument document = GetRiseSectionDataXml(riseSectionData);
            return document.ToString();
        }

        private static XDocument GetRiseSectionDataXml(RiseSectionData riseSectionData)
        {
            XDocument document = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"));

            XElement riseSectionElement = new XElement(
                "risesection",
                new XAttribute("height", riseSectionData.Height),
                new XAttribute("difficulty", riseSectionData.Difficulty));

            XElement platformsElement = new XElement("platforms");
            foreach (PlatformData platformData in riseSectionData.Platforms)
            {
                XElement platformElement = GetPlatformDataXml(platformData);
                platformsElement.Add(platformElement);
            }
            riseSectionElement.Add(platformsElement);

            if (!string.IsNullOrEmpty(riseSectionData.EnemiesXml))
            {
                XElement enemiesElement = XElement.Parse(riseSectionData.EnemiesXml);
                riseSectionElement.Add(enemiesElement);
            }

            if (!string.IsNullOrEmpty(riseSectionData.ItemsXml))
            {
                XElement itemsElement = XElement.Parse(riseSectionData.ItemsXml);
                riseSectionElement.Add(itemsElement);
            }

            document.Add(riseSectionElement);

            return document;
        }

        private static XElement GetPlatformDataXml(PlatformData platformData)
        {
            XElement platformElement = new XElement("platform");
            if (platformData.Id >= 0)
            {
                platformElement.Add(new XAttribute("id", platformData.Id));
            }
            platformElement.Add(new XAttribute("x", platformData.X));
            platformElement.Add(new XAttribute("y", platformData.Y));
            platformElement.Add(new XAttribute("type", platformData.Type));

            if (platformData.MovementData != null)
            {
                XElement movementElement = GetPlatformMovementDataXml(platformData.MovementData);
                platformElement.Add(movementElement);
            }

            if (platformData.FeaturesData != null)
            {
                XElement featuresElement = GetPlatformFeaturesDataXml(platformData.FeaturesData);
                platformElement.Add(featuresElement);
            }

            return platformElement;
        }

        private static XElement GetPlatformMovementDataXml(PlatformMovementData movementData)
        {
            XElement movementElement = new XElement("movement");
            movementElement.Add(DataAccessUtils.GetEnumAttribute("type", movementData.Type));

            if (movementData.Properties != null) 
            {
                XElement propertiesElement = GetPropertiesDataXml(movementData.Properties);
                movementElement.Add(propertiesElement);
            }

            return movementElement;
        }

        private static XElement GetPlatformFeaturesDataXml(List<PlatformFeatureData> featuresData)
        {
            XElement featuresElement = new XElement("features");
            foreach (PlatformFeatureData featureData in featuresData)
            {
                XElement featureElement = GetPlatformFeatureDataXml(featureData);
                featuresElement.Add(featureElement);
            }

            return featuresElement;
        }

        private static XElement GetPlatformFeatureDataXml(PlatformFeatureData featureData)
        {
            XElement featureElement = new XElement("movement");
            featureElement.Add(DataAccessUtils.GetEnumAttribute("type", featureData.Type));

            if (featureData.Properties != null)
            {
                XElement propertiesElement = GetPropertiesDataXml(featureData.Properties);
                featureElement.Add(propertiesElement);
            }

            return featureElement;
        }

        private static XElement GetPropertiesDataXml(Dictionary<string, string> properties)
        {
            XElement propertiesElement = new XElement("properties");
            foreach (KeyValuePair<string, string> property in properties)
            {
                XElement propertyElement = new XElement("property",
                    new XAttribute("name", property.Key),
                    new XAttribute("value", property.Value));
                propertiesElement.Add(propertyElement);
            }

            return propertiesElement;
        }
    }
}
