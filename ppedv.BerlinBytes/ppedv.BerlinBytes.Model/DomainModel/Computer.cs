namespace ppedv.BerlinBytes.Model.DomainModel
{
    public class Computer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string OsVersion { get; set; } = string.Empty;
        public virtual ICollection<App> Apps { get; set; } = new HashSet<App>();
    }
}