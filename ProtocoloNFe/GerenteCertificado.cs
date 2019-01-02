using ProtocoloNFe.classes;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ProtocoloNFe
{
    class GerenteCertificado
    {
        public X509Certificate2 getCertificado()
        {
            var serialNumber = GerenteParametro.numero_serial.ToUpper();
            X509Certificate2 cert = null;

            X509Store store = new X509Store("My");
            store.Open(OpenFlags.ReadOnly);
            try
            {
                foreach (X509Certificate2 mCert in store.Certificates)
                {
                    if (mCert.SerialNumber == serialNumber)
                    {
                        cert = mCert;
                        break;
                        }
                }

                if (cert == null)
                {
                    throw (
                              new Exception("O certificado informado não foi encontrado!")
                          );
                }

                return cert;
            }
            finally
            {
                store.Close();
            }
        }

        public X509Certificate2 getCert(string arquivo, string senha)
        {
            return new X509Certificate2(arquivo, senha);
        }
    }
}
