using System;
using System.Collections.Generic;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose the way to form the bicolor chip series:");
            Console.WriteLine("1. Using bicolor chips made.");
            Console.WriteLine("2. Creating each bicolor chip.");

            int selectedOption;
            while (!int.TryParse(Console.ReadLine(), out selectedOption) ||
                (selectedOption != 1 && selectedOption != 2))
            {
                Console.WriteLine("Incorrect value, please capture the option number, 1 or 2.");
            }
            Console.WriteLine();

            List<ColorChip> generatedColorChips = new List<ColorChip>();
            switch (selectedOption)
            {
                case 1:
                    generatedColorChips = Methods.SelectColorShips();
                    break;
                case 2:
                    generatedColorChips = Methods.CreateColorShips();
                    break;
            }

            // FINAL VALIDATION 
            var firstColorChip = generatedColorChips[0];
            var lastColorChip = generatedColorChips[generatedColorChips.Count - 1];

            if (firstColorChip.StartColor == Color.Blue && lastColorChip.EndColor == Color.Green)
            {
                Console.WriteLine("The master panel has been unlocked, you can now access your home.");
            }
            else
            {
                Console.WriteLine(Constants.ErrorMessage);
            }
        }
    }
}
