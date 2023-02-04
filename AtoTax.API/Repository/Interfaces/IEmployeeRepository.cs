using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {

        Task<Employee> UpdateAsync(Employee entity);
    }
}
