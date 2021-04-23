using System.Security.Cryptography;

namespace EncryptionAsymmetric
{
    class RSAkeyCSP
    {
        private string ContainerName = "Container";

        private RSACryptoServiceProvider cryptoServiceProvider;

        public RSAParameters key;

        public void AsignNewKey()
        {
            CspParameters cspParams = new CspParameters(1);
            cspParams.KeyContainerName = ContainerName;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
            key = RSA.Create().ExportParameters(false);

        }

        public byte[] Encrypt(byte[] data, byte[] exponent, byte[] modulus)
        {
            byte[] cipherbytes;

            using (var rsa = new RSACryptoServiceProvider())
            {
                cipherbytes = cryptoServiceProvider.Encrypt(data, false);

                RSAParameters rSAParameters = new RSAParameters();
                rSAParameters.Exponent = exponent;
                rSAParameters.Modulus = modulus;
                rsa.ImportParameters(rSAParameters);

                cipherbytes = rsa.Encrypt(data, false);
            }
            return cipherbytes;
        }


        public byte[] Decrypt(byte[] data)
        {
            byte[] chiperBytes;

            using (cryptoServiceProvider)
            {
                chiperBytes = cryptoServiceProvider.Decrypt(data, true);
            }

            return chiperBytes;
        }

    }
}
