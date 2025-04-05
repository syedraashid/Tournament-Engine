namespace TournamentEngine.Domain.Entities;

public class TournamentResult
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public int PlayerId { get; set; }
    public int PlayerStatus { get; set; }
    public long GainedPoints { get; set; }
    public Dictionary<string,object>? PlayingHistory { get; set; }
}
