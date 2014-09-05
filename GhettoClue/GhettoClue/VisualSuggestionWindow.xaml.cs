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
using System.Windows.Shapes;

namespace GhettoClue
{
    /// <summary>
    /// Interaction logic for VisualSuggestionWindow.xaml
    /// </summary>
    public partial class VisualSuggestionWindow : Window
    {
        public MainWindow ParentWin { get; set; }
        public Player currentPlayer { get; set; }
        public VisualSuggestionWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }
    }
}
