using NajotTalim.HR.API.Models;
using NajotTalim.HR.DataAcces;
using NajotTalim.HR.DataAcces.Entities;

namespace NajotTalim.HR.API.Services
{
    public class EmployeeCRUDService : IGenericCRUDService<EmployeeModel>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeCRUDService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeModel> Create(EmployeeModel model)
        {
            var employee = new Employee
            {
                FullName = model.FullName,
                Department = model.Department,
                Email = model.Email,
                Salary = model.Salary,
            };

            var createdEmployee = await _employeeRepository.Create(employee);
            var result = new EmployeeModel
            {
                Id = createdEmployee.Id,
                FullName = createdEmployee.FullName,
                Department = createdEmployee.Department,
                Email = createdEmployee.Email,
                Salary = createdEmployee.Salary,
            };

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _employeeRepository.Delete(id);
        }

        public async Task<EmployeeModel> Get(int id)
        {
            var employee = await _employeeRepository.Get(id);
            var model = new EmployeeModel
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Department = employee.Department,
                Email = employee.Email,
                Salary = employee.Salary,
            };

            return model;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            var result = new List<EmployeeModel>();
            var employees = await _employeeRepository.GetAll();
            foreach (var employee in employees)
            {
                var model = new EmployeeModel
                {
                    Id = employee.Id,
                    FullName = employee.FullName,
                    Department = employee.Department,
                    Email = employee.Email,
                    Salary = employee.Salary,
                };
                result.Add(model);
            }

            return result;
        }

        public async Task<EmployeeModel> Update(int id, EmployeeModel model)
        {
            var employee = new Employee
            {
                Id = model.Id,
                FullName = model.FullName,
                Department = model.Department,
                Email = model.Email,
                Salary = model.Salary,
            };

            var updatedEmployee = await _employeeRepository.Update(id, employee);
            var result = new EmployeeModel
            {
                Id = updatedEmployee.Id,
                FullName = updatedEmployee.FullName,
                Department = updatedEmployee.Department,
                Email = updatedEmployee.Email,
                Salary = updatedEmployee.Salary,
            };

            return result;
        }
    }
}
