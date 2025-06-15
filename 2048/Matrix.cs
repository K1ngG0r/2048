using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2048
{
    public class Field : INotifyPropertyChanged
    {
        public int[,] Matrix { get; set; }

        public Field() 
        {
            Matrix = new int[4,4] 
            { 
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void KeyDown(KeyEventArgs key)
        {
            switch(key.Key)
            {
                case System.Windows.Input.Key.Up:
                    break;
                case System.Windows.Input.Key.Down:
                    break;
                case System.Windows.Input.Key.Left:
                    break;
                case System.Windows.Input.Key.Right:
                    break;
                default:
                    break;
            }

            OnPropertyChanged("Matrix");
        }
    }
}
