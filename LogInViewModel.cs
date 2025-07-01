using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game2048
{
    public class LogInViewModel
    {
        private bool _rememberUser = false;

        private AccountMenager _accauntMenager = new AccountMenager();

        public string Username { get; set; }
        public string Password { get; set; }

        private RelayCommand _logInCommand;
        public RelayCommand LogInCommand
        {
            get
            {
                return  _logInCommand ?? 
                        (_logInCommand = new RelayCommand(
                        obj =>
                        {
                            Account user = new Account();

                            user = _accauntMenager.LogInOrRegistration(Username,
                               Password);

                            if (user == null)
                                return;

                            if(_rememberUser)
                                AccountMenager.RememberUser(user, user.HightScore);

                            var window = new MainWindow(user);
                            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                            window.ShowDialog();
                        },
                        obj =>
                        {
                            return Username != null && Password != null;
                        }));
            }
        }

        private RelayCommand _rememberMeCommand;
        public RelayCommand RememberMeCommand
        {
            get
            {
                return _rememberMeCommand ??
                       (_rememberMeCommand = new RelayCommand(
                            obj =>
                            {
                                _rememberUser = !_rememberUser;
                            },
                            obj =>
                            {
                                return Username != null && Password != null;
                            }));
            }
        }
    }
}
