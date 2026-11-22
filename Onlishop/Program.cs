class Progrm
{
    static void Main()
    {
        var laptop = new Produkt("Laptop", 1000m, 2);
        var maus = new Produkt("Maus", 50m, 5);
        var korb = new Warenkorb();
        korb.Hinzufügen(laptop, 1);
        korb.Hinzufügen(maus, 2); //Zwieschensumme =1100
        Console.WriteLine($"Zwischensumme: {korb.BerechneZwieschensumme():C}");        // Erwartet: 1.100,00 €

        //Rabatt & Zahlungsmethod
        IRabatt gutschein = new ProzentGutschein(10); //10 % rabatt->Endpreis
        IZahlungsmethode karteZuWenig = new Kreditkarte("1111-2222", 800m);
        IZahlungsmethode karteGenug = new Kreditkarte("3333-4444", 1500m);
        var kasse = new Kasse();
        //Test A:Sollte fehlschlagen (800EUR Limit reicht nicht für 900 EUR)
        kasse.Bestellen(korb, gutschein, karteZuWenig);
        Console.WriteLine($"Laptop-Bestand nach Fehlversuch: {laptop.Lagerbestand}"); // Muss noch 2 sein


        //Test B: Sollte klappen (1500 Eur Limit reciht für 990EUR)
        kasse.Bestellen(korb, gutschein, karteGenug);
        Console.WriteLine($"Laptop-Bestand nach Kauf: {laptop.Lagerbestand}"); //Muss jetzt 1 sein

    }
}