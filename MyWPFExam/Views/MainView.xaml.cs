using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace MyWPFExam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var uri = new Uri($"Settings/Themes/Light.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Visible;
            Catalogue.Visibility = Visibility.Hidden;
            Support.Visibility = Visibility.Hidden;
        }
        private void Catalogue_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Hidden;
            Catalogue.Visibility = Visibility.Visible;
            Support.Visibility = Visibility.Hidden;
        }
        private void Support_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Hidden;
            Catalogue.Visibility = Visibility.Hidden;
            Support.Visibility = Visibility.Visible;
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Hidden;
            Catalogue.Visibility = Visibility.Hidden;
            Support.Visibility = Visibility.Hidden;
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Hidden;
            Catalogue.Visibility = Visibility.Visible;
            Support.Visibility = Visibility.Hidden;
        }
        private void Collapse_Click(object sender, RoutedEventArgs e)
        {
            //Hide();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("We will anwser you soon! We wery appricate your comment(No)!", "Succesfully sent!", MessageBoxButton.OK, MessageBoxImage.Information);
            Support.Visibility = Visibility.Hidden;
            Main.Visibility = Visibility.Visible;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ChangeLan(object sender, RoutedEventArgs e)
        {
            string tag = (sender as Button).Tag.ToString();
            CultureInfo culture = new CultureInfo(tag);

            if (culture != null)
                App.Language = culture;
        }

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            string tm = (sender as Button).Tag.ToString();
            var uri = new Uri($"Settings/Themes/{tm}.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }
    }
}
