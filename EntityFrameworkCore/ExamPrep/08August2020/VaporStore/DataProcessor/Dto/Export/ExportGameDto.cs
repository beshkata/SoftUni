using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Game")]
    public class ExportGameDto
    {
        [XmlAttribute("title")]
        public string GameName { get; set; }

        [XmlElement("Genre")]
        public string GameGenre { get; set; }

        [XmlElement("Price")]
        public decimal GamePrice { get; set; }

    }
}
