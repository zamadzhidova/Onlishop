public class WarenkorbPosition
{
    public Produkt Produkt { get; }
    public int Menge { get; set; }
    public WarenkorbPosition(Produkt produkt, int menge)
    {
        Produkt = produkt;
        Menge = menge;
    }
}