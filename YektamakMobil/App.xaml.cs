using Utilities.Interfaces;

namespace YektamakMobil
{
    public partial class App : Application
    {
        private readonly ICache _cache;
        public App(ICache cache)
        {
            _cache = cache;
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell(_cache));
        }
    }
}