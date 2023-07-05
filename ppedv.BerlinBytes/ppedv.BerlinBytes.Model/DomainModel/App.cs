namespace ppedv.BerlinBytes.Model.DomainModel
{
    public class App : Entity
    {
        public required string Name { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;

        public virtual ICollection<Version> Versions { get; set; } = new HashSet<Version>();
        public virtual ICollection<Computer> Computers { get; set; } = new HashSet<Computer>();
    }
}