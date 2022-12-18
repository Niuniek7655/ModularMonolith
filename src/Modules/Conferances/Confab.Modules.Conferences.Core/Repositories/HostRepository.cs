﻿using Confab.Modules.Conferences.Core.DAL;
using Confab.Modules.Conferences.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confab.Modules.Conferences.Core.Repositories
{
    internal class HostRepository : IHostRepository
    {
        private readonly ConferencesDbContext _context;
        private readonly DbSet<Host> _hosts;

        public HostRepository(ConferencesDbContext context)
        {
            _context = context;
            _hosts = _context.Hosts;
        }

        public async Task AddAsync(Host host)
        {
            await _hosts.AddAsync(host);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Host>> BrowseAsync()
            => await _hosts.ToListAsync();

        public async Task DeleteAsync(Host host)
        {
            _hosts.Remove(host);
            await _context.SaveChangesAsync();
        }

        public Task<Host> GetAsync(Guid id) 
            => _hosts.Include(x => x.Conferences).SingleOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Host host)
        {
            _hosts.Update(host);
            await _context.SaveChangesAsync();
        }
    }
}
