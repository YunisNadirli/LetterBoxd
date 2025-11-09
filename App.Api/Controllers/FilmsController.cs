using App.Repositories.Films;
using App.Repositories.Tools;
using App.Services.Films;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController(IFilmService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add(FilmAddDto dto)
        {
            var result = await service.Add(dto);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = service.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.GetById(id); 
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, FilmUpdateDto dto)
        {
            var result = await service.Update(id, dto);
            return Ok(result);
        }
    }
}
