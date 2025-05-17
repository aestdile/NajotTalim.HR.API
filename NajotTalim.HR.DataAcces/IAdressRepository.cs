using NajotTalim.HR.DataAcces.Entities;

namespace NajotTalim.HR.DataAcces
{
    public interface IAdressRepository
    {
        Task<Adress> Create(Adress adress);
        Task<IEnumerable<Adress>> GetAll();
        Task<Adress> Get(int id);
        Task<Adress> Update(int id, Adress adress);
        Task<bool> Delete(int id);
    }
}
