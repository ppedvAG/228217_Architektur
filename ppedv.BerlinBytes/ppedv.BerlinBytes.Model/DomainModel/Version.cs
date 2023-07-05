namespace ppedv.BerlinBytes.Model.DomainModel
{
    public class Version : Entity
    {
        public int Number { get; set; }
        public AppStage Stage { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime EndOfSupportDate { get; set; }
        public int DownloadCount { get; set; }

        public virtual App? App { get; set; }
    }
}