using ppedv.BerlinBytes.Model.Contracts;

namespace ppedv.BerlinBytes.Logic.Core
{
    public class AppService : IAppService
    {
        IComputerService _computerService;
        IRepository _repo;

        public AppService(IRepository repo, IComputerService computerService)
        {
            _repo = repo;
            _computerService = computerService;
        }

        public void UpdateAppOnAllComputer()
        {
            foreach (var comp in _computerService.GetComputersWithOutOfSupportAppsInstalled())
            {
                //do Update app: comp
            }
        }
    }
}
