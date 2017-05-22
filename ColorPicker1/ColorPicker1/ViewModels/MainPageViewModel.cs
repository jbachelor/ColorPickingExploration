using ColorPicker1.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ColorPicker1.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        readonly INavigationService _navigationService;

        public DelegateCommand NavToBoxViewPickerCommand { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(MainPageViewModel)}:  ctor");

            _navigationService = navigationService;

            NavToBoxViewPickerCommand = new DelegateCommand(NavToBoxViewPicker);
            Title = "Color Picker Menu";
        }

        ~MainPageViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(MainPageViewModel)}:  dtor");
        }

        internal void NavToBoxViewPicker()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(NavToBoxViewPicker)}");
            _navigationService.NavigateAsync(nameof(BoxViewPickerPage));
        }

        #region INavigationAware
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        } 
        #endregion
    }
}
