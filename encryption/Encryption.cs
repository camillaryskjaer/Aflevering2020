using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypt
{
    class Encryption
    {
        //multidimentional array of the table where the code is both encrypted and decrypted.
        public string[,] array =
            {
                {  "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" },
                {  "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A" },
                {  "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B" },
                {  "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C" },
                {  "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D" },
                {  "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E" },
                {  "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F" },
                {  "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G" },
                {  "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H" },
                {  "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I" },
                {  "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" },
                {  "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" },
                {  "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" },
                {  "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" },
                {  "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N" },
                {  "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" },
                {  "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P" },
                {  "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q" },
                {  "S", "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R" },
                {  "T", "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S" },
                {  "U", "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" },
                {  "V", "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U" },
                {  "W", "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V" },
                {  "X", "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W" },
                {  "Y", "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X" },
                {  "Z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y" },
            };

        //method to encrypt a message with a code.
        public string Encrypt(string message, string code)
        {
            //ensures that the length of the code is the same as the message
            while (true)
            {
                if (message.Length > code.Length)
                {
                    code = code + code;
                }
                else if (code.Length > message.Length)
                {
                    code = code.Remove(message.Length);

                    break;
                }
                else if (code.Length == message.Length)
                {
                    break;
                }   

            }

            //converts the message to a char arary
            char[] cMessage = message.ToCharArray();


            //allocate space for the encrypted message.
            string encrypted = "";


            //encrypt one charecter at a time for the encrypted message, 
            for (int i = 0; i < message.Length; i++)
            {
                char[] cCode = code.ToCharArray();

                encrypted = encrypted + array[GetPosition(cMessage[i]), GetPosition(cCode[i])];
            }




            return $"Message: {message}\n" +
                $"Code: {code}\n" +
                $"EncryptedMessage: {encrypted}";
        }

        public string Decrypt(string encryptedMessage, string key)
        {
            //ensures that the length of the code is the same as the message
            while (true)
            {
                if (encryptedMessage.Length > key.Length)
                {
                    key = key + key;
                }
                else if (key.Length > encryptedMessage.Length)
                {
                    key = key.Remove(encryptedMessage.Length);

                    break;
                }
                else if (key.Length == encryptedMessage.Length)
                {
                    break;
                }
            }

            char[] cKey = key.ToCharArray();
            char[] cMessage = encryptedMessage.ToUpper().ToCharArray();
            int[] positions = new int[encryptedMessage.Length];


            //Finds the positions and puts them in an array
            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (array[j, GetPosition(cKey[i])] == cMessage[i].ToString())
                    {
                        positions[i] = j;
                    }
                }

            }

            string result = "";

            //Combine the positions and the first row in the array to find the message.
            for (int i = 0; i < positions.Length; i++)
            {
                result = result + array[0, positions[i]];
            }

            return $"EncryptedMessage: {encryptedMessage}\n" +
                $"Code: {key}\n" +
                $"DecryptedMessage: {result}";
        }

        public int GetPosition(char c)
        {
            string upperCase = c.ToString().ToUpper();
            switch (upperCase)
            {
                case "A":
                    return 0;
                case "B":
                    return 1;
                case "C":
                    return 2;
                case "D":
                    return 3;
                case "E":
                    return 4;
                case "F":
                    return 5;
                case "G":
                    return 6;
                case "H":
                    return 7;
                case "I":
                    return 8;
                case "J":
                    return 9;
                case "K":
                    return 10;
                case "L":
                    return 11;
                case "M":
                    return 12;
                case "N":
                    return 13;
                case "O":
                    return 14;
                case "P":
                    return 15;
                case "Q":
                    return 16;
                case "R":
                    return 17;
                case "S":
                    return 18;
                case "T":
                    return 19;
                case "U":
                    return 20;
                case "V":
                    return 21;
                case "W":
                    return 22;
                case "X":
                    return 23;
                case "Y":
                    return 24;
                case "Z":
                    return 25;
                default:
                    return 50;
            }
        }



    }
}
