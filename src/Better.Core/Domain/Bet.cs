using System;

namespace Better.Core.Domain
{
    public class Bet : Enity
    {
        public Guid UserId { get; protected set; }
        public Guid MatchId { get; protected set; }
        public string Team { get; protected set; }
        public decimal Coins { get; protected set; }

        protected Bet()
        {
        }

        protected Bet(Guid id, Guid userId, Guid matchId, string team, decimal coins)
        {
            Id = id;
            UserId = userId;
            MatchId = matchId;
            Team = team;
            Coins = coins;
        }

        public static Bet Create(Guid id, Guid userId, Guid matchId, string team, decimal coins)
            => new Bet(id, userId, matchId, team, coins);
    }
}