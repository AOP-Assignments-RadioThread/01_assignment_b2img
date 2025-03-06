using System.Threading.Tasks;

namespace ImageEditor.Services;

public interface IDialogService
{
    Task<string> ShowOpenFileDialogAsync();
}