using System;

namespace nsMonitorDFe.Classes
{
    class GerenteParametro
    {
        public static string string_conexao;
        public static bool tem_proxy;
        public static string servidor;
        public static string porta;
        public static string usuario;
        public static string senha;
        public static string id_estabelecimento;
        public static string numero_serial;
        public static string tenant;
        public static string apiKey;
        public static string endereco_mac;
        public static string nsu;
        public static string CNPJ;
        public static string ufAutor;
        public static int Sistema;
        public static string xml_upload;

           
        public static void Carregar()
        {

            if ( Convert.ToInt16( @Environment.GetCommandLineArgs()[1] ) == Constantes.SISTEMA_MONITOR_ERP )
            {
                Sistema            = Convert.ToInt16(@Environment.GetCommandLineArgs()[1]);
                string_conexao     = Convert.ToString(@Environment.GetCommandLineArgs()[2]);
                id_estabelecimento = Convert.ToString(@Environment.GetCommandLineArgs()[3]);
                numero_serial = Convert.ToString(@Environment.GetCommandLineArgs()[4]);
                tenant = Convert.ToString(@Environment.GetCommandLineArgs()[5]);
                apiKey = Convert.ToString(@Environment.GetCommandLineArgs()[6]);
                tem_proxy = Convert.ToBoolean(@Environment.GetCommandLineArgs()[7]);
                servidor = Convert.ToString(@Environment.GetCommandLineArgs()[8]);
                porta = Convert.ToString(@Environment.GetCommandLineArgs()[9]);
                usuario = Convert.ToString(@Environment.GetCommandLineArgs()[10]);
                senha = Convert.ToString(@Environment.GetCommandLineArgs()[11]);
                endereco_mac = Convert.ToString(@Environment.GetCommandLineArgs()[12]);
                nsu = Convert.ToString(@Environment.GetCommandLineArgs()[13]);
            }
            else
            {
                Sistema = Convert.ToInt16(@Environment.GetCommandLineArgs()[1]);
                CNPJ = Convert.ToString(@Environment.GetCommandLineArgs()[2]);
                numero_serial = Convert.ToString(@Environment.GetCommandLineArgs()[3]);
                tenant = Convert.ToString(@Environment.GetCommandLineArgs()[4]);
                apiKey = Convert.ToString(@Environment.GetCommandLineArgs()[5]);
                tem_proxy = Convert.ToBoolean(@Environment.GetCommandLineArgs()[6]);
                servidor = Convert.ToString(@Environment.GetCommandLineArgs()[7]);
                porta = Convert.ToString(@Environment.GetCommandLineArgs()[8]);
                usuario = Convert.ToString(@Environment.GetCommandLineArgs()[9]);
                senha = Convert.ToString(@Environment.GetCommandLineArgs()[10]);
                nsu = Convert.ToString(@Environment.GetCommandLineArgs()[11]);
                ufAutor = Convert.ToString(@Environment.GetCommandLineArgs()[12]);
                xml_upload = Convert.ToString(@Environment.GetCommandLineArgs()[13]);
            }

        }
   }
}
