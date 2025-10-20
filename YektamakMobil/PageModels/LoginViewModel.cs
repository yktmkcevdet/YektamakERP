using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using YektamakMobil.Models;

namespace YektamakMobil.PageModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string message;

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(OnLogin);
        }

        private void OnLogin()
        {
            if (username == "admin" && password == "1234")
            {
                message = "Giriþ baþarýlý!";
                // TODO: Navigation veya token alma iþlemi
            }
            else
            {
                message = "Hatalý giriþ!";
            }
        }
    }
}