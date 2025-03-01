using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace ImageEditor.ViewModels
{
    public class PixelViewModel : ViewModelBase
    {
        private bool _isActive;
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
        
        public ICommand ToggleCommand { get; }

        public PixelViewModel(bool initialState)
        {
            IsActive = initialState;
            ToggleCommand = new RelayCommand(Toggle);
        }

        private void Toggle()
        {
            IsActive = !IsActive;
        }
    }
}