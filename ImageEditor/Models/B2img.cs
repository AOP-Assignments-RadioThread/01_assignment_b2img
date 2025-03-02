using System;

namespace ImageEditor.Models;
using System.IO;
using System.Linq;

public class B2Img
{
    public int Width { get; set; }
    public int Height { get; set; } 
    public int[,] Pixels { get; set; }

    public static B2Img Load(string path)
    {
        //Load file into memory
        string[] lines = File.ReadAllLines(path);
        if (lines.Length < 2) throw new Exception("Invalid format");

        //Find dimensions
        var dimensions = lines[0].Split(' ');
        if (dimensions.Length != 2) throw new Exception("Invalid format");
     
        if (int.TryParse(dimensions[1], out int width))
        {
            Console.WriteLine($"Width parsed successfully: {width}");
        }
        else
        {
            throw new Exception("Invalid format: width");
        }
    
        if (int.TryParse(dimensions[0], out int height))
        {
            Console.WriteLine($"Width parsed successfully: {height}");
        }
        else
        {
            throw new Exception("Invalid format: height");
        }

        
        // Separate image
        var pixels = new int[height, width];
        string[] pixelData = lines[1..];

        // Combine all pixel lines into one continuous string
        string combinedData = string.Concat(pixelData);

        // Check if there are enough characters to fill the image
        if (combinedData.Length < width * height)
            throw new Exception("Invalid format: not enough pixel data");

        // Parse pixel data sequentially into the 2D array
        for (int i = 0; i < width * height; i++)
        {
            int row = i / width; // integer division gives the current row
            int col = i % width; // remainder gives the column within the row
            pixels[row, col] = int.Parse(combinedData[i].ToString());
        }

        return new B2Img { Width = width, Height = height, Pixels = pixels };
       
    }
  
    public void Save (string path)
    {
        using(StreamWriter writer = new StreamWriter(path))
        {
            //Write pixel data
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
