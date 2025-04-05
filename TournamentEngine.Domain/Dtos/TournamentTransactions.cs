using TournamentEngine.Domain.Entities;

namespace TournamentEngine.Domain.Dtos;

class TournamentTransactions
{
    public int TournamentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<TournamentPlayerTransaction> TournamentPlayerTransactions { get; set; }
}
