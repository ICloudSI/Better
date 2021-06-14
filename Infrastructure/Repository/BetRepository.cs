using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repository;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BetRepository : EntityRepository<Bet>, IBetRepository
    {
        public BetRepository(BetterContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Bet>> GetMatchBetsAsync(Guid matchId)
            => await table.Include(ownerUser => ownerUser.Owner).
                Include(match => match.MatchConcerned).
                Include(participant => participant.BetParticipant).
                Where(bet => bet.MatchConcerned.Id == matchId).ToListAsync();

        public async Task<IEnumerable<Bet>> GetUserBetsAsync(Guid userId)
            => await table.Include(ownerUser => ownerUser.Owner).
                Include(match => match.MatchConcerned).
                Include(participant => participant.BetParticipant).
                Where(bet => bet.Owner.Id == userId).ToListAsync();

    }
}

