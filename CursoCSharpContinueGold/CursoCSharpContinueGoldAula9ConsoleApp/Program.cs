using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharpContinueGoldAula9ConsoleApp
{
    class Program
    {
       
        static void Main(string[] args)
        {
                 
        }

        // AULA 9.02
        public void Tipo()
        {
            string s1 = "ola";
            object s2 = "ola"; // é uma string encapsulada em um object, precisa faze rum cast, para ter acesso aos métodos da string
            string s5 = (string)s2; // desta forma, não criamos uma nova área de memória, evitar usar o ToString()
            var s3 = "ola"; // o var é para ser usando quando trabalhamos com Linq, ou quando trabalhamos com objetos anônimos, O VAR INFERE O TIPO
            dynamic s4 = "ola"; // interoperabilidade com linguagens script, quando fazemos um "s4." a operação é resolvida em tempo de execução

            var x = new { Nome = "João", Idade = 19 }; // objeto anonimo  
        }

        // AULA 9.03 - criptografia
        // hash - formato oneway (senhas - Lei)
        // criptografia simetrica (password unico - ida e volta)
        // criptografia assimetrica (chave publica e outra privada)

            // segue exemplo de cryptografia simétrica
        public static class StringCipher
        {
            private const int KeySize = 256;
            private const int DerivationInterations = 1000;

            public static string Encrypt(string text, string pass)
            {
                byte[] saltValues = Generate256RandomBits();
                byte[] IV = Generate256RandomBits();
                byte[] textoEmBytes = Encoding.UTF8.GetBytes(text);

                using (Rfc2898DeriveBytes senha =
                    new Rfc2898DeriveBytes(pass, saltValues, DerivationInterations))
                {
                    byte[] senhaEmBytes = senha.GetBytes(KeySize / 8);
                    using (RijndaelManaged rijndaelAlgorithm = new RijndaelManaged())
                    {
                        rijndaelAlgorithm.BlockSize = KeySize;
                        rijndaelAlgorithm.Mode = CipherMode.CBC;
                        rijndaelAlgorithm.Padding = PaddingMode.PKCS7;
                        using (ICryptoTransform encryptor = rijndaelAlgorithm.CreateEncryptor(senhaEmBytes, IV))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                using (CryptoStream crypt =
                                    new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                                {
                                    crypt.Write(textoEmBytes, 0, textoEmBytes.Length);
                                    crypt.FlushFinalBlock();
                                    byte[] cipherTextBytes = saltValues;
                                    cipherTextBytes = cipherTextBytes.Concat(IV).ToArray();
                                    cipherTextBytes = cipherTextBytes.Concat(ms.ToArray()).ToArray();
                                    return Convert.ToBase64String(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }

            public static string Decrypt(string cipherText, string pass)
            {
                byte[] textWithSaltIV = Convert.FromBase64String(cipherText);
                byte[] saltUsedValue = textWithSaltIV.Take(KeySize / 8).ToArray();
                byte[] ivUsedValue =
                    textWithSaltIV.Skip(KeySize / 8).Take(KeySize / 8).ToArray();
                byte[] realCipherText =
                    textWithSaltIV.Skip((KeySize / 8) * 2).
                    Take(textWithSaltIV.Length - ((KeySize / 8) * 2)).ToArray();
                using (Rfc2898DeriveBytes password =
                    new Rfc2898DeriveBytes(pass, saltUsedValue, DerivationInterations))
                {
                    byte[] keyBytes = password.GetBytes(KeySize / 8);
                    using (RijndaelManaged rijndael = new RijndaelManaged())
                    {
                        rijndael.BlockSize = 256;
                        rijndael.Mode = CipherMode.CBC;
                        rijndael.Padding = PaddingMode.PKCS7;
                        using (ICryptoTransform encryptor =
                            rijndael.CreateEncryptor(keyBytes, ivUsedValue))
                        {
                            using (MemoryStream ms = new MemoryStream(realCipherText))
                            {
                                using (CryptoStream crypt =
                                    new CryptoStream(ms, encryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainText = new byte[realCipherText.Length];
                                    int bytesRead =
                                        crypt.Read(plainText, 0, plainText.Length);
                                    return Encoding.UTF8.GetString(plainText, 0, bytesRead);
                                }
                            }
                        }
                    }
                }
            }

            public static byte[] Generate256RandomBits()
            {
                byte[] dados = new byte[32];
                using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
                {
                    provider.GetBytes(dados);
                }
                return dados;
            }
        }
    }
}
