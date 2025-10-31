using App.Repositories.Films;
using App.Repositories.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController(IFilmRepository repository, IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(string name)
        {
            Film film = new Film { Name = name };
            repository.Add(film);   
            int a = await unitOfWork.SaveChangesAsync();
            return Ok(a);
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Film> films = repository.GetAll();
            return Ok(films);
        }
    }
}
