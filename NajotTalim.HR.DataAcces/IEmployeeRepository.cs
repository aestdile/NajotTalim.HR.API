using NajotTalim.HR.DataAcces.Entities;

namespace NajotTalim.HR.DataAcces
{
    public interface IEmployeeRepository
    {
        Task<Employee> Create(Employee employee);
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> Get(int id);
        Task<Employee> Update(int id, Employee employee);
        Task<bool> Delete(int id);
    }
}
