using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_tv_shows.Models;
using my_tv_shows.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace my_tv_shows
{
    public class SeriesRepository : ControllerBase, ISeriesRepository
    {
        private readonly RepositoryContext _context;

        public SeriesRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Serie>> GetAllAsync()
        {
            return await _context.Series
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<Serie> GetAsync(int? id)
        {
            return await _context.Series
                    .AsNoTracking()
                    .FirstOrDefaultAsync(element => element.Id == id);
        }

        public async Task<Serie> AddAsync(Serie serie)
        {
            if (await Exist(null, serie.Name))
            {
                return null;
            }
            var response = await _context.Series.AddAsync(serie);
            return response.Entity;
        }

        public async Task<Serie> UpdateAsync(int id, Serie serie)
        {
            if (await Exist(id, null))
            {
                return null;
            }
            _context.Entry(serie).State = EntityState.Modified;
            return serie;
        }

        public async Task<Serie> DeleteAsync(int? id)
        {
            if (!await Exist(id, null))
            {
                return null;
            }
            var serie = await _context.Series
                    .FirstOrDefaultAsync(element => element.Id == id);

            _context.Series.Remove(serie);
            return serie;
        }

        private async Task<bool> Exist(int? id, string name)
        {
            if (name != null)
            {
                return await _context.Series
                        .AnyAsync(element => element.Name == name);
            }
            return await _context.Series
                    .AnyAsync(element => element.Id == id);
        }
    }
}