using System;

namespace ImageEditor.Models;
using System.IO;

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
        var width = int.Parse(dimensions[0]);
        var height = int.Parse(dimensions[1]);
        
        //Separate image
        var pixels = new int[height, width];
        for (int i = 1; i <= lines.Length; i++)
        {
            
        }
        
        return new B2Img();
    }
}