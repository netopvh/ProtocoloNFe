
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ProtocoloNFe.classes
{
    class GerenteXML
    {
        private static NFe NF;
        public static string GerarXmlConsulta()
        {

            return string.Concat("<consSitNFe xmlns = \"http://www.portalfiscal.inf.br/nfe\" versao = \"" + NF.versao + "\">",
                    "<tpAmb>1</tpAmb>",
                    "<xServ>CONSULTAR</xServ>",
                    "<chNFe>" + NF.chaveacesso + "</chNFe></consSitNFe>");
        }

        public static void AdicionarCabecalhoProcNFe()
        {
            XNamespace NameSpace = "http://www.portalfiscal.inf.br/nfe";

            var novo_xml = NF.XML.CreateElement("nfeProc");
            novo_xml.SetAttribute("versao", NF.versao);
            novo_xml.SetAttribute("xmlns", NameSpace.NamespaceName);

            var xml_prolog = NF.XML.CreateXmlDeclaration("1.0", "utf-8", null);

            // adiciona o corpo da nfe a partir da tag NFe ao novo xml
            novo_xml.AppendChild(NF.XML.GetElementsByTagName("NFe")[0]);

            NF.XML.LoadXml(novo_xml.OuterXml);
            NF.XML.InsertBefore(xml_prolog, NF.XML.DocumentElement);

        }

        internal static void SalvarNFe()
        {
            var DocSave = XDocument.Load(new StringReader(NF.XML.InnerXml.ToString()), LoadOptions.None);
            DocSave.Save(NF.caminho_arquivo, SaveOptions.DisableFormatting);
        }

        internal static void CarregarNF(NFe _NF)
        {
            NF = _NF;
        }

        public static void AdicionarProtocoloNFe()
        {
            var xml_protocolo_formatado = FormatarXmlProtocolo(GerenteServicosWeb.XmlCarregado);
            XmlNode no_protocolo = NF.XML.ImportNode(xml_protocolo_formatado.GetElementsByTagName("protNFe")[0], true);
            NF.XML.GetElementsByTagName("nfeProc")[0].AppendChild(no_protocolo);
        }

        private static XmlDocument FormatarXmlProtocolo(XmlNode XML)
        {
            var PosicaoProtoNFeInicio = XML.OuterXml.IndexOf("<protNFe");
            var PosicaoProtoNFeFim = XML.OuterXml.IndexOf("/protNFe>") + "/protNFe>".Length;
            var tamanhoProtocolo = PosicaoProtoNFeFim - PosicaoProtoNFeInicio;
            var xml_protocolo_NF = new XmlDocument();
            xml_protocolo_NF.LoadXml(XML.OuterXml.Substring(PosicaoProtoNFeInicio, tamanhoProtocolo));
            return xml_protocolo_NF;
        }

    }
}
