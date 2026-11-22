public class Produkt
{
    public string Name { get; }
    public decimal Preis { get; }
    public int Lagerbestand { get; private set; }
    public Produkt(string name, decimal preis, int lagerbestand)
    {
        //TODO Wiese Name, Preis und Lagerbestand zu
        Name = name;
        Preis = preis;
        Lagerbestand = lagerbestand;
    }
public bool Bestandreduzieren(int menge)
    {
        //TODO
        //1. Prüfe, ob menge>0 und menge<= lagerbestand ist.
        if(menge>0 && menge <= Lagerbestand)
        {
            // 3. Falls ja: ziehe menge vom Lagerbestand ab und gib true zurück.
            Lagerbestand -= menge;
            return true;
        }
        //2. Falls nein: gibt false zurück.
       
        return false;
    }
}