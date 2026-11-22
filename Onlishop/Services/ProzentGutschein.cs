public class ProzentGutschein : IRabatt
{
    private readonly double _prozent;
    public ProzentGutschein(double prozent)
    {
        _prozent = prozent;
    }
    public decimal WendeRabattAn(decimal betrag)
    {
        //TODO 
        //Berechne den Anzug : betrag *(decimal)(_prozent/100.0)
        decimal abzug = betrag * (decimal)(_prozent / 100);
        // Gib (betrag-anzug) zurück.
        return betrag - abzug;
    }
}
