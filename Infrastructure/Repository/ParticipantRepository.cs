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
    public class ParticipantRepository: EntityRepository<Participant>, IParticipantRepository
    {

        public ParticipantRepository(BetterContext context):base(context)
        {
        }

    }
}
