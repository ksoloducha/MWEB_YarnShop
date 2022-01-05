using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;

namespace YarnShop.Core.Repositories
{
    public interface IColorsRepository
    {
        Task UpdateAsync(Color c);
        Task DeleteAsync(int id);
        Task AddAsync(Color c);
        Task<Color> GetAsync(int id);
        Task<IEnumerable<Color>> GetAllAsync();
    }
}
