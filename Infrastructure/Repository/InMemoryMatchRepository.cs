// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using Core.Domain;
// using Core.Repository;
//
// namespace Infrastructure.Repository
// {
//     public class InMemoryMatchRepository: IMatchRepository
//     {
//         private static readonly ISet<Match> _matches = new HashSet<Match>
//         {
//             /*
//             new Match(Guid.NewGuid(),new ParticipantsMatch(new Participant("Polska"), new Participant("Niemcy") ), DateTime.Now, DateTime.Now.AddMinutes(60))
//             */
//             
//         };
//
//         public async Task<Match> GetAsync(Guid id)
//             => await Task.FromResult(_matches.SingleOrDefault(x => x.Id == id));
//
//         public async Task<IEnumerable<Match>> BrowseAsync()
//             => await Task.FromResult(_matches.AsEnumerable());
//
//         public async Task AddAsync(Match match)
//         {
//             throw new NotImplementedException();
//         }
//
//         public async Task UpdateAsync(Match match)
//         {
//             throw new NotImplementedException();
//         }
//
//         public async Task DeleteAsync(Match match)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }
