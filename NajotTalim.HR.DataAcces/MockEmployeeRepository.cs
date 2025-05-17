using System.Collections.Concurrent;
using NajotTalim.HR.DataAcces.Entities;

namespace NajotTalim.HR.DataAcces
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private static ConcurrentDictionary<int, Employee> _employees = new ConcurrentDictionary<int, Employee>();
        private static object locker = new object();

        public MockEmployeeRepository()
        {
            Init();
        }
        private void Init()
        {
            _employees.TryAdd(1, new Employee { Id = 1, FullName = "John Doe", Department = "IT", Email = "john@nt.com" });
            _employees.TryAdd(2, new Employee { Id = 2, FullName = "Alice Smith", Department = "Accounting", Email = "Alice@nt.com" });
            _employees.TryAdd(3, new Employee { Id = 3, FullName = "Bill Hamilton", Department = "HR", Email = "Bill@nt.com" });
            _employees.TryAdd(4, new Employee { Id = 4, FullName = "Warren James", Department = "Marketing", Email = "Warren@nt.com" });
            _employees.TryAdd(5, new Employee { Id = 5, FullName = "Peter Kent", Department = "Management", Email = "Peter@nt.com" });
        }

        public async Task<Employee> Create(Employee employee)
        {
            int newId = 0;
            lock (locker)
            {
                newId = _employees.Keys.Max() + 1;
            }
            employee.Id = newId;
            _employees.TryAdd(newId, employee);
            return await Task.FromResult(employee);
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await Task.FromResult(_employees.Values);
        }

        public async Task<Employee> Get(int id)
        {
            return await Task.FromResult(_employees[id]);
        }

        public async Task<Employee> Update(int id, Employee employee)
        {
            await Task.FromResult(_employees[id] = employee);
            return employee;
        }

        public Task<bool> Delete(int id)
        {
            if (_employees.ContainsKey(id))
            {
                _employees.TryRemove(id, out _);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
