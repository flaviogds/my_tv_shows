using my_tv_shows.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace my_tv_shows.Service
{
    public interface ISerieService
    {
        public Task<IEnumerable<Serie>> GetAllAsync();

        public Task<Serie> GetAsync(int id);

        public Task<Serie> AddAsync(Serie serie);

        public Task<Serie> UpdateAsync(int id, Serie serie);

        public Task<Serie> DeleteAsync(int id);

    }
}
