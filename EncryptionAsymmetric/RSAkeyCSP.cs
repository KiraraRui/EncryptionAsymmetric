using System.Security.Cryptography;

namespace EncryptionAsymmetric
{
    class RSAkeyCSP
    {

        private string ContainerName = "Container";

        private RSACryptoServiceProvider _cryptoServiceProvider;

        public void AsignNewKey()
        {
            CspParameters cspParams = new CspParameters(1);
            cspParams.KeyContainerName = ContainerName;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";

        }

        public byte[] Encrypt(byte[] data, byte[] exponent, byte[] modulus)
        {
            byte[] cipherbytes;

            using (_cryptoServiceProvider) // var rsa = new RSACryptoServiceProvider()
            {
                cipherbytes = _cryptoServiceProvider.Encrypt(data, false);
          
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

            using (_cryptoServiceProvider)
            {
                chiperBytes = _cryptoServiceProvider.Decrypt(data, true);
            }

            return chiperBytes;
        }

    }
}
