using ppedv.BerlinBytes.Model.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.BerlinBytes.UI.Desktop.ViewModels
{
    public class AppsViewModel
    {

        public List<Model.DomainModel.App> AppList { get; set; }

        public Model.DomainModel.App SelectedApp { get; set; }

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
