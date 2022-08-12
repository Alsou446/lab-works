using System;
using System.Linq;
using System.Numerics;

namespace Client
{
    internal class DES
    {
        private string Key;
        private string[] RoundKeys = new string[16];

        static private int BlockSize = 16;

        private static int[] Pc1 = new int[56] {
            57, 49, 41, 33, 25, 17, 9,
            1,  58, 50, 42, 34, 26, 18,
            10, 2,  59, 51, 43, 35, 27,
            19, 11, 3,  60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15,
            7,  62, 54, 46, 38, 30, 22,
            14, 6,  61, 53, 45, 37, 29,
            21, 13, 5,  28, 20, 12, 4
        };

        // The PC2 table
        private static int[] Pc2 = new int[48] {
            14, 17, 11, 24, 1,  5,
            3,  28, 15, 6,  21, 10,
            23, 19, 12, 4,  26, 8,
            16, 7,  27, 20, 13, 2,
            41, 52, 31, 37, 47, 55,
            30, 40, 51, 45, 33, 48,
            44, 49, 39, 56, 34, 53,
            46, 42, 50, 36, 29, 32
        };

        // The substitution boxes. The should contain values
        // from 0 to 15 in any order.
        private static int[,,] SubstitionBoxes = new int[8, 4, 16] {
            {
                {14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7},
                {0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8},
                {4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0},
                {15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13}
            },
            {
                {15,1,8,14,6,11,3,4,9,7,2,13,12,0,5,10},
                {3,13,4,7,15,2,8,14,12,0,1,10,6,9,11,5},
                {0,14,7,11,10,4,13,1,5,8,12,6,9,3,2,15},
                {13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9}
            },
            {
                {10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8},
                {13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1},
                {13,6,4,9,8,15,3,0,11,1,2,12,5,10,14,7},
                {1,10,13,0,6,9,8,7,4,15,14,3,11,5,2,12}
            },
            {
                {7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15},
                {13,8,11,5,6,15,0,3,4,7,2,12,1,10,14,9},
                {10,6,9,0,12,11,7,13,15,1,3,14,5,2,8,4},
                {3,15,0,6,10,1,13,8,9,4,5,11,12,7,2,14}
            },
            {
                {2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9},
                {14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6},
                {4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14},
                {11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3}
            },
            {
                {12,1,10,15,9,2,6,8,0,13,3,4,14,7,5,11},
                {10,15,4,2,7,12,9,5,6,1,13,14,0,11,3,8},
                {9,14,15,5,2,8,12,3,7,0,4,10,1,13,11,6},
                {4,3,2,12,9,5,15,10,11,14,1,7,6,0,8,13}
            },
            {
                {4,11,2,14,15,0,8,13,3,12,9,7,5,10,6,1},
                {13,0,11,7,4,9,1,10,14,3,5,12,2,15,8,6},
                {1,4,11,13,12,3,7,14,10,15,6,8,0,5,9,2},
                {6,11,13,8,1,4,10,7,9,5,0,15,14,2,3,12}
            },
            {
                {13,2,8,4,6,15,11,1,10,9,3,14,5,0,12,7},
                {1,15,13,8,10,3,7,4,12,5,6,11,0,14,9,2},
                {7,11,4,1,9,12,14,2,0,6,10,13,15,3,5,8},
                {2,1,14,7,4,10,8,13,15,12,9,0,3,5,6,11}
            }
        };

        // The initial permutation table
        private static int[] InitialPermutation = new int[64] {
            58, 50, 42, 34, 26, 18, 10, 2,
            60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6,
            64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17, 9,  1,
            59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,
            63, 55, 47, 39, 31, 23, 15, 7
        };

        static int[] ExpansionTable = new int[48] {
            32,  1,  2,  3,  4,  5,  4,  5,
            6,  7,  8,  9,  8,  9, 10, 11,
            12, 13, 12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21, 20, 21,
            22, 23, 24, 25, 24, 25, 26, 27,
            28, 29, 28, 29, 30, 31, 32,  1
        };

        // The permutation table
        static int[] PermutationTab = new int[32] {
            16,  7, 20, 21, 29, 12, 28, 17,
             1, 15, 23, 26,  5, 18, 31, 10,
             2,  8, 24, 14, 32, 27,  3,  9,
            19, 13, 30,  6, 22, 11,  4, 25
        };

        // The inverse permutation table
        static int[] InversePermutation = new int[64] {
            40,  8, 48, 16, 56, 24, 64, 32,
            39,  7, 47, 15, 55, 23, 63, 31,
            38,  6, 46, 14, 54, 22, 62, 30,
            37,  5, 45, 13, 53, 21, 61, 29,
            36,  4, 44, 12, 52, 20, 60, 28,
            35,  3, 43, 11, 51, 19, 59, 27,
            34,  2, 42, 10, 50, 18, 58, 26,
            33,  1, 41,  9, 49, 17, 57, 25
        };

