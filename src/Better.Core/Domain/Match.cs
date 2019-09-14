using System;
using System.Collections.Generic;

namespace Better.Core.Domain
{
    public class Match : Enity
    {
        private ISet<Bet> _bets = new HashSet<Bet>();
        public string Team1 { get; protected set; }
        public string Team2 { get; protected set; }
        public DateTime StartTime { get; protected set; }
        public string Winner { get; protected set; }
        public IEnumerable<Bet> Bets => _bets;

        protected Match()
        {
        }

        public Match(Guid id, string team1, string team2, DateTime startTime)
        {
            Id = id;
            SetTeams(team1, team2);
            SetStartTime(startTime);
        }

        public void AddBet(User user, string team, decimal amountCoins)
        {
            if (user.Coins < amountCoins)
            {
                throw new Exception($"User: '{user.Username}' don't have enough Coins.");
            }
            if (amountCoins <= 0)
            {
                throw new Exception($"The bet can not be less than 1 Coin");
            }
            user.SubstractCoins(amountCoins);
            _bets.Add(Bet.Create(Guid.NewGuid(), user.Id, this.Id, team, amountCoins));

        }
        public void SetTeams(string team1, string team2)
        {
            if (string.IsNullOrEmpty(team1))
            {
                throw new Exception("Complete Team 1");
            }
            if (string.IsNullOrEmpty(team2))
            {
                throw new Exception("Complete Team 2");
            }
            if (team1 == team2)
            {
                throw new Exception("Teams can not be the same");
            }
            Team1 = team1;
            Team2 = team2;
        }

        public void SetStartTime(DateTime startTime)
        {
            if (startTime < DateTime.UtcNow)
            {
                throw new Exception("The date can not pass");
            }
            StartTime = startTime;
        }
        public void SetWinner(string winner)
        {
            if (!winner.Equals(Team1) && !winner.Equals(Team2) && !winner.Equals("draw"))
            {
                throw new Exception("Winner must take part in match");
            }
            Winner = winner;
        }


        public static Match Create(Guid matchId, string team1, string team2, DateTime startTime)
            => new Match(matchId, team1, team2, startTime);
    }
}