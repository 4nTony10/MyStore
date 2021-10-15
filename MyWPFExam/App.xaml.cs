using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyWPFExam
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static event EventHandler LanguageChange;
        public static CultureInfo Language
        {
            get => System.Threading.Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (value == null) throw new ArgumentException("value!");
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                ResourceDictionary dic = new ResourceDictionary();
                switch (value.Name)
                {
                    case "en-US":
                        dic.Source = new Uri(string.Format("Settings/Languages/en-US.xaml"), UriKind.Relative);
                        break;
                    case "ru-RU":
                        dic.Source = new Uri(string.Format("Settings/Languages/ru-RU.xaml"), UriKind.Relative);
                        break;
                }

                ResourceDictionary oldDct = (from d in Current.Resources.MergedDictionaries
                                             where d.Source != null &&
                                             d.Source.OriginalString.StartsWith("Settings/Languages/")
                                             select d).First();

                if (oldDct != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDct);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDct);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dic);
                }
                else
                    Application.Current.Resources.MergedDictionaries.Add(dic);
            }
        }

        private void App_languageChange(object sender, EventArgs e)
        {
            MyWPFExam.Properties.Settings.Default.DefaultLanguage = Language;
            MyWPFExam.Properties.Settings.Default.Save();

        }
    }
}
