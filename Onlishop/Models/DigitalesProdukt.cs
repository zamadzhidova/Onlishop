using System;

public class DigitalesProdukt : Produkt
{
    public string DownloadLink { get; }

    public DigitalesProdukt(string name, decimal preis, string downloadLink)
        : base(name, preis)
    {
        DownloadLink = downloadLink;
    }

    public override bool IstVerfuegbar(int menge)
    {
        return menge > 0; // Immer vorrätig!
    }

    public override decimal BerechneVersandkosten()
    {
        return 0m; // Kein Versand nötig
    }

    public override void Bestandreduzieren(int menge)
    {
        // Kein Lagerbestand zum Abziehen, aber wir liefern den Download-Link aus!
        Console.WriteLine($" -> Download bereit für '{Name}': {DownloadLink}");
    }
}
