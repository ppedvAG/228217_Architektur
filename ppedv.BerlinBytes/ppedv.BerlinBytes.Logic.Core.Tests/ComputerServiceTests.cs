using FluentAssertions;
using Moq;
using ppedv.BerlinBytes.Model.Contracts;
using ppedv.BerlinBytes.Model.DomainModel;

namespace ppedv.BerlinBytes.Logic.Core.Tests
{
    public class ComputerServiceTests
    {
        [Fact]
        public void GetComputersWithOutOfSupportAppsInstalled_no_computers_in_source_should_return_an_empty_list()
        {
            var repoMock = new Mock<IRepository>();
            var cs = new ComputerService(repoMock.Object);

            cs.GetComputersWithOutOfSupportAppsInstalled().Should().BeEmpty();
        }

        [Fact]
        public void GetComputersWithOutOfSupportAppsInstalled_1_of_3_is_out_of_support()
        {
            var repoMock = new Mock<IRepository>();
            repoMock.Setup(x => x.GetAll<Computer>()).Returns(() =>
            {
                var c1 = new Computer() { Name = "c1" };
                c1.Apps.Add(new App() { Name = "App1" });
                c1.Apps.First().Versions.Add(new Model.DomainModel.Version()
                {
                    Stage = AppStage.OutOfSupport,
                    EndOfSupportDate = DateTime.Now.AddDays(-1)
                });

                var c2 = new Computer() { Name = "c2" };
                c2.Apps.Add(new App() { Name = "App2" });
                c2.Apps.First().Versions.Add(new Model.DomainModel.Version()
                {
                    Stage = AppStage.Beta,
                    EndOfSupportDate = DateTime.Now.AddDays(-1)
                });

                var c3 = new Computer() { Name = "c3" };
                c3.Apps.Add(new App() { Name = "App3" });
                c3.Apps.First().Versions.Add(new Model.DomainModel.Version()
                {
                    Stage = AppStage.Beta,
                    EndOfSupportDate = DateTime.Now.AddDays(2)
                });

                return new[] { c1, c2, c3 };
            });
            var cs = new ComputerService(repoMock.Object);

            cs.GetComputersWithOutOfSupportAppsInstalled().Should().ContainSingle(x => x.Name == "c1");
        }
    }
}