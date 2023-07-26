using Microsoft.AspNetCore.Mvc;
using Relationships.Models;

namespace Relationships.Repository.EmpServices
{
    public interface IEmpServices
    {
        Task<IEnumerable<Emp>> GetEmps();
        Task<Emp> GetEmp(int id);
        Task<Emp> PutEmp(int id, Emp emp);
        string PostEmp(Emp emp);
        Task<string> DeleteEmp(int id);

    }
}
