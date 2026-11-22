using System;

public class Kreditkarte : IZahlungsmethode
{
    public string Kartennummer { get; }
    public decimal Limit { get; private set; }

    public Kreditkarte(string kartennummer, decimal limit)
    {
        Kartennummer = kartennummer;
        Limit = limit;
    }

    public bool Bezahlen(decimal betrag)
    {
        if (betrag <= 0 || betrag > Limit)
        {
            Console.WriteLine($"Kreditkarte ({Kartennummer}): Zahlung über {betrag:C} abgelehnt (Limit: {Limit:C}).");
            return false;
        }

        Limit -= betrag;
        Console.WriteLine($"Kreditkarte ({Kartennummer}): {betrag:C} bezahlt. Verbleibendes Limit: {Limit:C}.");
        return true;
    }
}
