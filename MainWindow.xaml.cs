using System.Windows;
using System.Windows.Input;

namespace Game2048
{
    public partial class MainWindow : Window
    {
        private Field Matrix{ get; set; }

        public MainWindow()
        {
            Matrix = new Field();

            InitializeComponent();

            UpdateMatrix(Matrix.Matrix);
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Matrix.KeyTriggered(e);
            UpdateMatrix(Matrix.Matrix);
        }

        public void UpdateMatrix(int[,] field)
        {
            oo.Text = field[0, 0].ToString();
            o1.Text = field[0, 1].ToString();
            o2.Text = field[0, 2].ToString();
            o3.Text = field[0, 3].ToString();
            I0.Text = field[1, 0].ToString();
            I1.Text = field[1, 1].ToString();
            I2.Text = field[1, 2].ToString();
            I3.Text = field[1, 3].ToString();
            II0.Text = field[2, 0].ToString();
            II1.Text = field[2, 1].ToString();
            II2.Text = field[2, 2].ToString();
            II3.Text = field[2, 3].ToString();
            III0.Text = field[3, 0].ToString();
            III1.Text = field[3, 1].ToString();
            III2.Text = field[3, 2].ToString();
            III3.Text = field[3, 3].ToString();

            ScoreCount.Text = Matrix.Score.ToString();

            if(Matrix.Score > Matrix.HightScore)
            {
                HightScoreCount.Text = Matrix.Score.ToString();
            }
        }
    }
}
