using System;
using System.IO;
using System.Linq;

namespace ImageEditor.Models
{
    public class B16Img
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int[,] Pixels { get; set; }

        public static B16Img? Load(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return null;
            }

            string[] lines = File.ReadAllLines(path);

            if (lines.Length < 2)
            {
                Console.WriteLine("Invalid format: Not enough lines in the file.");
                return null;
            }
            
            var dimensions = lines[0].Split();
            if (dimensions.Length != 2)
            {
                Console.WriteLine("Invalid format: First line must contain exactly two integers.");
                return null;
            }

            if (!int.TryParse(dimensions[0], out int height) || height <= 0)
            {
                Console.WriteLine("Invalid format: Height must be a positive integer.");
                return null;
            }

            if (!int.TryParse(dimensions[1], out int width) || width <= 0)
            {
                Console.WriteLine("Invalid format: Width must be a positive integer.");
                return null;
            }
            
            int[,] pixels = new int[height, width];
            
            for (int i = 1; i <= height; i++)
            {
                var pixelValues = lines[i].Split().Select(int.Parse).ToArray();

                if (pixelValues.Length != width)
                {
                    Console.WriteLine($"Invalid format: Row {i} does not match expected width {width}.");
                    return null;
                }

                for (int j = 0; j < width; j++)
                {
                    int value = pixelValues[j];
                    
                    if (value < 0 || value > 15)
                    {
                        Console.WriteLine($"Invalid pixel value {value} at row {i}, column {j}. Must be between 0 and 15.");
                        return null;
                    }

                    pixels[i - 1, j] = value;
                }
            }

            return new B16Img { Width = width, Height = height, Pixels = pixels };
        }

        public void Save(string path)
        {
            using StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine($"{Height} {Width}");
            
            for (int i = 0; i < Height; i++)
            {
                string row = string.Join(" ", Enumerable.Range(0, Width).Select(j => Pixels[i, j]));
                writer.WriteLine(row);
            }
        }
    }
}