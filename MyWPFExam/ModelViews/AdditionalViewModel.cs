using MyWPFExam.Views;
using MyWPFExam.Infrastructure;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
using BAL.Services;
using System.IO;

namespace MyWPFExam.ModelViews
{
    class AdditionalViewModel : BaseNotifyPropertyChange
    {
        AdditionalView editElectro;
        private ElectronicsBAL currentElectro;
        private IService<ElectronicsBAL> Service;
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
        public ICommand SaveChangeCommand { get; set; }

        public AdditionalViewModel(IService<ElectronicsBAL> service, ElectronicsBAL electronics = null)
        {
            if (electronics != null)
            {
                currentElectro = electronics;
                
            }
            else
                currentElectro = new ElectronicsBAL();

            if (service != null)
                Service = service;

            CancelCommand = new RelayCommand(x =>
            {
                currentElectro = null;
                editElectro.Close();
            });

            SaveChangeCommand = new RelayCommand(x =>
            {
                if(IDCheck() && BlankCheck() && PathCheck())
                    editElectro.Close();
            });

            editElectro = new AdditionalView();
            editElectro.DataContext = this;
            editElectro.ShowDialog();

        }

        private bool IDCheck()
        {
            if(CurrentElectro != null)
                foreach (var i in Service.GetAll())
                {
                    if (CurrentElectro.Id == i.Id && CurrentElectro.Name != i.Name && CurrentElectro.ImagePath != i.ImagePath)
                        return false;
                }

            return true;
        }

        private bool BlankCheck()
        {
            if (CurrentElectro != null)
            {
                if (CurrentElectro.Information == null || CurrentElectro.Name == null
                    || CurrentElectro.Description == null)
                    return false;
            }
                return true;
        }

        private bool PathCheck()
        {
            if (CurrentElectro != null)
            {
                if (!File.Exists(CurrentElectro.ImagePath))
                    return false;
            }
            return true;
        }
    }
}
