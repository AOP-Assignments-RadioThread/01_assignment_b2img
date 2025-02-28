using System;

namespace ImageEditor.Models;
using System.IO;
using System.Linq;

public class B2Img
{
    private int Width { get; set; }
    private int Height { get; set; }
    private int[,] Pixels { get; set; }

    public static B2Img Load(string path)
    {
        //Load file into memory
        string[] lines = File.ReadAllLines(path);
        if (lines.Length < 2) throw new Exception("Invalid format");

        //Find dimensions
        var dimensions = lines[0].Split(',');
        if (dimensions.Length != 2 )throw new Exception("Invalid format");
        //TODO: Change to try parse 
        int.TryParse(dimensions[0], out int width);
        int.TryParse(dimensions[1], out int height);
        
        //Separate image
        var pixels = new int[height, width];
        string pixelData = lines[1];

        for (int i = 1; i <= height; i++)
        {
            for (int j = 1; j <= width; j++)
            {
                pixels[i, j] = pixelData[i * width + j] == '1' ? 1 : 0;
            }
        }
        
        return new B2Img { Width = width, Height = height, Pixels = pixels };
    }

    public void Save (string path)
    {
        using(StreamWriter writer = new StreamWriter(path))
        {
            //Write pixel data
            writer.WriteLine($"{Height} {Width}");
            for (int i = 1; i <= Height; i++)
            {
                for (int j = 1; j <= Height; j++)
                {
                    writer.Write(Pixels[i, j]);
                }
            }
        }
    }
}