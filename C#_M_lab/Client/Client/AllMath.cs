using System;
using System.Collections.Generic;
using System.Numerics;

namespace Client
{
    internal class AllMath
    {
        static Random rand = new Random();

        public static bool CSh_Test(BigInteger p, int iteration = 100) // Тест на простоту Соловея-Штрасса
        {
            if (p < 2)
            {
                return false;
            }
            if (p != 2 && p % 2 == 0)
            {
                return false;
            }
            Random rand = new Random();
            for (int i = 0; i < iteration; i++)
            {
                BigInteger a = rand.Next() % (p - 1) + 1;
                BigInteger jacobian = (p + Jacobian(a, p)) % p;
                BigInteger mod = FastExponentiation(a, (p - 1) / 2, p);
                if (jacobian == 0 || mod != jacobian)
                {
                    return false;
                }
            }
            return true;
        }

        public static int Jacobian(BigInteger a, BigInteger n)
        {
            if (a == 0)
            {
                return 0;
            }
            int ans = 1;
            if (a < 0)
            {
                a = -a;
                if (n % 4 == 3)
                {
                    ans = -ans;
                }
            }
            if (a == 1)
            {
                return ans;
            }
            while (a != 0)
            {
                if (a < 0)
                {
                    a = -a;
                    if (n % 4 == 3)
                    {
                        ans = -ans;
                    }
                }
                while (a % 2 == 0)
                {
                    a /= 2;
                    if (n % 8 == 3 || n % 8 == 5)
                    {
                        ans = -ans;
                    }
                }
                (a, n) = (n, a);
                if (a % 4 == 3 && n % 4 == 3)
                {
                    ans = -ans;
                }
                a %= n;
                if (a > n / 2)
                {
                    a -= n;
                }
            }
            if (n == 1)
            {
                return ans;
            }
            return 0;
        }

        public static BigInteger FastExponentiation(BigInteger a, BigInteger b, BigInteger n) //Быстрое возведение в степень
        {
            // BigInteger cur = b;
            // List<BigInteger> bin = new List<BigInteger>();
            // while (cur != 1) // бинарный список
            // {
            //     bin.Add(cur % 2);
            //     cur /= 2;
            // }
            // bin.Add(1);
            // cur = a;
            // bin.Reverse(); // переворачиваем список
            // for (int i = 1; i < bin.Count; i++) // возведение в степень
            // {
            //     if (bin[i] == 0)
            //     {
            //         cur = BigInteger.Pow(cur, 2) % n;
            //     }
            //     else
            //     {
            //         cur = (BigInteger.Pow(cur, 2) * a) % n;
            //     }
            // }
            // return cur;
            BigInteger res = 1;
            while (b > 0)
            {
                if ((b & 1) > 0)
                {
                    res = res * 1 * a % n;
                    b--;
                }
                else
                {
                    a = a * 1 * a % n;
                    b >>= 1;
                }
            }

            return res;
        }

        public static (BigInteger, BigInteger, BigInteger) Evclid(BigInteger A, BigInteger B)//Расширенный алгаритм Евклида
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

        public static BigInteger Gcd(BigInteger m, BigInteger n)
        {
            // return m != 0 ? Gcd(n % m, m) : n;
            while (m > 0 && n > 0)
            {
                if (m > n)
                {
                    m %= n;
                }
                else
                {
                    n %= m;
                }
            }

            return m + n;
        }

        public static (BigInteger, BigInteger, BigInteger) RSA_generate(int bits)
        {
            BigInteger p = GenerateRandomSimpleBigInt(bits);

            BigInteger q = GenerateRandomSimpleBigInt(bits);

            BigInteger n = p * q;

            // Ф-ия Эйлера
            BigInteger fi = (p - 1) * (q - 1);

            BigInteger e_ = 0;

            BigInteger x, y, gcd;

            while (true)
            {
                BigInteger e = GenerateRandomSimpleBigInt(bits);
                if (e < 2 || e >= n)
                {
                    continue;
                }

                (gcd, x, y) = Evclid(e, fi);

                if (gcd == 1)
                {
                    e_ = e;
                    break;
                }
            }

            (x, y, gcd) = Evclid(e_, fi);

            BigInteger d = y; // Обратный к 'e' по модулю 'fi' элемент, т.е. e * d mod fi = 1
            if (d < 0)
            {
                d += fi;
            }
            return (n, e_, d);
        }

        public static BigInteger GenerateRandomSimpleBigInt(int bits)
        {
            DateTime dateTime = DateTime.Now;
            Random rand = new Random((int)dateTime.Ticks);
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

        public static BigInteger GenerateRandomBigInt(int bits)
        {
            bits = bits > 8 ? bits : 8;
            byte[] data = new byte[bits / 8];
            rand.NextBytes(data);
            BigInteger dt = new BigInteger(data);
            BigInteger i = BigInteger.Abs(dt);
            return i;
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

        public static BigInteger Pollard(BigInteger n)//Факторизация
        {
            int bits = (int)Math.Ceiling(BigInteger.Log(n, 2) / 2);
            BigInteger x = GenerateRandomBigInt(bits);
            x = x % n;
            BigInteger y = 1;
            int i = 0;
            int stage = 2;
            while (Gcd(n, BigInteger.Abs(x - y)) == 1)
            {
                if (i == stage)
                {
                    y = x;
                    stage = stage * 2;
                }
                x = (x * x + 1) % n;
                i++;
            }
            return Gcd(n, BigInteger.Abs(x - y));
        }

        public static void FactorizePollard(ref List<BigInteger> list, BigInteger n)
        {
            BigInteger p = Pollard(n);
            BigInteger q = n / p;

            if (CSh_Test(p))
            {
                list.Add(p);
            }
            else if (p != 1)
            {
                FactorizePollard(ref list, p);
            }

            if (CSh_Test(q))
            {
                list.Add(p);
            }
            else if (q != 1)
            {
                FactorizePollard(ref list, q);
            }
        }

        public static BigInteger GetPrimitive(BigInteger p)
        {
            List<BigInteger> fact = new List<BigInteger>();
            BigInteger fi = p - 1;

            FactorizePollard(ref fact, fi);

            if (fi > 1)
            {
                fact.Add(fi);
            }

            for (BigInteger res = BigInteger.Pow(2, 63); res <= p; res++)
            {
                bool ok = true;
                for (int i = 0; i < fact.Count && ok; i++)
                {
                    ok &= FastExponentiation(res, fi / fact[i], p) != 1;
                }
                if (ok)
                {
                    return res;
                }
            }
            return -1;
        }
    }
}
