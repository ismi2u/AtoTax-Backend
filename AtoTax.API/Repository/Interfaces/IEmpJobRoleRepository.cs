using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IEmpJobRoleRepository : IRepository<EmpJobRole>
    {

        Task<EmpJobRole> UpdateAsync(EmpJobRole entity);
    }
}
