using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace my_tv_shows.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly RepositoryContext _context;

        public UnityOfWork(RepositoryContext context)
        {
            _context = context;
        }

        public Task RollBackChangesAsync()
        {
            _context.ChangeTracker.Entries()
                .Where(e => e.Entity != null)
                .ToList()
                .ForEach(e => e.State = EntityState.Detached);

            return Task.CompletedTask;
        }

        public async Task<int> SubmitChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }

}
