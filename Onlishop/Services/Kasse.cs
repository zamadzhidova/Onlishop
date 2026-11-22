public class Kasse
{
    public bool Bestellen(Warenkorb korb, IRabatt rabatt, IZahlungsmethode zahlung) // <-- 'e' ergänzt
    {
        // Zwischensumme vom Warenkorb holen
        decimal zwischensumme = korb.BerechneZwieschensumme();
        decimal versand = korb.BerechneGesamtVersand();
        decimal endpreis = rabatt.WendeRabattAn(zwischensumme) + versand;

        Console.WriteLine($"Warenwert: {zwischensumme:C} | Versand: {versand:C} | Gesamt: {endpreis:C}");

        // Rabatt anwenden
        Console.WriteLine($"Zwischensumme: {zwischensumme:C} | Nach Rabatt: {endpreis:C}");

        // Zahlung ausführen
        bool bezahlt = zahlung.Bezahlen(endpreis);

        if (!bezahlt)
        {
            Console.WriteLine("Bestellung abgebrochen: Zahlung fehlgeschlagen!\n");
            return false;
        } // <-- Hier muss das 'if' zu Ende sein!

        // Alles darunter läuft nur, wenn bezahlt == true war:
        foreach (var position in korb.Positionen)
        {
            position.Produkt.Bestandreduzieren(position.Menge); // <-- Großes 'R'
        }

        Console.WriteLine("Bestellung erfolgreich!\n");
        return true;
    }
}
