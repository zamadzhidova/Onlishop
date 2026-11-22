public abstract class Produkt
{
    public string Name { get; }
    public decimal Preis { get; }

    protected Produkt(string name, decimal preis)
    {
        Name = name;
        Preis = preis;
    }

    // Jedes Produkt muss sagen können, ob genug verfügbar ist
    public abstract bool IstVerfuegbar(int menge);

    // Jedes Produkt muss seine Versandkosten selbst berechnen
    public abstract decimal BerechneVersandkosten();

    // Wird nach dem Bezahlen aufgerufen (digitale Produkte überschreiben das leer)
    public virtual void Bestandreduzieren(int menge) { }
}
