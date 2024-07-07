namespace Library;

public class NativeRate
{
    public DateTime Time { get; set; }
    public string Symbol { get; set; } = string.Empty;
    public double Bid { get; set; }
    public double Ask { get; set; }
}