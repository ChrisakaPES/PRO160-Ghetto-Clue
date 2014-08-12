using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            
            


            ////gameboard.Children.Remove(gameGrid);
            //gameGrid = new Grid();
            //gameGrid.Height = gameboard.RenderSize.Height;
            //gameGrid.Height = gameboard.RenderSize.Width;

            //double rows = 20;
            //double col = 20;

            ////double merWidth = gameGrid.Width / col;
            ////double merHeight = gameGrid.Height / rows;

            ////create columns
            //int cnum = 0;
            //for(int i =0; i < col; i++)
            //{
            //    ColumnDefinition columns = new ColumnDefinition();
            //    columns.Width = new GridLength(col);
            //    gameGrid.ColumnDefinitions.Add(columns);
            //}
            //cnum = (int)col;
            //numcol = cnum;

            ////create rows
            //int r = 0;for (int i = 0; i < rows; i++)
            //{
            //    RowDefinition ro = new RowDefinition();
            //    ro.Height = new GridLength(rows);
            //    gameGrid.RowDefinitions.Add(ro);
            //}
            //r = (int)rows;
            //numrow = r;

            ////makes fill and outline color
            //SolidColorBrush line = new SolidColorBrush();
            //line.Color = Color.FromArgb(160, 0, 0, 0);
            //SolidColorBrush fill = new SolidColorBrush();
            //fill.Color = Color.FromRgb(0, 0, 0);
            //rectArray = new Rectangle[r, cnum];

            ////adds rectangles to the grid
            //for(int i = 0; i < rows; i++)
            //{
            //    for(int j = 0; j < col; j++)
            //    {
            //        space = new Rectangle();
            //        space.MouseDown += space_MouseDown;
            //        rectArray[i,j] = space;
            //        space.Fill = fill;
            //        space.Stroke = line;
            //        Grid.SetColumn(space, j);
            //        Grid.SetRow(space, i);

            //        gameGrid.Children.Add(space);
            //    }
            //}
            

        }
        private void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //handles moving pawns           
        }
    }
}

