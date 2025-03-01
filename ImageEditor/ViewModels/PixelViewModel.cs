using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace ImageEditor.ViewModels;

public class PixelViewModel : ViewModelBase
{
    private bool _isActive; //This property represents if the pixel if on(true)/off(false)

    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (_isActive != value)
            {
                _isActive = value;
                OnPropertyChanged();
            }
        }
    }
    
    // This command is triggered when the user clicks on the pixel.
    public ICommand ToggleCommand { get; }
    
    // The constructor takes the initial state of the pixel.
    public PixelViewModel(bool initialState)
    {
        IsActive = initialState;
        ToggleCommand = new RelayCommand(Toggle);
    }

    // This method flips the pixel's state.
    private void Toggle()
    {
        IsActive = !IsActive;
    }
}