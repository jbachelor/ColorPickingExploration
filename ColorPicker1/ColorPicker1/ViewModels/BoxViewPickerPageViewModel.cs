using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        public BoxViewPickerPageViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(BoxViewPickerPageViewModel)}:  ctor");

            Title = "Box View Picker";
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
