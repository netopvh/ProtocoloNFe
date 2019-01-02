using System;
using System.Xml;

namespace ProtocoloNFe.classes
{
    class GerenteParametro
    {
        public static string senha;
        public static string numero_serial;
        public static string diretorio_xml;

        public static void Carregar()
        {
            XmlDocument DocumentoXML = new XmlDocument();
            DocumentoXML.Load(AppDomain.CurrentDomain.BaseDirectory + @"config_protocolo.xml" );
            numero_serial = DocumentoXML.GetElementsByTagName("numero_serial")[0].InnerText;
            senha         = DocumentoXML.GetElementsByTagName("senha")[0].InnerText;
            diretorio_xml = DocumentoXML.GetElementsByTagName("diretorio_xml")[0].InnerText;
        }
    }
}
