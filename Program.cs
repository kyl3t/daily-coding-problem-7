using System;
using System.Linq;

namespace dcp7
{
    static class Program
    {
        static void Main(string[] args)
        {
            var result1 = Decode("1");
            var result2 = Decode("11");
            var result3 = Decode("111");
            var result4 = Decode("112");
            var result5 = Decode("1122");
            var result6 = Decode("1122222");
            var result7 = Decode("22112246");

            Console.WriteLine($"Decode Result 1: {result1}");
            Console.WriteLine($"Decode Result 11: {result2}");
            Console.WriteLine($"Decode Result 111: {result3}");
            Console.WriteLine($"Decode Result 112: {result4}");
            Console.WriteLine($"Decode Result 1122: {result5}");
            Console.WriteLine($"Decode Result 1122222: {result6}");
            Console.WriteLine($"Decode Result 22112246: {result7}");

            while(true);
        }

        static int Decode(string code)
        {
            if (!Int32.TryParse(code, out int numericalCode) || code.First() == '0')
            {
                throw new ArgumentException("Not a valid argument.");
            }

            var count = 0;
            if (code.Length > 2)
            {
                count += IsLetter(int.Parse(code.Substring(0, 2))) ? Decode(code.Substring(2, code.Length - 2)) : 0;
                count += Decode(code.Substring(1, code.Length - 1));
            }
            else if (code.Length == 2)
            {
                count += IsLetter(int.Parse(code)) ? 2 : 1;
            }
            else if (code.Length == 1)
            {
                count = 1;
            }

            return count;
        }

        static bool IsLetter(int numericalCode)
        {
            return numericalCode <= 26 && numericalCode >= 1;
        }

    }
}
