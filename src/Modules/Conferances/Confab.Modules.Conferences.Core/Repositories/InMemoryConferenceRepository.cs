using Confab.Modules.Conferences.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confab.Modules.Conferences.Core.Repositories
{
    internal class InMemoryConferenceRepository : IConferenceRepository
    {
        // Not thread-safe, use Concurrent collections
        private readonly List<Conference> _conferences = new List<Conference>();

        public Task AddAsync(Conference conference)
        {
            _conferences.Add(conference);
            return Task.CompletedTask;
        }

        public async Task<IReadOnlyCollection<Conference>> BrowseAsync()
        {
            await Task.CompletedTask;
            return _conferences;
        }

        public Task DeleteAsync(Conference conference)
        {
            _conferences.Remove(conference);
            return Task.CompletedTask;
        }

        public Task<Conference> GetAsync(Guid id) => Task.FromResult(_conferences.SingleOrDefault(x => x.Id == id));

        public Task UpdateAsync(Conference conference)
        {
            return Task.CompletedTask;
        }
    }
}
