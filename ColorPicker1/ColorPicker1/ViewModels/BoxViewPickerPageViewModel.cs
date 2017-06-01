using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace ColorPicker1.ViewModels
{
    public class BoxViewPickerPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private Color _selectedColor;
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set { SetProperty(ref _selectedColor, value); }
        }

        private string _selectedColorLabelText;
        public string SelectedColorLabelText
        {
            get { return _selectedColorLabelText; }
            set { SetProperty(ref _selectedColorLabelText, value); }
        }
        
        private int _brightness;
        public int Brightness
        {
            get { return _brightness; }
            set { SetProperty(ref _brightness, value); }
        }
        
        public BoxViewPickerPageViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(BoxViewPickerPageViewModel)}:  ctor");

            Title = "Box View Picker";
            SelectedColor = Color.White;
            SelectedColorLabelText = "Select a Color";
        }

        ~BoxViewPickerPageViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(BoxViewPickerPageViewModel)}:  dtor");
        }

        #region INavigationAware

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
        } 

        #endregion
    }
}
