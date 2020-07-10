using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Repository;
using Infrastructure.DTO;

namespace Infrastructure.Services
{
    public class MatchService: IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public MatchService(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MatchDTO>> BrowseMatch()
        {
            var matches = await _matchRepository.BrowseAsync();
            var matchesToReturn = _mapper.Map<IEnumerable<MatchDTO>>(matches);
            return matchesToReturn;
        }

    }
}
