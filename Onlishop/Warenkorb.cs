public class Warenkorb
{
    // Die Liste ist private, damit niemand von außen ungültige Artikel einschmuggeln kann
    private readonly List<WarenkorbPosition> _positionen = new();
    // Gibt die Liste nach außen nur zum Lesen frei (brauchen wir später an der Kasse)
    public IReadOnlyList<WarenkorbPosition> Positionen => _positionen;

    public void Hinzufügen(Produkt produkt, int menge)
    {
        // TODO:
        // 1. Prüfe, ob produkt.Lagerbestand >= menge und menge > 0 ist.
        //    Falls nicht: Gib eine Meldung auf der Konsole aus ("Nicht genug auf Lager!") und brich mit 'return;' ab.
        if (!(produkt.Lagerbestand >= menge && menge > 0))
        {
            Console.WriteLine("Nicht genug auf Lager!");
            return;

        }
        // 2. Füge eine neue WarenkorbPosition(produkt, menge) zu '_positionen' hinzu.
        _positionen.Add(new WarenkorbPosition(produkt, menge));
    }
    public decimal BerechneZwieschensumme()
    {
        decimal summe = 0;
        // TODO:
        // Gehe mit einer foreach-Schleife durch '_positionen'
        // und addiere für jede Position (position.Produkt.Preis * position.Menge) zur 'summe'.
        foreach (var position in _positionen)
        {
            summe += position.Produkt.Preis * position.Menge;
        }
        return summe;
    }
}