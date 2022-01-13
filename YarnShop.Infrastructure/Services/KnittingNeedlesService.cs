using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;
using YarnShop.Infrastructure.DTO;

namespace YarnShop.Infrastructure.Services
{
    public class KnittingNeedlesService : IKnittingNeedlesService
    {
        private readonly IKnittingNeedlesRepository _knittingNeedlesRepository;

        public KnittingNeedlesService(IKnittingNeedlesRepository knittingNeedlesRepository)
        {
            _knittingNeedlesRepository = knittingNeedlesRepository;
        }

        public async Task<KnittingNeedleDTO> AddCrochetHook(KnittingNeedle knittingNeedle)
        {
            KnittingNeedle c = new KnittingNeedle()
            {
                Size = knittingNeedle.Size,
                n = knittingNeedle.n,
                Circular = knittingNeedle.Circular
            };
            await _knittingNeedlesRepository.AddAsync(c);
            return new KnittingNeedleDTO()
            {
                Size = knittingNeedle.Size,
                n = knittingNeedle.n,
                Circular = knittingNeedle.Circular
            };
        }

        public async Task<IEnumerable<KnittingNeedleDTO>> BrowseAll()
        {
            var c = await _knittingNeedlesRepository.GetAllAsync();
            return c.Select(x => mapToDTO(x));
        }

        public async Task<IEnumerable<KnittingNeedleDTO>> BrowseAllAndFilterSize(double minSize)
        {
            var knittingNeedles = await _knittingNeedlesRepository.GetAllAsync();
            return knittingNeedles.Select(c => mapToDTO(c));
        }

        public static KnittingNeedleDTO mapToDTO(KnittingNeedle c)
        {
            return new KnittingNeedleDTO()
            {
                Id = c.Id,
                Size = c.Size,
                n = c.n,
                Circular = c.Circular
            };
        }

        public async Task DeleteCrochetHook(int id)
        {
            await _knittingNeedlesRepository.DeleteAsync(id);
        }

        public async Task<KnittingNeedleDTO> EditCrochetHook(KnittingNeedle knittingNeedle, int id)
        {
            KnittingNeedle updatedKnittingNeedle = new KnittingNeedle()
            {
                Id = id,
                Size = knittingNeedle.Size,
                n = knittingNeedle.n,
                Circular = knittingNeedle.Circular
            };
            await _knittingNeedlesRepository.UpdateAsync(updatedKnittingNeedle);
            return mapToDTO(updatedKnittingNeedle);
        }

        public async Task<KnittingNeedleDTO> GetById(int id)
        {
            var crochetHook = await _knittingNeedlesRepository.GetAsync(id);
            return mapToDTO(crochetHook);
        }
    }
}
