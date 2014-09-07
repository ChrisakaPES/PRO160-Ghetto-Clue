using GhettoClue.Models;
using GhettoClue.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GhettoClue
{
    /// <summary>
    /// Interaction logic for GameBoard.xaml
    /// </summary>
    public partial class GameBoard : UserControl
    {

        public Cell[,] squares;
        public Cell[,] nextSquares;
        public int myColumn = 9;
        public int myRow = 10;
        List<Player> players;
        Player[] playerList;
        private bool isPlayerInRoom;

        public GameBoard()
        {
            InitializeComponent();
        }

        public void CreateBoard()
        {
            if (gameGrid != null)
            {
                gameGrid.Children.Clear();
                squares = new Cell[9, 10];
                nextSquares = new Cell[9, 10];
                for (int i = 0; i < gameGrid.Rows; i++)
                {
                    for (int j = 0; j < gameGrid.Columns; j++)
                    {
                        squares[j, i] = new Cell();

                        Rectangle block = new Rectangle();
                        block.DataContext = squares[j, i];
                        block.MouseLeftButtonDown += squares[j, i].parentClicked;
                        block.Margin = new Thickness(1);
                        if (i == 0 && j == 0 || i == 0 && j == 1 || i == 1 && j == 0 || i == 0 && j == 3 || i == 0 && j == 4 || i == 0 && j == 5 || i == 1 && j == 3 || i == 1 && j == 5 || 
                            i == 0 && j == 7 || i == 0 && j == 8 || i == 1 && j == 8 || i == 3 && j == 0 || i == 4 && j == 0 || i == 5 && j == 0 || i == 3 && j == 1 || i == 5 && j == 1
                            || i == 3 && j == 4 || i == 4 && j == 4 || i == 3 && j == 7 || i == 5 && j == 7 || i == 3 && j == 8 || i == 4 && j == 8 || i == 5 && j == 8 || i == 0 && j == 3 
                            || i == 0 && j == 4 || i == 0 && j == 5 || i == 1 && j == 3 || i == 1 && j == 5 || i == 7 && j == 0 || i == 8 && j == 0 || i == 9 && j == 0 || i == 7 && j == 1 
                            || i == 9 && j == 1 || i == 7 && j == 7 || i == 9 && j == 7 || i == 7 && j == 8 || i == 8 && j == 8 || i == 9 && j == 8 || i == 7 && j == 3 || i == 7 && j == 5 
                            || i == 9 && j == 3 || i == 9 && j == 5)
                            
                        {
                            squares[j, i].IsRoom = true;
                            squares[j, i].IsOpen = false;
                            block.Fill = new SolidColorBrush { Color = Colors.Transparent};
                            Binding b = new Binding("IsOpen");
                            b.Source = squares[j, i];
                            gameGrid.Children.Add(block);
                        }
                        else
                        {
                            MultiBinding b = new MultiBinding();

                            Binding c = new Binding("IsCurrent");
                            Binding h = new Binding("HasPlayer");
                            Binding r = new Binding("IsRoom");
                            Binding a = new Binding("IsAvailable");
                            Binding o = new Binding("IsOpen");
                            Binding d = new Binding("IsDoor");
                            Binding p = new Binding("Player");
                            b.Bindings.Add(h);
                            b.Bindings.Add(c);
                            b.Bindings.Add(d);
                            b.Bindings.Add(r);
                            b.Bindings.Add(a);
                            b.Bindings.Add(o);
                            b.Bindings.Add(p);

                            b.Converter = (StatusConverter)Application.Current.FindResource("StatusToColor");
                            block.SetBinding(Rectangle.FillProperty, b);
                            gameGrid.Children.Add(block);
                        }
                    }
                }
                squares[1, 1].IsDoor = true;
                squares[1, 4].IsDoor = true;
                squares[4, 1].IsDoor = true;
                squares[1, 8].IsDoor = true; 
                squares[7, 8].IsDoor = true;
                squares[7, 4].IsDoor = true; 
                squares[7, 1].IsDoor = true; 
                squares[4, 7].IsDoor = true;
                squares[4, 9].IsDoor = true;
                playerList = players.ToArray();
                squares[8, 2].Player = playerList[0];
                squares[8, 2].IsCurrent = true;
                squares[8, 6].Player = playerList[1];
                squares[0, 2].Player = playerList[2];
                squares[0, 6].Player = playerList[3];
                squares[2, 0].Player = playerList[4];
                squares[6, 0].Player = playerList[5];
            }
        }

        public void UpdatePlayers(List<Player> players)
        {
            this.players = players;
        }

        public void HighlightSpots(int roll)
        {

            List<GhettoClue.Movement.Point> availables = new List<GhettoClue.Movement.Point>();

            clearHighlights();
            for (int i = 0; i < gameGrid.Rows; i++)
            {
                for (int j = 0; j < gameGrid.Columns; j++)
                {
                    if (squares[j, i].IsCurrent)
                    {
                        getOpenSpots(j, i);
                    }
                }
            }

            for (int k = 0; k < roll - 1; k++)
            {
                for (int i = 0; i < gameGrid.Rows; i++)
                {
                    for (int j = 0; j < gameGrid.Columns; j++)
                    {
                        if (squares[j, i].IsAvailable)
                        {
                            availables.Add(new GhettoClue.Movement.Point(j, i));
                        }
                    }
                }

                foreach (GhettoClue.Movement.Point p in availables)
                {
                    getOpenSpots(p.X, p.Y);
                }
            }
        }

        public void UpdateNextTurn(Player p)
        {

            for (int i = 0; i < gameGrid.Rows; i++)
            {
                for (int j = 0; j < gameGrid.Columns; j++)
                {
                    if (squares[j, i].IsCurrent)
                    {
                        squares[j, i].IsCurrent = false;
                    }
                }
            }

            for (int k = 0; k < 6; k++)
            {
                for (int i = 0; i < gameGrid.Rows; i++)
                {
                    for (int j = 0; j < gameGrid.Columns; j++)
                    {
                        if(p == squares[j,i].Player)
                        {
                            squares[j, i].IsCurrent = true;
                        }
                    }
                }
            }
        }

        public void inRoom(Player p)
        {
            for (int k = 0; k < 6; k++)
            {
                for (int i = 0; i < gameGrid.Rows; i++)
                {
                    for (int j = 0; j < gameGrid.Columns; j++)
                    {
                        if (p == squares[j, i].Player)
                        {
                            if (BackAlleyCheck(j, i) || LaundroMatCheck(j, i) || BBMommasPadCheck(j, i) || GrowHouseCheck(j, i) || KFCCheck(j, i) || TheCornerCheck(j, i))
                            {
                                p.IsInRoom = true;
                            }
                            else
                            {
                                p.IsInRoom = false;
                            }
                        }
                    }
                }
            }
        }

        public void getOpenSpots(int x, int y)
        {
            // Check cell on the right.
            if (x != myColumn - 1)
                if (squares[x + 1, y].IsOpen)
                    squares[x + 1, y].IsAvailable = true;

            // Check cell on the bottom.
            if (y != myRow - 1)
                if (squares[x, y + 1].IsOpen)
                    squares[x, y + 1].IsAvailable = true;

            // Check cell on the left.
            if (x != 0)
                if (squares[x - 1, y].IsOpen)
                    squares[x - 1, y].IsAvailable = true;

            // Check cell on the top.
            if (y != 0)
                if (squares[x, y - 1].IsOpen)
                    squares[x, y - 1].IsAvailable = true;
        }

        public void clearHighlights()
        {
            foreach (Cell cell in squares)
            {
                cell.IsAvailable = false;
            }
        }

        public void PutInRoom(int x, int y)
        {
            // Check cell on the right.
            if (x != myColumn - 1)
                if (squares[x + 1, y].IsRoom)
                    squares[x + 1, y].IsAvailable = true;

            // Check cell on the bottom.
            if (y != myRow - 1)
                if (squares[x, y + 1].IsRoom)
                    squares[x, y + 1].IsAvailable = true;

            // Check cell on the left.
            if (x != 0)
                if (squares[x - 1, y].IsRoom)
                    squares[x - 1, y].IsAvailable = true;

            // Check cell on the top.
            if (y != 0)
                if (squares[x, y - 1].IsRoom)
                    squares[x, y - 1].IsAvailable = true;

        }

        public bool BackAlleyCheck(int x, int y)
        {
            bool check = false;

            // Check cell on the left.
            if (x != 0)
                if (squares[x - 1, y] == squares[0,1])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            // Check cell on the top.
            if (y != 0)
                if (squares[x, y - 1] == squares[1, 0])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            return check;
        }

        public bool LaundroMatCheck(int x, int y)
        {
            bool check = false;

            // Check cell on the right.
            if (x != myColumn - 1)
                if (squares[x + 1, y] == squares[5, 1])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            // Check cell on the left.
            if (x != 0)
                if (squares[x - 1, y] == squares[3, 1])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            // Check cell on the top.
            if (y != 0)
                if (squares[x, y - 1] == squares[4, 0])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            return check;
        }

        public bool BBMommasPadCheck(int x, int y)
        {
            bool check = false;

            // Check cell on the right.
            if (x != myColumn - 1)
                if (squares[x + 1, y] == squares[8, 1])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            // Check cell on the top.
            if (y != 0)
                if (squares[x, y - 1] == squares[7, 0])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            return check;
        }

        public bool GrowHouseCheck(int x, int y)
        {
            bool check = false;

            // Check cell on the bottom.
            if (y != myRow - 1)
                if (squares[x, y + 1] == squares[1, 5])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            // Check cell on the left.
            if (x != 0)
                if (squares[x - 1, y] == squares[0, 4])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            // Check cell on the top.
            if (y != 0)
                if (squares[x, y - 1] == squares[1, 3])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            return check;
        }

        public bool KFCCheck(int x, int y)
        {
            bool check = false;

            // Check cell on the right.
            if (x != myColumn - 1)
                if (squares[x + 1, y] == squares[8, 4])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            // Check cell on the bottom.
            if (y != myRow - 1)
                if (squares[x, y + 1] == squares[7, 5])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            // Check cell on the top.
            if (y != 0)
                if (squares[x, y - 1] == squares[7, 3])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            return check;
        }

        public bool TheCornerCheck(int x, int y)
        {
            bool check = false;

            // Check cell on the bottom.
            if (y != myRow - 1)
                if (squares[x, y + 1] == squares[1, 9])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            // Check cell on the left.
            if (x != 0)
                if (squares[x - 1, y] == squares[0, 8])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            // Check cell on the top.
            if (y != 0)
                if (squares[x, y - 1] == squares[1, 7])
                {
                    check = true;
                }
                else
                {
                    return false;
                }

            return check;
        }
    }
}
