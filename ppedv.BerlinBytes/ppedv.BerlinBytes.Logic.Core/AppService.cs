using ppedv.BerlinBytes.Model.Contracts;

namespace ppedv.BerlinBytes.Logic.Core
{
    public class AppService : IAppService
    {
        IComputerService _computerService;
        IUnitOfWork _unitOfWork;

        public AppService(IUnitOfWork uow, IComputerService computerService)
        {
            _unitOfWork = uow;
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
