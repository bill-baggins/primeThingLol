using System;
using System.IO;
using System.Collections.Generic;
namespace PublicKeyCryptography
{
    class Program
    {
        static IEnumerable<ulong> primeNumberGenerator(ulong n)
        {
            bool[] pno = new bool[n+1];
            Array.Fill(pno, true);
            for(ulong i = 2; i*i <= n; i++)
            {
                if(pno[i])
                {
                    for(ulong j = i*2; j <= n; j += i)
                    {
                        pno[j] = false;
                    }
                }
            }
            for(ulong i = 0; i<=n; i++)
            {
                if(pno[i])
                {
                    yield return i;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter in a number, and the numbers will be written to a file called 'primes.txt'.");
            string response = Console.ReadLine();
            ulong bigThing = UInt64.Parse(response);
            using(StreamWriter file = new StreamWriter("./primes.txt"))
            {
                foreach(int num in primeNumberGenerator(bigThing))
                {
                    file.Write("{0} ", num.ToString());
                }
            }
           Console.WriteLine("Success! Check your directory for the 'primes.txt' file.");
           Console.ReadLine();
        }
    }
}
