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
    public class MatchRepository: EntityRepository<Match>, IMatchRepository
    {

        public MatchRepository(BetterContext context):base(context)
        {
        }

    }
}
