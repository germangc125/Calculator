namespace Common.Models
{

    public class DivtResult
    {
        public int Quotient { get; set; }
        public int Remainder { get; set; }
    }

    public class DivtRequest
    {
        public int Dividend { get; set; }
        public int Divisor { get; set; }
    }
}
