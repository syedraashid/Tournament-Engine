namespace TournamentEngine.Domain.Entities;

public class Users
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public long Points { get; set; }
    public bool InGame { get; set; }

    public List<TournamentPlayer> TournamentPlayers { get; set; }
}
