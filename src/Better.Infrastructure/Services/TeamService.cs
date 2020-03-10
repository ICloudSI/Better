using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Better.Core.Domain;
using Better.Core.Repository;
using Better.Infrastructure.Dto;

namespace Better.Infrastructure.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }
        public async Task<TeamDto> GetAsync(Guid id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null)
            {
                throw new Exception($"Team with id: '{id}' does not exist.");
            }

            return _mapper.Map<TeamDto>(team);
        }
        public async Task<IEnumerable<TeamDto>> BrowseAsync()
        {
            var teams = await _teamRepository.BrowseAsync();

            return _mapper.Map<IEnumerable<TeamDto>>(teams);
        }

        public async Task CreateTeamAsync(string team)
        {
            var teamFromRepo = await _teamRepository.GetByNameAsync(team);
            if (teamFromRepo != null)
            {
                throw new Exception($"Team with name '{team}' already exist.");
            }

            var teamToRepo = new Team(team);

            await _teamRepository.AddAsync(teamToRepo);

        }


    }
}