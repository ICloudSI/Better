using System;

namespace Better.Core.Domain
{
    public class Bet : Enity
    {
        public Guid UserId { get; protected set; }
        public Guid MatchId { get; protected set; }
        public Team Team { get; protected set; }
        public decimal Coins { get; protected set; }

        protected Bet()
        {
        }

        public Bet(Guid userId, Guid matchId, Team team, decimal coins)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            MatchId = matchId;
            Team = team;
            Coins = coins;
        }
    }
}