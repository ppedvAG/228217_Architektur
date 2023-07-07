using ppedv.BerlinBytes.Model.Contracts;
using ppedv.BerlinBytes.Model.DomainModel;

namespace ppedv.BerlinBytes.Logic.Core
{
    public class ComputerService : IComputerService
    {
        private readonly IRepository repo;

        public ComputerService(IRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Computer> GetComputersWithOutOfSupportAppsInstalled()
        {
            // Get all computers from the repository
            IEnumerable<Computer> computers = repo.Query<Computer>();

            // Filter computers with out-of-support apps installed
            IEnumerable<Computer> computersWithOutOfSupportApps = computers.Where(computer =>
                computer.Apps.Any(app => app.Versions.Any(version =>
                    version.Stage == AppStage.OutOfSupport && version.EndOfSupportDate < DateTime.Now
                ))
            );

            return computersWithOutOfSupportApps;
        }
    }
}