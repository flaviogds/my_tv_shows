using my_tv_shows.Models;
using my_tv_shows.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace my_tv_shows.Service
{
    public class SerieService : ISerieService
    {
        private readonly ISeriesRepository _repository;
        private readonly IUnityOfWork _repositoryChanges;

        public SerieService(
            ISeriesRepository repository,
            IUnityOfWork repositoryChanges)
        {
            _repository = repository;
            _repositoryChanges = repositoryChanges;
        }

        public async Task<IEnumerable<Serie>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Serie> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Serie> AddAsync(Serie serie)
        {
            var response = await _repository.AddAsync(serie);
            return await ValidToSave(response);
        }

        public async Task<Serie> UpdateAsync(int id, Serie serie)
        {
            var response = await _repository.UpdateAsync(id, serie);
            return await ValidToSave(response);
        }

        public async Task<Serie> DeleteAsync(int id)
        {
            var response = await _repository.DeleteAsync(id);
            return await ValidToSave(response);
        }

        private async Task<Serie> ValidToSave(Serie response)
        {
            if (response != null)
            {
                await _repositoryChanges.SubmitChangesAsync();
            }
            return response;
        }
    }
}
