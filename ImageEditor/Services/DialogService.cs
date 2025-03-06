using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace ImageEditor.Services;

public class DialogService : IDialogService
{
    private readonly Window _mainWindow;

    public DialogService(Window mainWindow)
    {
        _mainWindow = mainWindow;
    }

    public async Task<string?> ShowOpenFileDialogAsync()
    {
        var dialog = new OpenFileDialog
        {
            Title = "Select a file",
            AllowMultiple = false,
            Filters =
            {
                new FileDialogFilter { Name = "B2IMG Text Files", Extensions = { "b2img.txt" } }
            }
        };

        var result = await dialog.ShowAsync(_mainWindow);
        return result?.FirstOrDefault();
    }
}