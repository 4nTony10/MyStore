using BAL.Models;
using MyWPFExam.Infrastructure;
using MyWPFExam.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWPFExam.ModelViews
{
    class ObjectInfoModelView : BaseNotifyPropertyChange
    {

        ObjectInfo viewElectro;
        private ElectronicsBAL currentElectro;
        public ElectronicsBAL CurrentElectro
        {
            get => currentElectro;
            set
            {
                currentElectro = value;
                Notify();
            }
        }
        public ICommand CancelCommand { get; set; }

        public ObjectInfoModelView(ElectronicsBAL electronics)
        {
            if (electronics == null)
                viewElectro.Close();

            CurrentElectro = electronics;

            CancelCommand = new RelayCommand(x =>
            {
                currentElectro = null;
                viewElectro.Close();
            });

            viewElectro = new ObjectInfo();
            viewElectro.DataContext = this;
            viewElectro.ShowDialog();

        }

    }
}
