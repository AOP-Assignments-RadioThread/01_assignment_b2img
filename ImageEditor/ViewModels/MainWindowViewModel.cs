using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImageEditor.Models;
using ImageEditor.Services;

namespace ImageEditor.ViewModels;
using System.Collections.ObjectModel;

public partial class MainWindowViewModel : ObservableObject
{
    public ObservableCollection<PixelViewModel> FirstImage { get; }
    public ObservableCollection<PixelViewModel> SecondImage { get; }
    
    private readonly IDialogService _dialogService;
    [ObservableProperty]
    private string? _filePathB2img;
    [ObservableProperty]
    private string? _filePathB16img;


    [ObservableProperty] private int _selectedColorFirst = 0;
    [ObservableProperty] private int _selectedColorSecond = 0;

    [ObservableProperty] private int _gridColumnsFirst;
    [ObservableProperty] private int _gridRowsFirst;
    
    [ObservableProperty] private int _gridColumnsSecond;
    [ObservableProperty] private int _gridRowsSecond;
    
    


    public MainWindowViewModel(IDialogService dialogService)
    {

        _dialogService = dialogService;
        
        FirstImage = new ObservableCollection<PixelViewModel>();
        SecondImage = new ObservableCollection<PixelViewModel>();
        
    }
    
    [RelayCommand]
    private async Task OpenFileDialogAsyncFirst()
    {
        var filePath = await _dialogService.ShowOpenFileDialogAsync();
        if (!string.IsNullOrEmpty(filePath))
        {
            FilePathB2img = filePath;
            ImportB2Img(filePath);
        }
    }
    [RelayCommand]
    private async Task OpenFileDialogAsyncSecond()
    {
        var filePath = await _dialogService.ShowOpenFileDialogAsync();
        if (!string.IsNullOrEmpty(filePath))
        {
            FilePathB16img = filePath;
            ImportB16Img(filePath);
        }
    }

    [RelayCommand]
    public void ChangeSelectedColorFirst(string newColor)
    {
        SelectedColorFirst = int.Parse(newColor);
    }
    
    [RelayCommand]
    public void ChangeSelectedColorSecond(string newColor)
    {
        SelectedColorSecond = int.Parse(newColor);
    }
    
    [RelayCommand]
    public void SaveFirstImage()
    {
        if (FirstImage.Count == 0)
        {
            return;
        }
        var updatedPixels = new int[GridRowsFirst, GridColumnsFirst];

        for (int i = 0; i < GridRowsFirst; i++)
        {
            for (int j = 0; j < GridColumnsFirst; j++)
            {
                var pixel = FirstImage[i * GridColumnsFirst + j];
                updatedPixels[i, j] = pixel.Color;
            }
        }

        B2Img newImage = new B2Img
        {
            Width = GridColumnsFirst,
            Height = GridRowsFirst,
            Pixels = updatedPixels
        };
        
        newImage.Save(FilePathB2img);
    }
    
    [RelayCommand]
    public void SaveSecondImage()
    {
        if (SecondImage.Count == 0)
        {
            return;
        }
        var updatedPixels = new int[GridRowsSecond, GridColumnsSecond];

        for (int i = 0; i < GridRowsSecond; i++)
        {
            for (int j = 0; j < GridColumnsSecond; j++)
            {
                var pixel = SecondImage[i * GridColumnsSecond + j];
                updatedPixels[i, j] = pixel.Color;
            }
        }

        B16Img newImage = new B16Img
        {
            Width = GridColumnsSecond,
            Height = GridRowsSecond,
            Pixels = updatedPixels
        };
        Console.WriteLine($"Width: {newImage.Width} Height: {newImage.Height}");
        
        newImage.Save(FilePathB16img);

    }

    public void ImportB2Img(string filePath)
    {
        if (FirstImage is not null)
        {
            FirstImage.Clear();
        }
        B2Img img = B2Img.Load(FilePathB2img);
        
        if (img is null)
        {
            return;
        }
        GridRowsFirst = img.Pixels.GetLength(0);
        GridColumnsFirst = img.Pixels.GetLength(1);

        for (int i = 0; i < GridRowsFirst; i++)
        {
            for (int j = 0; j < GridColumnsFirst; j++)
            {
                FirstImage.Add(new PixelViewModel(img.Pixels[i, j]));
            }
        }
        
    }
    public void ImportB16Img(string filePath)
    {
        if (FirstImage is not null)
        {
            FirstImage.Clear();
        }
        B16Img img = B16Img.Load(FilePathB16img);

        if (img is null)
        {
            return;
        }
        GridRowsSecond = img.Pixels.GetLength(0);
        GridColumnsSecond = img.Pixels.GetLength(1);

        for (int i = 0; i < GridRowsSecond; i++)
        {
            for (int j = 0; j < GridColumnsSecond; j++)
            {
                SecondImage.Add(new PixelViewModel(img.Pixels[i, j]));
            }
        }
        
    }
}