namespace TournamentEngine.Domain.Dtos;

public class TournamentPlayerTransaction
{
    public int PlayerId { get; set; }
    public Dictionary<string,string> TransactionsDetails { get; set; }
}
