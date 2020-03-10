using System.Collections.Generic;

namespace Better.Core.Domain
{
    public class Team : Enity
    {
        public string TeamName { get; private set;}
        private ISet<Match> _matches = new HashSet<Match>();
        public IEnumerable<Match> Matches => _matches;
        
        public Team (string teamName)
        {
            TeamName = teamName;
        }

        public void AddNewMatchToHistory(Match match)
        {
            _matches.Add(match);
        }
    }
}