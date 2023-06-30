using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileEncrypter.Class
{
    public class EncrypterAndDecrypter
    {
        public string EnCode(string input)
        {
            try
            {
                // -------------------------------------------------------------------------------------
                //Keys
                string PrivateKey = Console.ReadLine();
                string key = "abcdefgh";
                // -------------------------------------------------------------------------------------

                // --------------------------------------------------------------------------------------
                //Converting keys and input into byte
                byte[] PrivateKeyByte = { };

                PrivateKeyByte = Encoding.UTF8.GetBytes(PrivateKey);

                byte[] KeyByte = { };
                KeyByte = Encoding.UTF8.GetBytes(key);

                byte[] inputtextbyte = { };
                inputtextbyte = Encoding.UTF8.GetBytes(input);
                // --------------------------------------------------------------------------------------

                using (DESCryptoServiceProvider dsp = new DESCryptoServiceProvider())
                {
                    var strem = new MemoryStream();
                    var cryptostremobj = new CryptoStream(strem, dsp.CreateEncryptor(KeyByte, PrivateKeyByte), CryptoStreamMode.Write);
                    cryptostremobj.Write(inputtextbyte, 0, inputtextbyte.Length);
                    cryptostremobj.FlushFinalBlock();
                    return Convert.ToBase64String(strem.ToArray());


                }

            }
            catch
            {
                return "Error";
            }


        }

        public string DeCode(string input)
        {
            try
            {
                // -------------------------------------------------------------------------------------
                //Keys
                string PrivateKey = Console.ReadLine();
                string key = "abcdefgh";
                // -------------------------------------------------------------------------------------

                // --------------------------------------------------------------------------------------
                //Converting keys and input into byte
                byte[] PrivateKeyByte = { };

                PrivateKeyByte = Encoding.UTF8.GetBytes(PrivateKey);

                byte[] KeyByte = { };
                KeyByte = Encoding.UTF8.GetBytes(key);

                byte[] inputtextbyte = { };
                inputtextbyte = new byte[input.Replace(" ", "+").Length];
                inputtextbyte = Convert.FromBase64String(input.Replace(" ", "+"));

                // --------------------------------------------------------------------------------------
                using (DESCryptoServiceProvider dsp = new DESCryptoServiceProvider())
                {
                    var strem = new MemoryStream();
                    var cryptostremobj = new CryptoStream(strem, dsp.CreateDecryptor(KeyByte, PrivateKeyByte), CryptoStreamMode.Write);
                    cryptostremobj.Write(inputtextbyte, 0, inputtextbyte.Length);
                    cryptostremobj.FlushFinalBlock();
                    return Encoding.UTF8.GetString(strem.ToArray());



                }
            }
            catch
            {
                return "Error";

            }
        }

    }
}
