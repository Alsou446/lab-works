using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections.Generic;
using System.Globalization;

namespace Decripter
{
    internal class MyMath
    {
        static Random rand = new Random();

        public static BigInteger SqrtFast(BigInteger value)
        {
            if (value <= 4503599761588223UL) // small enough for Math.Sqrt() or negative?
            {
                if (value.Sign < 0) throw new ArgumentException("Negative argument.");
                return (ulong)Math.Sqrt((ulong)value);
            }

            BigInteger root; // now filled with an approximate value
            int byteLen = value.ToByteArray().Length;
            if (byteLen < 128) // small enough for direct double conversion?
            {
                root = (BigInteger)Math.Sqrt((double)value);
            }
            else // large: reduce with bitshifting, then convert to double (and back)
            {
                root = (BigInteger)Math.Sqrt((double)(value >> (byteLen - 127) * 8)) << (byteLen - 127) * 4;
            }

            for (; ; )
            {
                var root2 = value / root + root >> 1;
                if ((root2 == root || root2 == root + 1) && IsSqrt(value, root)) return root;
                root = value / root2 + root2 >> 1;
                if ((root == root2 || root == root2 + 1) && IsSqrt(value, root2)) return root2;
            }
        }

        private static bool IsSqrt(BigInteger value, BigInteger root)
        {
            var lowerBound = root * root;

            return value >= lowerBound && value <= lowerBound + (root << 1);
        }

        public static BigInteger LogGelfond_Shenks(BigInteger a, BigInteger b, BigInteger m)
        {
            BigInteger n = SqrtFast(m) + 1;

            BigInteger an = 1;
            for (BigInteger i = 0; i < n; i++)
            {
                an = (an * a) % m;
            }

            Dictionary<BigInteger, BigInteger> vals = new Dictionary<BigInteger, BigInteger>();
            for (BigInteger i = 1, cur = an; i <= n; i++)
            {
                if (!vals.ContainsKey(cur))
                {
                    vals[cur] = i;
                }
                cur = (cur * an) % m;
            }

            for (BigInteger i = 0, cur = b; i <= n; i++)
            {
                if (vals.ContainsKey(cur))
                {
                    BigInteger ans = vals[cur] * n - i;
                    if (ans < m)
                    {
                        return ans;
                    }
                }
                cur = (cur * a) % m;
            }

            return -1;
        }

        public static BigInteger Inverse(BigInteger a, BigInteger n)
        {
            return Evclid(a, n).Item2;
        }


        public static (BigInteger, BigInteger, BigInteger) Xab(BigInteger x, BigInteger a, BigInteger b, BigInteger G, BigInteger H, BigInteger P, BigInteger Q)
        {
            BigInteger sub = x % 3;

            if (sub == 0)
            {
                x = x * G % P;
                a = (a + 1) % Q;
            }

            if (sub == 1)
            {
                x = x * H % P;
                b = (b + 1) % Q;
            }

            if (sub == 2)
            {
                x = x * x % P;
                a = a * 2 % Q;
                b = b * 2 % Q;
            }

            return (x, a, b);
        }
        BigInteger RoPollard(BigInteger G, BigInteger H, BigInteger P)
        {
            BigInteger Q = (P - 1) / 2;
            BigInteger x = G * H;
            BigInteger a = 1;
            BigInteger b = 1;
            BigInteger X = x;
            BigInteger A = a;
            BigInteger B = b;

            for (BigInteger i = 1; i < P; i++)
            {
                (x, a, b) = Xab(x, a, b, G, H, P, Q);

                (X, A, B) = Xab(X, A, B, G, H, P, Q);
                (X, A, B) = Xab(X, A, B, G, H, P, Q);

                if (x == X)
                {
                    break;
                }
            }

            BigInteger nom = (a - A);
            BigInteger denom = (B - b);

            BigInteger inv = Inverse(denom, Q);

            if (inv < 0)
            {
                inv += Q;
            }

            return (inv * nom) % Q;
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

        public static BigInteger GetPrimitive(BigInteger p)
        {
            List<BigInteger> fact = new List<BigInteger>();
            BigInteger fi = p - 1;

            FactorizePollard(ref fact, fi);

            if (fi > 1)
            {
                fact.Add(fi);
            }

            for (BigInteger res = BigInteger.Pow(2, 15); res <= p; res++)
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

        public static BigInteger GenerateRandomSimpleBigInt(int bits)
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


        public static BigInteger roPollard (BigInteger g, BigInteger A, BigInteger p)
        {
            if (g != GetPrimitive(p))
            {
                return -1;
            }
            return LogGelfond_Shenks (g, A, p);
        }

        public static int BitLength (BigInteger n)
        {
            int bitLength = 0;

            do
            {
                bitLength++;
                n /= 2;
            } while (n != 0);

            return bitLength;
        }

        public static BigInteger RandBigint( BigInteger a, BigInteger b)
        {
            int bitB = BitLength (b);
            Random rand = new Random ();
            int bit = rand.Next(8, bitB);
            BigInteger r = MyMath.GenerateRandomBigInt (bit);
            while (r > b || r == 0)
            {
                r = MyMath.GenerateRandomBigInt(bit);
            }
            return r;
        }

        public static BigInteger GcdLocal(BigInteger a, BigInteger b)
        {
            BigInteger remainder;
            while (a % b != 0)
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }
            return b;
        }

        public static BigInteger FastPow(BigInteger base_, BigInteger k, BigInteger N)
        {
            if (k == 0)
            {
                return 1;
            }
            if (k == 1)
            {
                return base_;
            }

            BigInteger half = FastPow(base_, k / 2, N);

            if (k % 2 == 0)
            {
                return ((half * half) % N);
            }
            else
            {
                BigInteger value = ((((half * half) % N) * base_) % N);
                return value;
            }
        }

        public static BigInteger pollardP1_v1(BigInteger N)
        {
            if (N % 2 == 0)
            {
                return 2;
            }
            if (MR_Test(N))
            {
                return N;
            }
            BigInteger a = 71;
            int k = 2;
            BigInteger factorial_product = BigInteger.Pow(a, k);
            BigInteger gcd_value = GcdLocal((factorial_product) - 1, N);
            bool overflow = false;

            while (gcd_value == 1)
            {
                k++;
                factorial_product = FastPow(factorial_product, k, N);

                if (factorial_product == 0)
                {
                    overflow = true;
                    break;
                }
                gcd_value = GcdLocal((factorial_product) - 1, N);
            }

            if (!overflow)
            {
                BigInteger divisor = Gcd(factorial_product - 1, N);
                return divisor;
            }
            else
            {
                return 1;
            }
        }

        public static BigInteger ferma(BigInteger n)
        {
            if (n % 2 == 0)
            {
                return 2;
            }
            if (MR_Test(n))
            {
                return n;
            }

            BigInteger x = SqrtFast(n);
            BigInteger y = 0;
            BigInteger r = x * x - y * y - n;

            while (true)
            {
                if (r == 0)
                {
                    return x != y ? x - y : x + y;
                }

                else
                {
                    if (r > 0)
                    {
                        r -= y + y + 1;
                        y++;
                    }
                    else
                    {
                        r += x + x + 1;
                        x++;
                    }
                }
            }
        }
    }
}
