namespace ppedv.BerlinBytes.API.Model
{
    public class VersionDTO
    {
        public int Id { get; set; }
        public int VersionsNummer { get; set; }
        public string Stage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime EndOfSupportDate { get; set; }
        public int Count { get; set; }
    }
}
