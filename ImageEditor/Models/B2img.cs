using System;
using System.IO;
using System.Linq;

namespace ImageEditor.Models
{
    public class B2Img
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int[,] Pixels { get; set; }
        
        public static B2Img? Load(string path)
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
            
            var dimensions = lines[0].Split(' ');
            if (dimensions.Length != 2)
            {
                Console.WriteLine("Invalid format: First line must contain exactly two integers.");
                return null;
            }
            
            if (!int.TryParse(dimensions[1], out int width))
            {
                Console.WriteLine("Invalid format: width");
                return null;
            }

            if (!int.TryParse(dimensions[0], out int height))
            {
                Console.WriteLine("Invalid format: height");
                return null;
            }
            
            var pixels = new int[height, width];
            string[] pixelData = lines[1..];
            
            string combinedData = string.Concat(pixelData);


            if (combinedData.Length < width * height)
            {
                Console.WriteLine("Invalid format: not enough pixel data");
                return null;
            }

   
            for (int i = 0; i < width * height; i++)
            {
                int row = i / width; 
                int col = i % width; 

   
                if (!int.TryParse(combinedData[i].ToString(), out int pixelValue) || pixelValue < 0 || pixelValue > 1)
                {
                    Console.WriteLine($"Invalid pixel value at position {i}");
                    return null;
                }
                
                pixels[row, col] = pixelValue;
            }

            return new B2Img { Width = width, Height = height, Pixels = pixels };
        }

        public void Save(string path)
        {
            using StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine($"{Height} {Width}");
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    writer.Write(Pixels[i, j]);
                }
                writer.WriteLine();
            }
        }
    }
}