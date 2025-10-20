using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Models;
using Models.DTO;
using Utilities.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using Font = Microsoft.Maui.Font;

namespace YektamakMobil
{
    public partial class AppShell : Shell
    {
        private readonly ICache _cache;
        public AppShell(ICache cache)
        {
            _cache = cache;
            InitializeComponent();
            var currentTheme = Microsoft.Maui.Controls.Application.Current!.RequestedTheme;
            //ThemeSegmentedControl.SelectedIndex = currentTheme == AppTheme.Light ? 0 : 1;
        }
        public static async Task DisplaySnackbarAsync(string message)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Color.FromArgb("#FF3300"),
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.Yellow,
                CornerRadius = new CornerRadius(0),
                Font = Font.SystemFontOfSize(18),
                ActionButtonFont = Font.SystemFontOfSize(14)
            };

            var snackbar = Snackbar.Make(message, visualOptions: snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
        }

        public static async Task DisplayToastAsync(string message)
        {
            // Toast is currently not working in MCT on Windows
            if (OperatingSystem.IsWindows())
                return;

            var toast = Toast.Make(message, textSize: 18);

            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await toast.Show(cts.Token);
        }

        private void SfSegmentedControl_SelectionChanged(object sender, Syncfusion.Maui.Toolkit.SegmentedControl.SelectionChangedEventArgs e)
        {
            Microsoft.Maui.Controls.Application.Current!.UserAppTheme = e.NewIndex == 0 ? AppTheme.Light : AppTheme.Dark;
        }
        public void BuildMenu()
        {
            this.Items.Clear(); // önce menüyü temizle

            foreach (AnaMenuDTO anaMenu in _cache.anaMenuList.OrderBy(a => a.siraNo))
            {
                var parentMenu = new FlyoutItem
                {
                    Title = anaMenu.ad,
                    Route = $"route_{anaMenu.Id}"
                };
                foreach (Yetki yetki in _cache.yetkiList.Where(y=>y.menu.ad==anaMenu.ad).OrderBy(y => y.ekran.Id))
                {
                    
                    var tab = new Tab
                    {
                        Title = yetki.ekran.ekranAdi.ToString(),
                        Route = $"route_{yetki.ekran.formAd.ToString()}"
                    };

                    // Alt menüye bağlı sayfa
                    tab.Items.Add(new ShellContent
                    {
                        Title = yetki.ekran.ekranAdi.ToString(),
                        ContentTemplate = new DataTemplate(typeof(MainPage)) // buraya ilgili Page türünü koyarsın
                    });

                    parentMenu.Items.Add(tab);
                }
                this.Items.Add(parentMenu);
            }
        }
    }
}
