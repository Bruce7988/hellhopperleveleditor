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
            document.Add(riseSectionElement);

            return document;
        }

        private static XElement GetPlatformDataXml(PlatformData platformData)
        {
            XElement platformElement = new XElement(
                RiseSectionDataXmlConstants.TAG_PLATFORM,
                new XAttribute(RiseSectionDataXmlConstants.ATTRIBUTE_STEP, platformData.Step),
                new XAttribute(RiseSectionDataXmlConstants.ATTRIBUTE_OFFSET, platformData.Offset),
                new XAttribute(RiseSectionDataXmlConstants.ATTRIBUTE_TYPE, platformData.Type));

            return platformElement;
        }
    }
}
