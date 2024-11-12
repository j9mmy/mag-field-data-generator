using System.Text;
using System.Globalization;

class Program
{
    static void Main()
    {
        try
        {
            Directory.CreateDirectory("data");
            
            Console.WriteLine("Enter the number of rows you want to generate: ");
            if (!long.TryParse(Console.ReadLine(), out long rowAmount))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                PauseBeforeExit();
                return;
            }

            Console.WriteLine("\nEnter the minimum value (use . or , as decimal separator): ");
            if (!double.TryParse(Console.ReadLine(), 
                NumberStyles.Any, 
                CultureInfo.InvariantCulture, 
                out double min))
            {
                Console.WriteLine("Invalid minimum value.");
                PauseBeforeExit();
                return;
            }

            Console.WriteLine("\nEnter the maximum value (use . or , as decimal separator): ");
            if (!double.TryParse(Console.ReadLine(), 
                NumberStyles.Any, 
                CultureInfo.InvariantCulture, 
                out double max) || max <= min)
            {
                Console.WriteLine("Invalid maximum value. Must be greater than minimum.");
                PauseBeforeExit();
                return;
            }

            Console.WriteLine("\nGenerating data...");
            GenerateData(rowAmount, min, max);
            PauseBeforeExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            File.AppendAllText("error.log", $"{DateTime.Now}: {ex}\n");
            PauseBeforeExit();
        }
    }

    private static void PauseBeforeExit()
    {
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    private static void GenerateData(long rowAmount, double min, double max)
    {
        double range = max - min;
        
        using var writer = new StreamWriter("data/results.csv", false, Encoding.UTF8, 65536);
        var sb = new StringBuilder(50);
        var random = new Random();
    
        try
        {
            writer.WriteLine("Sample,Y AXIS Results (mT)");
            
            long updateFrequency = Math.Max(1, rowAmount / 1000);
            
            for (long i = 0; i < rowAmount; i++)
            {
                double result = (random.NextDouble() * range) + min;
                sb.Clear()
                  .Append(i)
                  .Append(',')
                  .Append(result.ToString(System.Globalization.CultureInfo.InvariantCulture));
                writer.WriteLine(sb);
    
                if (i % updateFrequency == 0)
                {
                    Console.Write($"\rGenerating... {(i * 100.0 / rowAmount):F1}%");
                }
            }
            
            Console.Write("\rGenerating... 100.0%");
            Console.WriteLine("\nData has been written to data/results.csv");
        }
        catch
        {
            File.Delete("data/results.csv");
            throw;
        }
    }
}