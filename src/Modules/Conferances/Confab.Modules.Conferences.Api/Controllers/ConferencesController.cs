using Confab.Modules.Conferences.Core.DTO;
using Confab.Modules.Conferences.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confab.Modules.Conferences.Api.Controllers
{
    internal class ConferencesController : BaseController
    {
        private readonly IConferenceService _conferenceService;

        public ConferencesController(IConferenceService hostService)
        {
            _conferenceService = hostService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ConferenceDetailsDto>> Get(Guid id)
            => OkOrNotFound(await _conferenceService.GetAsync(id));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<ConferenceDto>>> BrowseAsync()
            => OkOrNotFound(await _conferenceService.BrowseAsync());

        [HttpPost]
        public async Task<ActionResult> AddAsync(ConferenceDetailsDto dto)
        {
            await _conferenceService.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateAsync(Guid id, ConferenceDetailsDto dto)
        {
            dto.Id = id;
            await _conferenceService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _conferenceService.DeleteAsync(id);
            return NoContent();
        }
    }
}