        public void SetKey(BigInteger n)
        {
            string r = "";
            while (n != 0)
            {
                r = (n % 2 == 0 ? "0" : "1") + r;
                n /= 2;
            }

            Key = r;

            while (Key.Length < 64)
            {
                Key += Key;
            }
        }

        private string shift_left_once(string key_chunk)
        {
            string shifted = "";
            for (int i = 0; i < 28; i++)
            {
                shifted += key_chunk[i];
            }
            shifted += key_chunk[0];
            return shifted;
        }

        private string shift_left_twice(string key_chunk)
        {
            string shifted = "";

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    shifted += key_chunk[j];
                }

                shifted += key_chunk[0];
                key_chunk = shifted;
                shifted = "";
            }
            return key_chunk;
        }

        private void generate_keys()
        {
            // 1. Compressing the key using the PC1 table
            string perm_key = "";

            for (int i = 0; i < 56; i++)
            {
                perm_key += Key[Pc1[i] - 1];
            }

            // 2. Dividing the result into two equal halves
            string left = perm_key.Substring(0, 28);
            string right = perm_key.Substring(28, 28);

            // Generating 16 keys
            for (int i = 0; i < 16; i++)
            {
                // 3.1. For rounds 1, 2, 9, 16 the key_chunks
                // are shifted by one.
                if (i == 0 || i == 1 || i == 8 || i == 15)
                {
                    left = shift_left_once(left);
                    right = shift_left_once(right);
                }

                // 3.2. For other rounds, the key_chunks
                // are shifted by two
                else
                {
                    left = shift_left_twice(left);
                    right = shift_left_twice(right);
                }

                // 4. The chunks are combined
                string combined_key = left + right;
                string round_key = "";
                // 5. Finally, the PC2 table is used to transpose
                // the key bits
                for (int j = 0; j < 48; j++)
                {
                    round_key += combined_key[Pc2[j] - 1];
                }

                RoundKeys[i] = round_key;
            }
        }
        
        public string CryptString(string data)
        {
            // data - обычная строка с символами ASCII. Русского нет!!!
            string hexData = "";
            foreach (var s in data)
            {
                // s - символ из строки. Его переводим в шестнадцатиричную запись. Напр., char('A') = 65 = 0x41
                // Convert.ToString(value, base) - делает из числа 'value' строку, при этом переводит в заданную систему счисления
                string curHex = Convert.ToString((int)s, 16);

                // Если число меньше 0x10, то бязательно добиваем нулём, чтобы было 2 символа
                if (curHex.Length == 1)
                {
                    curHex = "0" + curHex;
                }
                hexData += curHex;
            }

            generate_keys();
            string res = "";
            int blocksCrypted = 0;
            int len = hexData.Length;

            // Идём по блокам, каждый шифруем, добавляем в конец строки-результата, считаем кол-во зашифрованных блоков
            for (int i = 0; i < len / BlockSize; i++)
            {
                res += crypt64(hexData.Substring(i * BlockSize, BlockSize));
                blocksCrypted++;
            }

            // Если зашифровали блоками и ничего не осталось
            if (len - (blocksCrypted * BlockSize) == 0)
            {
                return res;
            }

            // Иначе остался не целый последний блок. Добиваем его нулями, шифруем, добавляем к результирующей строке
            string lastBlock = hexData.Substring(blocksCrypted * BlockSize);
            while (lastBlock.Length < BlockSize)
            {
                lastBlock += "0";
            }
            res += crypt64(lastBlock);
            return res;
        }

        public string DecryptString(string hexData)
        {
            // Аналогично шифровке, но надо развернуть раундовые ключи
            generate_keys();

            // Reversing the round_keys array for decryption
            int i = 15;
            int j = 0;

            while (i > j)
            {
                string temp = RoundKeys[i];
                RoundKeys[i] = RoundKeys[j];
                RoundKeys[j] = temp;
                i--;
                j++;
            }

            string res = "";
            int blocksDecrypted = 0;
            int len = hexData.Length;

            for (i = 0; i < len / BlockSize; i++)
            {
                res += crypt64(hexData.Substring(i * BlockSize, BlockSize));
                blocksDecrypted++;
            }

            // Удаляем нули в конце. Именно два, т.к. за один символ отвечают две цифры. 
            while (res.EndsWith("00"))
            {
                res = res.Remove(res.Length - 2, 2);
            }

            string charRes = "";

            int resLen = res.Length;

            // Переводим строку с шестнадцатиричной записью в строку из символов
            for (i = 0; i < resLen / 2; i++)
            {
                // Берём два символа, Convert.ToInt32(str, base) - делает из строки целое число, с учётом того, что число в строке есть число по основанию base
                charRes += ((char)(Convert.ToInt32(res.Substring(i * 2, 2), 16)));
            }

            return charRes;
        }

        private string convertDecimalToBinary(int dec)
        {
            string binary = "";
            while (dec != 0)
            {
                binary = (dec % 2 == 0 ? "0" : "1") + binary;
                dec = dec / 2;
            }
            while (binary.Length < 4)
            {
                binary = "0" + binary;
            }
            return binary;
        }

        private int convertBinaryToDecimal(string binary)
        {
            int dec = 0;
            int counter = 0;
            int size = binary.Length;
            for (int i = size - 1; i >= 0; i--)
            {
                if (binary[i] == '1')
                {
                    dec += (int)Math.Pow(2, counter);
                }
                counter++;
            }
            return dec;
        }

        private string Xor(string a, string b)
        {
            string result = "";
            int size = b.Length;
            for (int i = 0; i < size; i++)
            {
                if (a[i] != b[i])
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }
            return result;
        }

        private string crypt64(string hex)
        {
            //0. Переводим строку с хексой ("0102ABFE...") в бинарную строку ("1001010101010...")
            string msg_bin = "";
            int hexLen = hex.Length;

            for (int i = 0; i < hexLen / 2; i++)
            {
                // Берём по два символа. Convert.ToInt32(str, 16) - переводит из hex-строки в десятичное число.
                //                       Convert.ToString(value, 2) - переводит из числа в бинарную строку
                string binStr = Convert.ToString(Convert.ToInt32(hex.Substring(i * 2, 2), 16), 2);

                // Если число меньше 0b10000000, то обязательно добиваем начало нулями, чтобы было 8 битов
                while (binStr.Length < 8)
                {
                    binStr = "0" + binStr;
                }

                msg_bin += binStr;
            }

            //1. Applying the initial permutation
            string perm = "";
            for (int i = 0; i < 64; i++)
            {
                perm += msg_bin[InitialPermutation[i] - 1];
            }

            // 2. Dividing the result into two equal halves
            string left = perm.Substring(0, 32);
            string right = perm.Substring(32, 32);

            // The plain text is encrypted 16 times
            for (int i = 0; i < 16; i++)
            {
                string right_expanded = "";

                // 3.1. The right half of the plain text is expanded
                for (int j = 0; j < 48; j++)
                {
                    right_expanded += right[ExpansionTable[j] - 1];
                };  // 3.3. The result is xored with a key

                string xored = Xor(RoundKeys[i], right_expanded);
                string res_ = "";

                // 3.4. The result is divided into 8 equal parts and passed
                // through 8 substitution boxes. After passing through a
                // substituion box, each box is reduces from 6 to 4 bits.
                for (int j = 0; j < 8; j++)
                {
                    // Finding row and column indices to lookup the
                    // substituition box
                    string row1 = xored.Substring(j * 6, 1) + xored.Substring(j * 6 + 5, 1);
                    int row = convertBinaryToDecimal(row1);
                    string col1 = xored.Substring(j * 6 + 1, 1) + xored.Substring(j * 6 + 2, 1) + xored.Substring(j * 6 + 3, 1) + xored.Substring(j * 6 + 4, 1); ;
                    int col = convertBinaryToDecimal(col1);
                    int val = SubstitionBoxes[j, row, col];
                    res_ += convertDecimalToBinary(val);
                }

                // 3.5. Another permutation is applied
                string perm2 = "";
                for (int j = 0; j < 32; j++)
                {
                    perm2 += res_[PermutationTab[j] - 1];
                }

                // 3.6. The result is xored with the left half
                xored = Xor(perm2, left);

                // 3.7. The left and the right parts of the plain text are swapped
                left = xored;

                if (i < 15)
                {
                    string temp = right;
                    right = xored;
                    left = temp;
                }
            }

            // 4. The halves of the plain text are applied
            string combined_text = left + right;
            string ciphertext = "";
            // The inverse of the initial permuttaion is applied
            for (int i = 0; i < 64; i++)
            {
                ciphertext += combined_text[InversePermutation[i] - 1];
            }

            //5. Converting binary to hex notation (for example '010101001' -> 'AF03.....'
            string res = "";
            string qciphertext = ciphertext;
            int len = ciphertext.Length;

            // Переводим бинарные данные в хексовые
            for (int i = 0; i < len / 8; i++)
            {
                // Convert.ToInt32(str, 2) - переводит бинарную строку в целое число
                // Convert.ToString(value, 16) - переводит число в хексовую строку
                string hexStr = Convert.ToString(Convert.ToInt32(qciphertext.Substring(i * 8, 8), 2), 16);

                // Если число меньше 0x10, то бязательно добиваем нулём, чтобы было 2 символа
                if (hexStr.Length == 1)
                {
                    hexStr = "0" + hexStr;
                }
                res += hexStr;
            }

            //And we finally get the cipher text
            return res;
        }
    }
}
