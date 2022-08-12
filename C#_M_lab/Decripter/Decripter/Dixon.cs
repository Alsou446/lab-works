using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Decripter
{
    internal class Dixon
    {
        public static BigInteger DixonFactorization(BigInteger n)
        {
            double L = Math.Exp(Math.Sqrt(BigInteger.Log(n) * Math.Log(BigInteger.Log(n))));
            int k = (int)Math.Sqrt(L);
            List<int> prime_base = Primes(k);
            int prime_base_size = prime_base.Count;

            List<BigInteger> X = new List<BigInteger>();
            List<List<int>> Q_x_exponents = new List<List<int>>();
            List<List<int>> V = new List<List<int>>();
            BigInteger x_i = MyMath.SqrtFast(n) + 1;


            while (x_i <= n)
            {
                Console.WriteLine("step 1");

                while (true)
                {
                    List<int> vector = new List<int>();
                    for (int i = 0; i < prime_base_size; i++)
                    {
                        vector.Add(0);
                    }

                    List<int> Q_x_i_exponents = new List<int>();
                    for (int i = 0; i < prime_base_size; i++)
                    {
                        Q_x_i_exponents.Add(0);
                    }
                    BigInteger Q_x_i = (x_i * x_i - n) % n;


                    for (int j = 0; j < prime_base_size; j++)
                    {
                        int p_j = prime_base[j];
                        while (Q_x_i % p_j == 0 && Q_x_i != 0)
                        {
                            Q_x_i = (BigInteger)Q_x_i / p_j;
                            vector[j] = (vector[j] + 1) % 2;
                            Q_x_i_exponents[j] = Q_x_i_exponents[j] + 1;
                        }
                        if (Q_x_i == 1)
                        {
                            X.Add(x_i);
                            x_i++;
                            V.Add(vector);
                            Q_x_exponents.Add(Q_x_i_exponents);
                            break;
                        }
                    }

                    if (X.Count >= prime_base_size)
                    {
                        break;
                    }
                    x_i++;
                }


                double[,] A = new double[V[0].Count, V.Count];
                for (int i = 0; i < V.Count; i++)
                {
                    for (int j = 0; j < V[i].Count; j++)
                    {
                        A[j, i] = V[i][j];
                    }
                }

                MatrixBuilder<double> M = Matrix<double>.Build;
                Matrix<double> m = M.DenseOfArray(A);


                int q_size = A.GetLength(1);
                MathNet.Numerics.LinearAlgebra.Vector<double> K = null;

                for (int i = 1; i < Math.Pow(2, q_size); i++)
                {
                    MathNet.Numerics.LinearAlgebra.Vector<double> cur_q = MathNet.Numerics.LinearAlgebra.Vector<double>.Build.Dense(MyMath.BitLength((BigInteger)Math.Pow(2, q_size)) - 1);
                    string binary = Convert.ToString(i, 2);
                    for (int j = binary.Length - 1, r = cur_q.Count - 1; j != -1; j--, r--)
                    {
                        cur_q[r] = double.Parse(binary[j].ToString());
                    }

                    MathNet.Numerics.LinearAlgebra.Vector<double> cur_res = m * cur_q;

                    if (cur_res.Sum() != 0 && (cur_res % 2).Sum() == 0)
                    {
                        K = cur_q;
                        break;
                    }

                }
                if (K == null)
                {
                    continue;
                }
                Console.WriteLine("step 2");
                int K_size = K.Count;

                BigInteger x = 1;
                BigInteger y = 1;
                for (int j = 1; j < K_size; j++)
                {
                    MathNet.Numerics.LinearAlgebra.Vector<double> K_vect = K;
                    List<BigInteger> y_ecponent_vect = new List<BigInteger>();

                    for (int i = 0; i < prime_base_size; i++)
                    {
                        y_ecponent_vect.Add(0);
                    }

                    for (int kq = 0; kq < X.Count; kq++)
                    {
                        if (K_vect[kq] == 1)
                        {
                            BigInteger x_factor = X[kq];

                            for (int l = 0; l < prime_base_size; l++)
                            {
                                y_ecponent_vect[l] += Q_x_exponents[kq][l];
                            }
                            x = (x * x_factor) % n;
                        }
                    }
                    for (int l = 0; l < prime_base_size; l++)
                    {
                        y = (y * MyMath.FastExponentiation(prime_base[l], y_ecponent_vect[l] / 2, n)) % n;
                    }


                }

                if (x != y && x != n - y)
                {
                    BigInteger d = BigInteger.GreatestCommonDivisor(x + y, n);
                    return d;
                }
                x_i++;
                if (x_i % 100 == 0)
                {
                    Console.WriteLine(x_i / 100 + " / " + (int)(n / 100));
                }
            }

            return n;
        }

        public static List<int> Primes (int t)
        {
            List<int> primes = new List<int>() { 2, 3, 5 };
            if (t <= 5)
            {
                return primes;
            }
            BigInteger p1 = 6;
            int p2 = 6;
            while (true)
            {
                if (p2 > t)
                {
                    break;
                }
                if (MyMath.MR_Test(p1) == true)
                {
                    primes.Add(p2);
                }
                p1++;
                p2++;
            }
            return primes;
        }

    }
}
