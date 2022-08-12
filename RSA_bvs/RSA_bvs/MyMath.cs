using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace RSA_bvs
{
    class MyMath
    {
        public static bool IsNumberValid(string number)
        {
            if (number[0] < '1' || number[0] > '9')
            {
                return false;
            }
            foreach (var i in number)
            {
                if (i < '0' || i > '9')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool MR_Test(BigInteger p, int iteration = 100)
        {
            if (p < 2)
            {
                return false;
            }
            if (p != 2 && p % 2 == 0)
            {
                return false;
            }
            BigInteger s = p - 1;
            while (s % 2 == 0)
            {
                s /= 2;
            }
            Random rand = new Random();
            for (int i = 0; i < iteration; i++)
            {
                BigInteger a = rand.Next() % (p - 1) + 1;
                BigInteger temp = s;
                BigInteger mod = FastExponentiation(a, temp, p);
                while (temp != p - 1 && mod != 1 && mod != p - 1)
                {
                    mod = mod * mod % p;
                    temp *= 2;
                }
                if (mod != p - 1 && temp % 2 == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static BigInteger FastExponentiation(BigInteger a, BigInteger b, BigInteger n)
        {
            BigInteger cur = b;
            List<BigInteger> bin = new List<BigInteger>();
            while (cur != 1) // бинарный список
            {
                bin.Add(cur % 2);
                cur /= 2;
            }
            bin.Add(1);
            cur = a;
            bin.Reverse(); // переворачиваем список
            for (int i = 1; i < bin.Count; i++) // возведение в степень
            {
                if (bin[i] == 0)
                {
                    cur = BigInteger.Pow(cur, 2) % n;
                }
                else
                {
                    cur = (BigInteger.Pow(cur, 2) * a) % n;
                }
            }
            return cur;
        }

        public static (BigInteger, BigInteger, BigInteger) Evclid(BigInteger A, BigInteger B)
        {
            int count = 0;
            List<BigInteger> arr = new List<BigInteger>();
            while (A % B != 0)
            {
                arr.Add(A / B);
                (A, B) = (B, A % B);
                count++;
            }
            BigInteger x = 0;
            BigInteger y = 1;
            for (int i = count - 1; i >= 0; i--)
            {
                (x, y) = (y, x - y * arr[i]);
            }
            return (B, x, y);
        }

        public static BigInteger GenerateRandomBigInt(int bits)
        {
            Random rand = new Random();
            while (true)
            {
                byte[] data = new byte[bits / 8];
                rand.NextBytes(data);
                BigInteger i = BigInteger.Abs(new BigInteger(data)) * 2;

                if (i % 2 == 0)
                {
                    i++;
                }
                if (MR_Test(i))
                {
                    return i;
                }
            }
        }

        public static bool CheckRSAKeys(BigInteger e, BigInteger d, BigInteger fi)
        {
            return (e * d) % fi == 1;
        }
    }
}
