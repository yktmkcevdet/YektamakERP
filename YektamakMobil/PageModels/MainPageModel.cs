using CommunityToolkit.Mvvm.ComponentModel;

namespace YektamakMobil.PageModels
{
    public partial class MainPageModel: ObservableObject
    {
        [ObservableProperty]
        string message="";

        public MainPageModel()
        {
        }
    }
}
