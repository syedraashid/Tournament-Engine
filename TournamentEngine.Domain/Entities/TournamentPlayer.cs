
namespace TournamentEngine.Domain.Entities;

public class TournamentPlayer
{
    public int Id { get; set; }
    public int userId { get; set; }
    public int TournamentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public long Chips { get; set; }
    public int Rank { get; set; }

    public Users Users { get; set; }
    public Tournament Tournaments { get; set; }
}
