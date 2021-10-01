using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Torneio.API.Interfaces;
using Torneio.API.Models.Dtos;
using Torneio.API.Models.Dtos.Jogador;
using Torneio.API.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Torneio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly ITimeRepository _repository;
        private readonly IMapper _mapper;

        public TimeController(IMapper mapper, ITimeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListTimeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<Time> times = await _repository.Get();
                return Ok(times);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}", Name = "GetDetail")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _repository.Get(id);
            return Ok(_mapper.Map<DetailTimeDto>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DetailTimeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync([FromBody] CreateTimeDto time)
        {
            var toCreate = _mapper.Map<Time>(time);
            var result = await _repository.Add(toCreate);
            var timeToReturn = _mapper.Map<DetailTimeDto>(result);
            return CreatedAtRoute("GetDetail", new { id = timeToReturn.TimeId }, timeToReturn);
        }

        [HttpPost("{id}/adiciona-jogador")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DetailTimeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> AdicionaJogadorAsync([FromBody] AdicionaJogadorDto time)
        {
            var toCreate = _mapper.Map<Time>(time);
            var result = await _repository.Add(toCreate);
            var timeToReturn = _mapper.Map<DetailTimeDto>(result);
            return CreatedAtRoute("GetDetail", new { id = timeToReturn.TimeId }, timeToReturn);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DetailTimeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] CreateTimeDto time)
        {
            var toUpdate = await _repository.Get(id);
            toUpdate.Nome = time.Nome;
            await _repository.Update(id, toUpdate);
            return Ok(toUpdate);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _repository.Remove(id);
            return NoContent();

        }
    }
}
