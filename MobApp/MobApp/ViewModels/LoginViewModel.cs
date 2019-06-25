using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MobApp.Services;

namespace MobApp.ViewModels
{
    public class LoginViewModel :INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public Action DisplayValidLoginPrompt;
        public Action DisplayCatchError;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        APICall api = new APICall();
        
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public async void OnSubmit()
        {
            try
            {
                var i = await api.loginAsync(email, password);
                if (Convert.ToInt32(i) == 1)
                {
                    DisplayValidLoginPrompt();
                }
            }
            catch
            {
                DisplayCatchError();
            }
            //if (email != "diptej.thakkar@gmail.com" || password != "Parv@2018")
            //{
            //    DisplayInvalidLoginPrompt();
            //}
        }
    }
}
