using System.Windows;
using System.Windows.Controls;

namespace Game2048.Controls
{
    public partial class ColoredTile : UserControl
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ColoredTile),
                new PropertyMetadata(""));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public ColoredTile()
        {
            InitializeComponent();
        }
    }
}