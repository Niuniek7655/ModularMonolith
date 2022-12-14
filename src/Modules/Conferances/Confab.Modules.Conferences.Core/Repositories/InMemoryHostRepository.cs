using Confab.Modules.Conferences.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confab.Modules.Conferences.Core.Repositories
{
    internal class InMemoryHostRepository : IHostRepository
    {
        // Not thread-safe, use Concurrent collections
        private readonly List<Host> _hosts = new List<Host>();

        public Task AddAsync(Host host)
        {
            _hosts.Add(host);
            return Task.CompletedTask;
        }

        public async Task<IReadOnlyCollection<Host>> BrowseAsync()
        {
            await Task.CompletedTask;
            return _hosts;
        }

        public Task DeleteAsync(Host host)
        {
            _hosts.Remove(host);
            return Task.CompletedTask;
        }

        public Task<Host> GetAsync(Guid id) => Task.FromResult(_hosts.SingleOrDefault(x => x.Id == id));

        public Task UpdateAsync(Host host)
        {
            return Task.CompletedTask;
        }
    }
}
