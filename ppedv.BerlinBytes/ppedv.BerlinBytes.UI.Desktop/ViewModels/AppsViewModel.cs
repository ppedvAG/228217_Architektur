using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ppedv.BerlinBytes.Model.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ppedv.BerlinBytes.UI.Desktop.ViewModels
{
    public class AppsViewModel : ObservableObject
    {
        private Model.DomainModel.App selectedApp;

        public List<Model.DomainModel.App> AppList { get; set; }

        public Model.DomainModel.App SelectedApp
        {
            get => selectedApp;
            set
            {
                selectedApp = value;
                OnPropertyChanged(nameof(SelectedApp));
                OnPropertyChanged(nameof(VersionCount));
            }
        }

        public string VersionCount
        {
            get
            {
                if (SelectedApp == null)
                    return "---";

                return SelectedApp.Versions.Count.ToString();
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }

        //todo kill it!!
        public AppsViewModel() : this(new Data.Db.EfUnitOfWork("Server=(localdb)\\mssqllocaldb;Database=BerlinBytes_Test;Trusted_Connection=true;"))
        {
        }

        public AppsViewModel(IUnitOfWork repo)
        {
            AppList = new List<Model.DomainModel.App>(repo.AppRepo.Query().ToList());

            SaveCommand = new RelayCommand(() => repo.SaveAll());
        }

    }
}
