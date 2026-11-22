public class PhysischesProdukt : Produkt
{
    public int Lagerbestand { get; private set; }
    public double GewichtInKg { get; }

    public PhysischesProdukt(string name, decimal preis, int lagerbestand, double gewichtInKg)
        : base(name, preis)
    {
        Lagerbestand = lagerbestand;
        GewichtInKg = gewichtInKg;
    }

    public override bool IstVerfuegbar(int menge)
    {
        return menge > 0 && menge <= Lagerbestand;
    }

    public override decimal BerechneVersandkosten()
    {
        return Preis >= 500m ? 0m : 4.99m;
    }

    public override void Bestandreduzieren(int menge)
    {
        if (IstVerfuegbar(menge))
        {
            Lagerbestand -= menge;
        }
    }
}
