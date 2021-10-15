using System;
using System.Collections.Generic;
using System.IO;
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

namespace MyWPFExam.Views
{
    /// <summary>
    /// Логика взаимодействия для AdditionalView.xaml
    /// </summary>
    public partial class AdditionalView : Window
    {
        public AdditionalView()
        {
            InitializeComponent();
        }

        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Rating_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender as TextBox).Text.Contains("1234567890") &&
                (sender as TextBox).Text.Length > 2)
                (sender as TextBox).Text = "0";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!File.Exists((sender as TextBox).Text))
            {
                (sender as TextBox).Text = "Invalid path";
            }
        }

    }
}
