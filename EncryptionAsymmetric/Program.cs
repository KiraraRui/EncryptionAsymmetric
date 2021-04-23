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
            string path = @"..\..\..\XmlKeys";
            bool isRunning = true;

                while (isRunning)
                {

                Console.Clear();
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

                string userInput = "";
                byte[] encryptedText = null;

                if (userInput == "1")
                {

                    //writes the modulus values 
                    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
                    {
                        rsa.PersistKeyInCsp = false;
                        rsa.FromXmlString(File.ReadAllText(path + @"\PrivateKey"));
                        Console.WriteLine($"Exponent: {BitConverter.ToString(rsa.ExportParameters(false).Exponent)}\n" +
                                          $"Modulus: {BitConverter.ToString(rsa.ExportParameters(false).Modulus)}\n");
                    }

                //text --> encrypt
                Console.WriteLine("Write your text");
                    userInput = Console.ReadLine();
                    encryptedText = RSA.Encrypt(path + @"\PublicKey", Encoding.UTF8.GetBytes(userInput));

                    
                    //File.WriteAllBytes(path + @"\" + DateTime.Now.Ticks + ".txt", encryptedText);

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



