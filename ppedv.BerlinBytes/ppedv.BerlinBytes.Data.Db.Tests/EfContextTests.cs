using ppedv.BerlinBytes.Model.DomainModel;

namespace ppedv.BerlinBytes.Data.Db.Tests
{
    public class EfContextTests
    {
        readonly string conString = "Server=(localdb)\\mssqllocaldb;Database=BerlinBytes_Test;Trusted_Connection=true;";

        [Fact]
        public void Can_create_db()
        {
            var con = new EfContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_insert_Computer()
        {
            var con = new EfContext(conString);
            con.Database.EnsureCreated();
            var comp = new Computer() { Name = "Z1" };

            con.Add(comp);
            var result = con.SaveChanges();

            Assert.Equal(1, result);
        }

        [Fact]
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
                Assert.Equal(comp.Name, loaded?.Name);
            }
        }

        [Fact]
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
                var result = con.SaveChanges();
                Assert.Equal(1, result);
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Find<Computer>(comp.Id);
                Assert.Equal(newName, loaded?.Name);
            }
        }

        [Fact]
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
                var result = con.SaveChanges();
                Assert.Equal(1, result);
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Find<Computer>(comp.Id);
                Assert.Null(loaded);
            }
        }
    }
}