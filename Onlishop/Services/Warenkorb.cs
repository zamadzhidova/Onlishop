using System;
using System.Collections.Generic;

public class Warenkorb
{
    private readonly List<WarenkorbPosition> _positionen = new();

    public IReadOnlyList<WarenkorbPosition> Positionen => _positionen;

    public void Hinzufuegen(Produkt produkt, int menge)
    {
        if (!produkt.IstVerfuegbar(menge))
        {
            Console.WriteLine($"'{produkt.Name}' ist in dieser Menge nicht verfügbar!");
            return;
        }

        _positionen.Add(new WarenkorbPosition(produkt, menge));
    }

    public decimal BerechneZwieschensumme()
    {
        decimal summe = 0;
        foreach (var position in _positionen)
        {
            summe += position.Produkt.Preis * position.Menge;
        }
        return summe;
    }

    public decimal BerechneGesamtVersand()
    {
        decimal versand = 0;
        foreach (var position in _positionen)
        {
            versand += position.Produkt.BerechneVersandkosten();
        }
        return versand;
    }
}
