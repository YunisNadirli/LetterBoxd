using App.Repositories.Films;
using App.Repositories.Tools;
using App.Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Films
{
    public class FilmService(IFilmRepository repository, IUnitOfWork unitOfWork) : IFilmService
    {
        public async Task<ServiceResult> Add(FilmAddDto dto)
        {
            Film film = new Film
            {
                Name = dto.Name,
                Duration = dto.Duration,
                Year = dto.Year,
            };
            await repository.Add(film);
            int rows = await unitOfWork.SaveChangesAsync();

            if (rows == 0) return ServiceResult.Fail("Any data not added");
            return ServiceResult.Success();
        }

        public async Task<ServiceResult> Delete(int id)
        {
            Film film = await repository.GetById(id);
            repository.Delete(film);
            int rows = await unitOfWork.SaveChangesAsync();
            if (rows == 0) ServiceResult.Fail("Any film not deleted");
            return ServiceResult.Success();
            
        }

        public ServiceResult<List<FilmGetDto>> GetAll()
        {
            List<Film> films = repository.GetAll().ToList();
            List<FilmGetDto> filmDtos = films.Select(f => new FilmGetDto(f.Id,f.Name,f.Duration,f.Year)).ToList();
            if (filmDtos is null) ServiceResult<FilmGetDto>.Fail("Any film not found");
            return ServiceResult<List<FilmGetDto>>.Success(filmDtos!);
        }

        public async Task<ServiceResult<FilmGetDto>> GetById(int id)
        {
            Film film = await repository.GetById(id);
            FilmGetDto dto = new FilmGetDto(film.Id, film.Name, film.Duration, film.Year);
            if (film is null)
            {
                return ServiceResult<FilmGetDto>.Fail("Film not found");
            }
            return ServiceResult<FilmGetDto>.Success(dto);
        }

        public async Task<ServiceResult> Update(int id, FilmUpdateDto dto)
        {
            Film film = await repository.GetById(id);
            if(film is null)
            {
                return ServiceResult.Fail("Film not found");
            }
            film.Name = dto.Name;
            film.Duration = dto.Duration;
            film.Year = dto.Year;
            repository.Update(film);
            int rows = await unitOfWork.SaveChangesAsync();
            if (rows > 0) return ServiceResult.Success();
            return ServiceResult.Fail("Film not updated");
        }

    }
}
