using Microsoft.AspNetCore.Mvc;
using Relationships.Models;

namespace Relationships.Repository.DeptServices
{
    public interface IDeptServices
    {
        Task<IEnumerable<Dept>> GetDepts();
        Task<Dept> GetDept(int id);
        Task<Dept> PutDept(int id, Dept dept);
        Task<Dept> PostDept(Dept dept);
        Task<string> DeleteDept(int id);


    }
}
