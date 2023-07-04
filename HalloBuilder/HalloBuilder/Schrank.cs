namespace HalloBuilder
{
    public class Schrank
    {
        public int AnzahlTüren { get; private set; }
        public int AnzahlBöden { get; private set; }
        public Oberfläche Oberfläche { get; private set; }
        public string Farbe { get; private set; }
        public bool Kleiderstange { get; private set; }

        private Schrank()
        { }

        public class Builder
        {
            private Schrank schrank = new Schrank();

            public Builder SetTüren(int anzahl)
            {
                if (anzahl < 2 || anzahl > 7)
                    throw new ArgumentException("Ein Schrank darf nur 2-7 Türen haben");

                schrank.AnzahlTüren = anzahl;
                return this;
            }

            public Builder SetBöden(int anzahl)
            {
                if (anzahl < 0 || anzahl > 6)
                    throw new ArgumentException("Ein Schrank darf nur 0-6 Böden haben");

                schrank.AnzahlBöden = anzahl;
                return this;
            }

            public Builder SetFarbe(string farbe)
            {
                if (schrank.Oberfläche != Oberfläche.Lackiert)
                    throw new ArgumentException("Der Schrank muss lackiert sein");

                schrank.Farbe = farbe;
                return this;
            }

            public Builder SetOberfläche(Oberfläche oberfläche)
            {
                if (oberfläche != Oberfläche.Lackiert)
                    schrank.Farbe = string.Empty;

                schrank.Oberfläche = oberfläche;
                return this;
            }

            public Schrank Build()
            {
                return schrank;
            }
        }
    }

    public enum Oberfläche
    {
        Natur,
        Gewachst,
        Lackiert
    }
}
