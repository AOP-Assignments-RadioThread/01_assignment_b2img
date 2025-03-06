using Avalonia.Controls;
using ImageEditor.Services;
using ImageEditor.ViewModels;

namespace ImageEditor.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var dialogService = new DialogService(this);
        DataContext = new MainWindowViewModel(dialogService);
    }
}