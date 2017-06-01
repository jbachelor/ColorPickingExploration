using ColorPicker1.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ColorPicker1.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        readonly INavigationService _navigationService;

        public DelegateCommand NavToBoxViewPickerCommand { get; set; }
        public DelegateCommand NavToStaticPickerCommand { get; set; }
        public DelegateCommand NavToSkiaPlay1Command { get; set; }
        public DelegateCommand NavToTapToFillPageCommand { get; set; }
        public DelegateCommand NavToColorExplorerPageCommand { get; set; }
        public DelegateCommand NavToSkiaPicker1PageCommand { get; set; }

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
            NavToStaticPickerCommand = new DelegateCommand(NavToStaticPickerAsync);
            NavToSkiaPlay1Command = new DelegateCommand(NavToSkiaPlay1);
            NavToTapToFillPageCommand = new DelegateCommand(NavToTapToFillPage);
            NavToColorExplorerPageCommand = new DelegateCommand(NavToColorExplorerPage);
            NavToSkiaPicker1PageCommand = new DelegateCommand(NavToSkiaPicker1Page);

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

        private async void NavToStaticPickerAsync()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(NavToStaticPickerAsync)}");
            await _navigationService.NavigateAsync(nameof(StaticPickerPage));
        }

        private async void NavToSkiaPlay1()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(NavToSkiaPlay1)}");
            await _navigationService.NavigateAsync(nameof(SkiaPlay1));
        }

        private async void NavToTapToFillPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(NavToTapToFillPage)}");
            await _navigationService.NavigateAsync(nameof(TapToFillPage));
        }
        private async void NavToColorExplorerPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(NavToColorExplorerPage)}");
            await _navigationService.NavigateAsync(nameof(ColorExplorerPage));
        }

        private async void NavToSkiaPicker1Page()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(NavToSkiaPicker1Page)}");
            await _navigationService.NavigateAsync(nameof(SkiaPicker1Page));
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
