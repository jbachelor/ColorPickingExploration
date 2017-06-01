using Prism.Unity;
using ColorPicker1.Views;
using Xamarin.Forms;

namespace ColorPicker1
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<BoxViewPickerPage>();
            Container.RegisterTypeForNavigation<StaticPickerPage>();
            Container.RegisterTypeForNavigation<SkiaPlay1>();
            Container.RegisterTypeForNavigation<TapToFillPage>();
            Container.RegisterTypeForNavigation<ColorExplorerPage>();
            Container.RegisterTypeForNavigation<SkiaPicker1Page>();
        }
    }
}
