using ppedv.BerlinBytes.Model.Contracts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ppedv.BerlinBytes.UI.Desktop.ViewModels
{
    public class AppsViewModel : INotifyPropertyChanged
    {
        private Model.DomainModel.App selectedApp;

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Model.DomainModel.App> AppList { get; set; }

        public Model.DomainModel.App SelectedApp
        {
            get => selectedApp;
            set
            {
                selectedApp = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedApp)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VersionCount)));
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

        //todo kill it!!
        public AppsViewModel() : this(new Data.Db.EfRepository("Server=(localdb)\\mssqllocaldb;Database=BerlinBytes_Test;Trusted_Connection=true;"))
        {
        }

        public AppsViewModel(IRepository repo)
        {
            AppList = new List<Model.DomainModel.App>(repo.GetAll<Model.DomainModel.App>().ToList());
        }

    }
}
