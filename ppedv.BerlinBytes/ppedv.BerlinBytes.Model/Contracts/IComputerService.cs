using ppedv.BerlinBytes.Model.DomainModel;

namespace ppedv.BerlinBytes.Model.Contracts
{
    public interface IComputerService
    {
        IEnumerable<Computer> GetComputersWithOutOfSupportAppsInstalled();
    }
}