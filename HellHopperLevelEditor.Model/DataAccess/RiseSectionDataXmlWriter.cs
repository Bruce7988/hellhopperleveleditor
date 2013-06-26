using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                RiseSectionDataXmlConstants.TAG_RISE_SECTION,
                new XAttribute(RiseSectionDataXmlConstants.ATTRIBUTE_STEP_RANGE, riseSectionData.StepRange),
                new XAttribute(RiseSectionDataXmlConstants.ATTRIBUTE_DIFFICULTY, riseSectionData.Difficulty));

            XElement platformsElement = new XElement(RiseSectionDataXmlConstants.TAG_PLATFORMS);
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
            XElement platformElement = new XElement(RiseSectionDataXmlConstants.TAG_PLATFORM);
            if (platformData.Id >= 0)
            {
                platformElement.Add(new XAttribute(RiseSectionDataXmlConstants.ATTRIBUTE_ID, platformData.Id));
            }
            platformElement.Add(new XAttribute(RiseSectionDataXmlConstants.ATTRIBUTE_STEP, platformData.Step));
            platformElement.Add(new XAttribute(RiseSectionDataXmlConstants.ATTRIBUTE_OFFSET, platformData.Offset));
            platformElement.Add(new XAttribute(RiseSectionDataXmlConstants.ATTRIBUTE_TYPE, platformData.Type));

            if (!string.IsNullOrEmpty(platformData.MovementXml))
            {
                XElement movementElement = XElement.Parse(platformData.MovementXml);
                platformElement.Add(movementElement);
            }

            if (!string.IsNullOrEmpty(platformData.FeaturesXml))
            {
                XElement featuresElement = XElement.Parse(platformData.FeaturesXml);
                platformElement.Add(featuresElement);
            }

            return platformElement;
        }
    }
}
