using ProtocoloNFe.classes;
using System;
using System.IO;

namespace ProtocoloNFe
{
    class Program
    {
        static void Main(string[] args)
        {
            GerenteParametro.Carregar();
            GerenteServicosWeb.Carregar();

            DirectoryInfo ListaArquivos = new DirectoryInfo(GerenteParametro.diretorio_xml);
            foreach (var Arquivo in ListaArquivos.GetFiles())
            {
                Console.WriteLine("Lendo arquivo: " + Arquivo.FullName);
                NFe NF = new NFe(Arquivo.FullName);

                if ((NF.possui_protocolo)
                      || (NF.possui_evento_processamento))
                    continue;

                try
                {
                    GerenteXML.CarregarNF(NF);
                    GerenteServicosWeb.ConsultarNFCe(NF);
                    if (!GerenteServicosWeb.NFStatusEmitido())
                        continue;
                    GerenteXML.AdicionarCabecalhoProcNFe();
                    GerenteXML.AdicionarProtocoloNFe();
                    GerenteXML.SalvarNFe();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

        }
    }
}
