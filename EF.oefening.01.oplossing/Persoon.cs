namespace EF.oefening._01.oplossing
{
    internal class Persoon
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public bool HeeftRijbewijs { get; set; }

        public Persoon()
        {

        }

        public Persoon(string naam, string voornaam, DateTime geboortedatum, bool heeftRijbewijs)
        {
            Naam = naam;
            Voornaam = voornaam;
            Geboortedatum = geboortedatum;
            HeeftRijbewijs = heeftRijbewijs;
        }

        public override string ToString()
        {
            return $"{Naam} {Voornaam}";
        }
    }
}
