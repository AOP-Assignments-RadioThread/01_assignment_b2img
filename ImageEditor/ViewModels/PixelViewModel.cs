using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace ImageEditor.ViewModels
{
    public partial class PixelViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _color;
        

        public PixelViewModel (int initialColor)
        {
            Color = initialColor;
        }

        [RelayCommand]
        private void ChangeColor(int newColor)
        {
           Color = newColor;
        }
    }
}