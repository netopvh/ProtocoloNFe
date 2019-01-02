
using System.Xml;

namespace ProtocoloNFe.classes
{
    class NFe
    {
        public string caminho_arquivo { get; set; }
        public string cuf { get; set; }
        public string versao { get; set; }
        public string chaveacesso { get; set; }
        public string protocolo { get; set; }
        public bool possui_protocolo { get; set; }
        public bool possui_evento_processamento { get; set; }
        public XmlDocument XML { get; set; }
        public NFe( string arquivo )
        {
            XML = new XmlDocument();
            XML.Load( arquivo );

            if (XML.GetElementsByTagName("protNFe").Count > 0)
            { protocolo = XML.GetElementsByTagName("protNFe")[0].InnerText; }
            else protocolo = "";

            possui_protocolo = protocolo != "";

            caminho_arquivo = arquivo; 
            possui_evento_processamento  = XML.GetElementsByTagName("procEventoNFe").Count > 0;
            versao          = XML.GetElementsByTagName("infNFe")[0].Attributes.GetNamedItem("versao").Value;
            cuf             = XML.GetElementsByTagName("cUF")[0].InnerText;
            var chavene_aux = XML.GetElementsByTagName("infNFe")[0].Attributes.GetNamedItem("Id").Value;
            chaveacesso     = chavene_aux.Substring(3, 44);
        }

    }
}
