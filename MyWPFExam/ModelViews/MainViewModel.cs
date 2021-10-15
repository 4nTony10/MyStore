using BAL.Models;
using BAL.Services;
using MyWPFExam.Extensions;
using MyWPFExam.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWPFExam.ModelViews
{
    class MainViewModel : BaseNotifyPropertyChange
    {
        #region Property
        IService<ElectronicsBAL> ElService { get; set; }
        public ObservableCollection<ElectronicsBAL> AllElectro { get; set; }
        private ElectronicsBAL electronic;
        public ElectronicsBAL SelectedElectro
        {
            get => electronic;
            set
            {
                electronic = value;
                Notify();
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ShowCommand { get; set; }
        #endregion

        public MainViewModel(IService<ElectronicsBAL> elService)
        {
            ElService = elService;
            AllElectro = ElService.GetAll().ToObservableCollection();

            AddCommand = new RelayCommand(x =>
            {
                AdditionalViewModel vm = new AdditionalViewModel(ElService);
                SelectedElectro = vm.CurrentElectro;
                if (SelectedElectro != null)
                {
                    ElService.Create(SelectedElectro);
                    AllElectro.Add(SelectedElectro);
                    SelectedElectro = null;
                }
            });

            UpdateCommand = new RelayCommand(x =>
            {
                if (SelectedElectro != null)
                {
                    AdditionalViewModel vm = new AdditionalViewModel(ElService, SelectedElectro);
                    ElService.Update(SelectedElectro);
                    SelectedElectro = null;
                }
            });

            RemoveCommand = new RelayCommand(x =>
            {
                if (SelectedElectro != null)
                {
                    ElService.Remove(SelectedElectro.Id);
                    AllElectro.Remove(SelectedElectro);
                    SelectedElectro = null;
                }
            });

            ShowCommand = new RelayCommand(x =>
            {
                if(SelectedElectro != null)
                {
                    ObjectInfoModelView obj = new ObjectInfoModelView(SelectedElectro);
                    SelectedElectro = null;
                }
            });

            SaveCommand = new RelayCommand(x =>
            {
                ElService.Save();
            });
        }
    }
}
