﻿using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ImageEditor.Models;

namespace ImageEditor.ViewModels;
using System.Collections.ObjectModel;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<PixelViewModel> Pixels { get; }

    public int GridColumns { get; set; } = 5;
    public int GridRows { get; set; } = 5;
    public string ImagePath { get; set; } = "";
    public ICommand SaveCommand { get; set; }


    public MainWindowViewModel()
    { 
        SaveCommand = new RelayCommand(SaveCurrentState);
        Pixels = new ObservableCollection<PixelViewModel>();
        ImagePath = "/Users/victorpetrica/Desktop/AOP shit/Assignments/01_assignment_b2img/ImageEditor/Assets/image.txt";
        B2Img test = B2Img.Load(ImagePath);
        
        // Print the dimensions of the image
        Console.WriteLine($"Width: {test.Width}. \nHeight: {test.Height}");
        Console.WriteLine();
        
     
        GridRows = test.Pixels.GetLength(0);
        GridColumns = test.Pixels.GetLength(1);

        for (int i = 0; i < GridRows; i++)
        {
            for (int j = 0; j < GridColumns; j++)
            {
                bool state;
                // Print each element followed by a space
                Console.Write(test.Pixels[i, j] + " ");
                if (test.Pixels[i, j] == 0)
                {
                    state = false;
                }
                else
                {
                    state = true;
                }
                Pixels.Add(new PixelViewModel(initialState: state));
            }
            // Move to the next line after each row
            Console.WriteLine();
        }
    }

    public void SaveCurrentState()
    {
        var updatedPixels = new int[GridRows, GridColumns];

        for (int i = 0; i < GridRows; i++)
        {
            for (int j = 0; j < GridColumns; j++)
            {
                var pixel = Pixels[i * GridColumns + j];
                updatedPixels[i, j] = pixel.IsActive ? 1 : 0;
            }
        }

        B2Img newImage = new B2Img
        {
            Width = GridColumns,
            Height = GridRows,
            Pixels = updatedPixels
        };
        
        newImage.Save(ImagePath);

    }
}