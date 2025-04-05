namespace TournamentEngine.Domain.Entities;

public class Tournament
{
    public int Id { get; set; }
    public string TournamentName { get; set; }
    public int EventId { get; set; }
    public DateTime StartTime { get; set; }
    public string Status { get; set; }
    public int MaxPlayers { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UpdatedAt { get; set; }

    public List<TournamentPlayer> TournamentPlayers { get; set; }
    public List<TournamentResult> TournamentResults { get; set; }
    public Events Events { get; set; }

}
