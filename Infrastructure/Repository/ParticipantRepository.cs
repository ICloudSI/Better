using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repository;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ParticipantRepository: IParticipantRepository
    {
        private readonly BetterContext _dbContext;

        public ParticipantRepository(BetterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Participant> GetAsync(Guid id)
            => await _dbContext.Participants.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Participant>> BrowseAsync()
            => await _dbContext.Participants.ToListAsync();

        public async Task AddAsync(Participant participant)
        {
            {
                await _dbContext.Participants.AddAsync(participant);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Participant participant)
        {
            _dbContext.Participants.Update(participant);
            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteAsync(Participant participant)
        {
            _dbContext.Participants.Remove(participant);
            await _dbContext.SaveChangesAsync();
        }
    }
}
