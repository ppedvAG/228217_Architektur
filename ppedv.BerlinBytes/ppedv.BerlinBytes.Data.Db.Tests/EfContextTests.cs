using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using ppedv.BerlinBytes.Model.DomainModel;
using System.Reflection;

namespace ppedv.BerlinBytes.Data.Db.Tests
{
    public class EfContextTests
    {
        readonly string conString = "Server=(localdb)\\mssqllocaldb;Database=BerlinBytes_Test;Trusted_Connection=true;";

        [Fact]
        [Trait("","Integration")]
        public void Can_create_db()
        {
            var con = new EfContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            result.Should().BeTrue();
        }

        [Fact]
        [Trait("", "Integration")]

        public void Can_insert_Computer()
        {
            var con = new EfContext(conString);
            con.Database.EnsureCreated();
            var comp = new Computer() { Name = "Z1" };

            con.Add(comp);
            var result = con.SaveChanges();

            result.Should().Be(1);
        }

        [Fact]
        [Trait("", "Integration")]

        public void Can_read_Computer()
        {
            var comp = new Computer() { Name = $"Z2_{Guid.NewGuid()}" };
            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(comp);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Find<Computer>(comp.Id);
                loaded!.Name.Should().Be(comp.Name);
            }
        }

        [Fact]
        [Trait("", "Integration")]

        public void Can_update_Computer()
        {
            var comp = new Computer() { Name = $"Z2_{Guid.NewGuid()}" };
            var newName = $"Z3_{Guid.NewGuid()}";
            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(comp);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Find<Computer>(comp.Id);
                loaded!.Name = newName;
                con.SaveChanges().Should().Be(1);
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Find<Computer>(comp.Id);
                loaded!.Name.Should().Be(newName);
            }
        }

        [Fact]
        [Trait("", "Integration")]

        public void Can_delete_Computer()
        {
            var comp = new Computer() { Name = $"Z4_{Guid.NewGuid()}" };
            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(comp);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Find<Computer>(comp.Id);
                con.Remove(loaded!);
                con.SaveChanges().Should().Be(1);
            }

            using (var con = new EfContext(conString))
            {
                con.Find<Computer>(comp.Id).Should().BeNull();
            }
        }

        [Fact]
        [Trait("", "Integration")]

        public void Can_insert_App_with_AutoFixture()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter("Id"));
            var app = fix.Create<App>();
            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(app);
                con.SaveChanges().Should().BeGreaterThan(3);
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Find<App>(app.Id);
                loaded.Should().BeEquivalentTo(app, x => x.IgnoringCyclicReferences());
            }
        }
    }

    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}