
namespace TournamentEngine.Domain.Entities;

public class Leaderboard
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
   
    public List<Tournament> Tournaments { get; set; }
}
