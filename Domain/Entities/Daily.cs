namespace Domain.Entities;

public class Daily
{
    public DateTime Date { get; set; }
    public DateTime PreviousDate { get; set; }
    public string PreviousURL { get; set; }
    public DateTime Timestamp { get; set; }
    public Dictionary<string, ValuteData> Valute { get; set; }
}
