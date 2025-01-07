using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chips Required to Unlock Master Panel\n");
            Console.WriteLine("1. Try your luck with randomly generated chips.");
            Console.WriteLine("2. Manually enter chips.");
            Console.WriteLine("3. Use example chips: [Blue, Yellow] [Red, Green] [Yellow, Red] [Orange, Purple].");

            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2 && option != 3))
            {
                Console.WriteLine("Invalid input. Please enter 1, 2 or 3.");
            }
        }
    }
}
