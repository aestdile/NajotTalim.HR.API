using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.API.Services;
using NajotTalim.HR.DataAcces.Entities;

namespace NajotTalim.HR.DataAcces
{
    public class AdressRepository : IGenericRepository<Adress>
    {
        private readonly AppDbContext _dbContext;

        public AdressRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Adress> Create(Adress adress)
        {
            await _dbContext.Adresses.AddAsync(adress);
            await _dbContext.SaveChangesAsync();
            return adress;
        }

        public async Task<bool> Delete(int id)
        {
            var adress = await _dbContext.Adresses.FindAsync(id);
            if (adress != null)
            {
                _dbContext.Adresses.Remove(adress);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Adress> Get(int id)
        {
            return await _dbContext.Adresses.FindAsync(id);
        }

        public async Task<IEnumerable<Adress>> GetAll()
        {
            return await _dbContext.Adresses.ToListAsync();
        }

        public async Task<Adress> Update(int id, Adress adress)
        {
            var updatedAdress = _dbContext.Adresses.Attach(adress);
            updatedAdress.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return adress;
        }
    }
}
