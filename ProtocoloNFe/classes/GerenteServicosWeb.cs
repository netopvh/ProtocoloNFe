using System.Net;
using System.Xml;

namespace ProtocoloNFe.classes
{
    class GerenteServicosWeb
    {
        static ServiceConsultaNFCe3_0.NfeConsulta2SoapClient _ConsultaNFCe3;
        static ServiceConsultaNFCe4_0.NFeConsultaProtocolo4SoapClient _ConsultaNFCe4;
        static ServiceConsultaNFCe3_0.nfeCabecMsg _MsgCabecalho;

        public static XmlNode XmlCarregado { get; set; }
      
        public static void Carregar()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;

            _ConsultaNFCe3 = new ServiceConsultaNFCe3_0.NfeConsulta2SoapClient();
            _ConsultaNFCe4 = new ServiceConsultaNFCe4_0.NFeConsultaProtocolo4SoapClient();
            _MsgCabecalho  = new ServiceConsultaNFCe3_0.nfeCabecMsg();
            
            var Certificado   = new GerenteCertificado().getCertificado();

            _ConsultaNFCe3.ClientCredentials.ClientCertificate.Certificate = Certificado;
            _ConsultaNFCe4.ClientCredentials.ClientCertificate.Certificate = Certificado;

        }
        public static void ConsultarNFCe( NFe NF )
        {
            XmlDocument DocEnvioSoap = new XmlDocument();
            DocEnvioSoap.LoadXml(GerenteXML.GerarXmlConsulta());
            
            if ( NF.versao == "3.10")
            {
                _MsgCabecalho.cUF         = NF.cuf;
                _MsgCabecalho.versaoDados = NF.versao;

                XmlCarregado = _ConsultaNFCe3.nfeConsultaNF2(ref _MsgCabecalho, DocEnvioSoap);
            }
            else
            {   XmlCarregado = _ConsultaNFCe4.nfeConsultaNF( DocEnvioSoap ); }

        }

        public static bool NFStatusEmitido()
        {
            XmlDocument XDoc = new XmlDocument();
            XDoc.LoadXml("<xml>" + XmlCarregado.InnerXml.ToString() + "</xml>");
            return XDoc.GetElementsByTagName("cStat")[0].InnerText == "100";
        }
    }
}
