using System.Windows;
using System.Windows.Input;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;


namespace Game2048
{
    public partial class Registration : Window
    {
        public Account User {  get; set; }

        public Registration()
        {
            User = new Account();

            DataContext = new LogInViewModel();

            if (File.Exists("lastUser.txt"))
            {
                string newList = File.ReadAllText("lastUser.txt");

                User = JsonSerializer.Deserialize<Account>(newList) ?? new Account();

                var window = new MainWindow(User);
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                window.ShowDialog();

                Close();
            }

            InitializeComponent();
        }
    }
}
