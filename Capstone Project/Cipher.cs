using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Project
{
    class Cipher
    {
        /// <summary>
        /// ******************************************************
        ///             CHIPHER METHOD
        /// ******************************************************
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static char CaesarCipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }
        /// <summary>
        /// ******************************************************
        ///             ENCRYPTION
        /// ******************************************************
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>

        public static string Encrypt(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += CaesarCipher(ch, key);

            return output;
        }
        /// <summary>
        /// ******************************************************
        ///             DECRYPTION
        /// ******************************************************
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string input, int key)
        {
            return Encrypt(input, 26 - key);
        }
    }
}
