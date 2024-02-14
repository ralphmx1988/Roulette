namespace Roulette.Core.Models
{
    public class BetResult
    {
        public bool IsWinner { get; set; }=false;
        public int Balance { get; set; }
        public string Message { get; set; }
    }
}
