using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Domain.IServices;
using ToDoList.Domain.Models;
using ToDoList.DTO;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("{version:apiVersion}/[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly ILogger<ToDoListController> _logger;
        private readonly IToDoListItemService _toDoListItemService;
        private readonly IMapper _mapper;

        public ToDoListController(ILogger<ToDoListController> logger, IToDoListItemService toDoListItemService, IMapper mapper)
        {
            _logger = logger;
            _toDoListItemService = toDoListItemService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ToDoListItemResource), 201)]
        public async Task<IEnumerable<ToDoListItem>> GetAsync()
        {
            return await _toDoListItemService.ListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ToDoListItem> GetAsync(long id)
        {
            return await _toDoListItemService.FindByIdAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ToDoListItemResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 4001)]
        public async Task<IActionResult> PostAsync([FromBody] ToDoListItemResource resource)
        {
            var toDoListItem = _mapper.Map<ToDoListItemResource, ToDoListItem>(resource);
            toDoListItem.CreatedDate = DateTime.Now;
            var result = await _toDoListItemService.SaveAsync(toDoListItem);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var toDoListItemResource = _mapper.Map<ToDoListItem, ToDoListItemResource>(result.Resource);
            return Ok(toDoListItemResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ToDoListItemResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 4001)]
        public async Task<IActionResult> PutAsync(long id, [FromBody] ToDoListItemResource resource)
        {
            var toDoListItem = _mapper.Map<ToDoListItemResource, ToDoListItem>(resource);
            toDoListItem.LastModifiedDate = DateTime.Now;
            var result = await _toDoListItemService.UpdateAsync(id, toDoListItem);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var toDoListItemResource = _mapper.Map<ToDoListItem, ToDoListItemResource>(result.Resource);
            return Ok(toDoListItemResource);
        }

        [HttpDelete("archive/{id}")]
        [ProducesResponseType(typeof(ToDoListItemResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 4001)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _toDoListItemService.ArchiveAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var toDoListItemResource = _mapper.Map<ToDoListItem, ToDoListItemResource>(result.Resource);
            return Ok(toDoListItemResource);
        }
        [HttpDelete("restore/{id}")]
        [ProducesResponseType(typeof(ToDoListItemResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 4001)]
        public async Task<IActionResult> BinRestoreAsync(long id)
        {
            var result = await _toDoListItemService.RestoreAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var toDoListItemResource = _mapper.Map<ToDoListItem, ToDoListItemResource>(result.Resource);
            return Ok(toDoListItemResource);
        }
        [HttpDelete("remove/{id}")]
        [ProducesResponseType(typeof(ToDoListItemResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 4001)]
        public async Task<IActionResult> BinDeleteAsync(long id)
        {
            var result = await _toDoListItemService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var toDoListItemResource = _mapper.Map<ToDoListItem, ToDoListItemResource>(result.Resource);
            return Ok(toDoListItemResource);
        }
    }
}
