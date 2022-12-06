﻿using Confab.Modules.Conferences.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confab.Modules.Conferences.Core.Repositories
{
    internal interface IHostRepository
    {
        Task<Host> GetAsync(Guid id);
        Task<IReadOnlyCollection<Host>> BrowseAsync();
        Task AddAsync(Host host);
        Task UpdateAsync(Host host);
        Task DeleteAsync(Host host);
    }
}
