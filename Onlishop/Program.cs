class Program
{
    static void Main()
    {
        var laptop = new PhysischesProdukt("Gaming-Laptop", 1200m, lagerbestand: 2, gewichtInKg: 2.5);
        var maus = new PhysischesProdukt("Funk-Maus", 40m, lagerbestand: 5, gewichtInKg: 0.2);
        var windowsKey = new DigitalesProdukt("Windows 11 Pro Lizenz", 145m, "https://techstore.de");

        var korb = new Warenkorb();
        korb.Hinzufuegen(laptop, 1);     // 0 € Versand (über 500 €)
        korb.Hinzufuegen(maus, 1);       // 4,99 € Versand (unter 500 €)
        korb.Hinzufuegen(windowsKey, 1); // 0 € Versand (digital)
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