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

namespace MyWPFExam.Views
{
    /// <summary>
    /// Логика взаимодействия для ObjectInfo.xaml
    /// </summary>
    public partial class ObjectInfo : Window
    {
        public ObjectInfo()
        {
            InitializeComponent();
        }
        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
