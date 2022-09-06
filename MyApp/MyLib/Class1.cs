
namespace MyLib
{
    public class Figure
    {
        public static int CalculateArea(int r) => (int)(Math.PI * r * r);

        public static int CalculateArea(int a, int b, int c)
        {
            if (a == 0 || b == 0 || c == 0)
            {
                return 0;
            }

            if (a >= b + c || b >= a + c || c >= a + b)
            {
                return 0;
            }

            double p = (a + b + c) / 2;

            return (int)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public static bool isRightTriangle(int a, int b, int c)
        {
            return (a * a == b * b + c * c || b * b == a * a + c * c || c * c == a * a + b * b);
        }
    }

}