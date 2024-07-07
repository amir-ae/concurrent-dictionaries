namespace Library;

public class Rate
{
    public DateTime Time { get; set; }
    public string Symbol { get; set; } = string.Empty;
    public double Bid { get; set; }
    public double Ask { get; set; }
}