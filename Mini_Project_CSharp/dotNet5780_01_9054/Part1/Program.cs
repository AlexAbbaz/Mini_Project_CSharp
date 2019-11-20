using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[20];
            int[] B = new int[20];
            int[] C = new int[20];

            Random rA = new Random(1);
            Random rB = new Random(2);

            for (int i = 0; i < 20; ++i)
            {
                A[i] = rA.Next(18, 122);
                B[i] = rB.Next(18, 122);

                if (A[i] > B[i])
                    C[i] = A[i] - B[i];
                else
                    C[i] = B[i] - A[i];
            }

            for (int i = 0; i < 20; ++i)
                Console.Write("{0,-3}", A[i]);

            Console.Write("\r\n");

            for (int i = 0; i < 20; ++i)
                Console.Write("{0,-3}", B[i]);

            Console.Write("\r\n");

            for (int i = 0; i < 20; ++i)
                Console.Write("{0,-3}", C[i]);

            Console.ReadKey();
        }
    }
}
