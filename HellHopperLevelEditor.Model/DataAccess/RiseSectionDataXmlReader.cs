using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            XElement riseSectionElement = document.Element(RiseSectionDataXmlConstants.TAG_RISE_SECTION);
            int stepRange = int.Parse(riseSectionElement.Attribute(RiseSectionDataXmlConstants.ATTRIBUTE_STEP_RANGE).Value, NumberFormatInfo.InvariantInfo);
            int difficulty = int.Parse(riseSectionElement.Attribute(RiseSectionDataXmlConstants.ATTRIBUTE_DIFFICULTY).Value, NumberFormatInfo.InvariantInfo);

            XElement platformsElement = riseSectionElement.Element(RiseSectionDataXmlConstants.TAG_PLATFORMS);
            IEnumerable<XElement> platformElements = platformsElement.Elements(RiseSectionDataXmlConstants.TAG_PLATFORM);
            List<PlatformData> platforms = new List<PlatformData>();
            foreach (XElement platformElement in platformElements)
            {
                PlatformData platform = GetPlatformData(platformElement);
                platforms.Add(platform);
            }

            XElement enemiesElement = riseSectionElement.Element(RiseSectionDataXmlConstants.TAG_ENEMIES);
            string enemiesXml = enemiesElement != null ? enemiesElement.ToString() : "";

            XElement itemsElement = riseSectionElement.Element(RiseSectionDataXmlConstants.TAG_ITEMS);
            string itemsXml = itemsElement != null ? itemsElement.ToString() : "";

            riseSectionData.StepRange = stepRange;
            riseSectionData.Difficulty = difficulty;
            riseSectionData.Platforms = platforms;
            riseSectionData.EnemiesXml = enemiesXml;
            riseSectionData.ItemsXml = itemsXml;
        }

        private static PlatformData GetPlatformData(XElement platformElement)
        {
            XAttribute idAttribute = platformElement.Attribute(RiseSectionDataXmlConstants.ATTRIBUTE_ID);
            int id = idAttribute != null ? int.Parse(idAttribute.Value) : -1;
            int step = int.Parse(platformElement.Attribute(RiseSectionDataXmlConstants.ATTRIBUTE_STEP).Value, NumberFormatInfo.InvariantInfo);
            int offset = int.Parse(platformElement.Attribute(RiseSectionDataXmlConstants.ATTRIBUTE_OFFSET).Value, NumberFormatInfo.InvariantInfo);
            string type = platformElement.Attribute(RiseSectionDataXmlConstants.ATTRIBUTE_TYPE).Value;

            XElement movementElement = platformElement.Element(RiseSectionDataXmlConstants.TAG_MOVEMENT);
            string movementXml = movementElement != null ? movementElement.ToString() : "";

            XElement featuresElement = platformElement.Element(RiseSectionDataXmlConstants.TAG_FEATURES);
            string featuresXml = featuresElement != null ? featuresElement.ToString() : "";

            PlatformData platformData = new PlatformData(id, step, offset, type, movementXml, featuresXml);

            return platformData;
        }
    }
}
