using System.Threading.Tasks;

namespace my_tv_shows.Repository
{
    public interface IUnityOfWork
    {
        public Task<int> SubmitChangesAsync();

        public Task RollBackChangesAsync();
    }
}
