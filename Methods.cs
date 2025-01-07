using System;
using System.Collections.Generic;

namespace ChipSecuritySystem
{
    internal static class Methods
    {
        public static List<ColorChip> SelectColorShips()
        {
            List<ColorChip> colorChipsOptions = new List<ColorChip>();
            colorChipsOptions.Add(new ColorChip(Color.Blue, Color.Yellow));
            colorChipsOptions.Add(new ColorChip(Color.Red, Color.Green));
            colorChipsOptions.Add(new ColorChip(Color.Yellow, Color.Red));
            colorChipsOptions.Add(new ColorChip(Color.Orange, Color.Purple));

            Console.WriteLine("Select 3 chips from the following collection:");
            int optionsCount = 1;
            foreach (var colorChipOption in colorChipsOptions)
            {
                Console.WriteLine($"{optionsCount}. [{colorChipOption.StartColor}, {colorChipOption.EndColor}]");
                optionsCount++;
            }

            List<ColorChip> result = new List<ColorChip>();
            while (result.Count < 3)
            {
                int selectedOption;
                while (!int.TryParse(Console.ReadLine(), out selectedOption) ||
                    (selectedOption < 1 || selectedOption > 4))
                {
                    Console.WriteLine("Incorrect value, please capture a correct option number");
                }
                result.Add(colorChipsOptions[selectedOption - 1]);

                Console.WriteLine("\nSelected Color Chips:");
                foreach(var item in result)
                {
                    Console.WriteLine($"[{ item.StartColor}, {item.EndColor}]");
                }
                Console.WriteLine("Select another color chip:");
            }
            Console.WriteLine();
            return result;
        }

        public static List<ColorChip> CreateColorShips()
        {
            List<ColorChip> result = new List<ColorChip>();
            Console.WriteLine("Enter the colors according to the options presented, to generate three bicolor chips:");

            int enumCount = 1;
            foreach (var color in Enum.GetValues(typeof(Color)))
            {
                Console.WriteLine(enumCount.ToString() + ". " + color.ToString());
                enumCount++;
            }
            Console.WriteLine();

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Chip {i}:");
                Color startColor = SetChipColor("Start Color: ");
                Color endColor = SetChipColor("End Color: ");
                result.Add(new ColorChip(startColor, endColor));
                Console.WriteLine();
            }
            return result;
        }

        #region privateMethods
        private static Color SetChipColor(string chipColorType)
        {
            Console.Write(chipColorType);

            int colorNumber;
            while (!int.TryParse(Console.ReadLine(), out colorNumber) ||
                (colorNumber < 1 && colorNumber > Enum.GetValues(typeof(Color)).Length))
            {
                Console.WriteLine("Incorrect value, please try again.");
                Console.Write(chipColorType);
            }

            return (Color)Enum.GetValues(typeof(Color)).GetValue(colorNumber - 1);
        }
        #endregion
    }
}
