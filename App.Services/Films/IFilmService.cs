using App.Repositories.Films;
using App.Services.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Films
{
    public interface IFilmService
    {
        Task<ServiceResult> Add(FilmAddDto dto);
        Task<ServiceResult> Delete(int id);
        ServiceResult<List<FilmGetDto>> GetAll();
        Task<ServiceResult<FilmGetDto>> GetById(int id);
        Task<ServiceResult> Update(int id, FilmUpdateDto dto);

    }
}
