using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionAsymmetric
{
    class Program
    {
        private static void Main(string[] args)
        {
            string path = @"..\XmlKeys";
            bool isRunning = true;

            string userInput = "";
            while (isRunning)
            {

                Console.WriteLine("ASymmectric Encryption & Decryption by RSA\n");

                Console.WriteLine(@"
                         +------------------------------------+
                         | +------------------------------------+
                         | |                                  | |
                         | |      Press 1 for continuing      | |
                         | |         Press 2 for Exit         | |
                         | |    ==========================    | |
                         | |      Remember to press enter     | |
                         | |                                  | |
                         +------------------------------------+ |
                           +------------------------------------+ ");
                userInput = Console.ReadLine();

                byte[] encryptedText = null;

                if (userInput == "1")
                {

                    var RSAKey = new RSAkeyCSP();
                    RSAKey.AsignNewKey();
                    Console.WriteLine(Convert.ToBase64String(RSAKey.key.Modulus));

                    //writes the modulus values 
                    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
                    {
                        File.WriteAllText(path + @"\PrivateKey.xml", rsa.ToXmlString(true));
                        rsa.PersistKeyInCsp = false;
                        rsa.FromXmlString(File.ReadAllText(path + @"\PrivateKey.xml"));
                        Console.WriteLine($"Exponent: {BitConverter.ToString(rsa.ExportParameters(false).Exponent)}\n" +
                                          $"Modulus: {BitConverter.ToString(rsa.ExportParameters(false).Modulus)}\n");
                    }

                    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
                    {
                        File.WriteAllText(path + @"\PublicKey.xml", rsa.ToXmlString(false));
                        rsa.PersistKeyInCsp = false;
                        rsa.FromXmlString(File.ReadAllText(path + @"\PublicKey.xml"));
                        Console.WriteLine($"Exponent: {BitConverter.ToString(rsa.ExportParameters(false).Exponent)}\n" +
                                          $"Modulus: {BitConverter.ToString(rsa.ExportParameters(false).Modulus)}\n");
                    }

                    //text --> encrypt
                    Console.WriteLine("Write your text");
                    userInput = Console.ReadLine();
                    var s = RSA.Create();
                    encryptedText = s.Encrypt(Encoding.UTF8.GetBytes(path + @"\PublicKey" + (userInput)), RSAEncryptionPadding.Pkcs1);
                    Console.Clear();
                }

                else if (userInput == "2")
                {
                    isRunning = false;
                }
            }
        }

    }
}



