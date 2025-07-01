using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Game2048
{
    public class Field : INotifyPropertyChanged
    {
        public int[,] Matrix { get; set; }
        public int Score { get; set; }
        public int HightScore { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        //=================================================================

        public Field()
        {
            Matrix = new int[4, 4]
            {
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0}
            };

            Score = 0;
            HightScore = 0;

            AddRandomTile();
        }
        public Field(Account user)
        {

            Matrix = new int[4,4] 
            { 
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0}
            };

            Score = 0;
            HightScore = user.HightScore;

            AddRandomTile();
        }

        //=================================================================

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void KeyTriggered(KeyEventArgs key)
        {
            switch(key.Key)
            {
                case System.Windows.Input.Key.Up:
                    MoveUp();
                    break;
                case System.Windows.Input.Key.Down:
                    MoveDown();
                    break;
                case System.Windows.Input.Key.Left:
                    MoveLeft();
                    break;
                case System.Windows.Input.Key.Right:
                    MoveRight();
                    break;
                default:
                    return;
            }

            AddRandomTile();

            OnPropertyChanged("Matrix");
        }
        public void AddRandomTile()
        {
            Random random = new Random();

            for (int tmp = 0; tmp < 17; tmp++)
            {
                int i = random.Next(0, 4);
                int j = random.Next(0, 4);

                if (Matrix[i, j] == 0)
                {
                    Matrix[i, j] = random.Next(0, 10) % 10 != 0 ? 2 : 4;

                    return;
                }
            }
        }
        public void MoveUp()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int y = 1; y < 4; y++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        if (Matrix[y, x] != 0)
                        {
                            if (Matrix[y - 1, x] == 0)
                            {
                                Matrix[y - 1, x] = Matrix[y, x];
                                Matrix[y, x] = 0;
                            }
                            else if (Matrix[y - 1, x] == Matrix[y, x])
                            {
                                Matrix[y - 1, x] *= 2;
                                Matrix[y, x] = 0;

                                Score += Matrix[y - 1, x];
                            }
                        }
                    }
                }
            }
        }
        public void MoveDown()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int y = 2; y >= 0; y--)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        if (Matrix[y, x] != 0)
                        {
                            if (Matrix[y + 1, x] == 0)
                            {
                                Matrix[y + 1, x] = Matrix[y, x];
                                Matrix[y, x] = 0;
                            }
                            else if (Matrix[y + 1, x] == Matrix[y, x])
                            {
                                Matrix[y + 1, x] *= 2;
                                Matrix[y, x] = 0;

                                Score += Matrix[y + 1, x];
                            }
                        }
                    }
                }
            }
        }
        public void MoveLeft()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int y = 0; y < 4; y++)
                {
                    for (int x = 1; x < 4; x++)
                    {
                        if (Matrix[y, x] != 0)
                        {
                            if (Matrix[y, x - 1] == 0)
                            {
                                Matrix[y, x - 1] = Matrix[y, x];
                                Matrix[y, x] = 0;
                            }
                            else if (Matrix[y, x - 1] == Matrix[y, x])
                            {
                                Matrix[y, x - 1] *= 2;
                                Matrix[y, x] = 0;

                                Score += Matrix[y, x - 1];
                            }
                        }
                    }
                }
            }
        }
        public void MoveRight()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int y = 0; y < 4; y++)
                {
                    for (int x = 2; x >= 0; x--)
                    {
                        if (Matrix[y, x] != 0)
                        {
                            if (Matrix[y, x + 1] == 0)
                            {
                                Matrix[y, x + 1] = Matrix[y, x];
                                Matrix[y, x] = 0;
                            }
                            else if (Matrix[y, x + 1] == Matrix[y, x])
                            {
                                Matrix[y, x + 1] *= 2;
                                Matrix[y, x] = 0;
                                Score += Matrix[y, x + 1];
                            }
                        }
                    }
                }
            }
        }
    }
}