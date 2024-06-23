using System;
namespace TemperaturesComparisonApp
  {
class Program {
  public static void Main (string[] args) {

                const int NumTemperatures = 5;
                const int MinTemp = -30;
                const int MaxTemp = 130;

                int[] temperatures = new int[NumTemperatures];

                for (int i = 0; i < NumTemperatures; i++)
                {
                    temperatures[i] = GetValidTemperature(i + 1, MinTemp, MaxTemp);
                }

                string orderMessage = GetOrderMessage(temperatures);
                double average = GetAverage(temperatures);

                Console.WriteLine("\n5-day Temperatures entered:");
                foreach (var temp in temperatures)
                {
                    Console.WriteLine(temp);
                }
                Console.WriteLine($"\n{orderMessage}");
                Console.WriteLine($"Average temperature: {average:F2}");
            }
            static int GetValidTemperature(int index, int min, int max)
            {
                int temp;
                Console.Write($"Enter temperature {index} (between {min} and {max}): ");
                while (!int.TryParse(Console.ReadLine(), out temp) || temp < min || temp > max)
                {
                    Console.Write($"Invalid input. Enter temperature {index} (between {min} and {max}): ");
                }
                return temp;
            }

            static string GetOrderMessage(int[] temps)
            {
                bool isGettingWarmer = true;
                bool isGettingCooler = true;

                for (int i = 1; i < temps.Length; i++)
                {
                    if (temps[i] <= temps[i - 1])
                    {
                        isGettingWarmer = false;
                    }
                    if (temps[i] >= temps[i - 1])
                    {
                        isGettingCooler = false;
                    }
                }

                if (isGettingWarmer)
                {
                    return "Getting warmer";
                }
                else if (isGettingCooler)
                {
                    return "Getting cooler";
                }
                else
                {
                    return "It's a mixed bag";
                }
            }

            static double GetAverage(int[] temps)
            {
                double total = 0;
                foreach (var temp in temps)
                {
                    total += temp;
                }
                return total / temps.Length;
            }
        }
    }