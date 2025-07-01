using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.InteropServices;
using System.Xml;
using System.Windows;


namespace Game2048
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int HightScore {  get; set; }
        
        public bool LogIn( string password)
        {
            if (Password == password)
                return true;
            else
            {
                MessageBox.Show("Не правильный пороль(",
                    "Пороль", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
        }
    }
}