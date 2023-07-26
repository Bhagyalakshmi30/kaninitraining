using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Relationships.Models;

namespace Relationships.Repository.EmpServices
{
    public class EmpServices : IEmpServices
    {

        public CompanyContext _CompanyContext;
        public EmpServices(CompanyContext CompanyContext)
        {
            _CompanyContext = CompanyContext;
        }

      
        public async Task<IEnumerable<Emp>> GetEmps()
        {
            var Emp = await _CompanyContext.Emps.ToListAsync();
            return Emp;
        }
        

        public async Task<Emp> GetEmp(int id)
        {
            var emp = await _CompanyContext.Emps.FindAsync(id);

            if (emp is null)
            {
                return null;
            }
            return emp;
        }

        public async Task<Emp> PutEmp(int id, Emp emp)
        {
            Emp em = await _CompanyContext.Emps.FirstOrDefaultAsync(x=>x.Empid==id);
            em.Empid=emp.Empid;
            em.Ename= emp.Ename;
            em.Deptno= emp.Deptno;
            await _CompanyContext.SaveChangesAsync();
            return emp;
        }

        public string PostEmp(Emp emp)
        {
            _CompanyContext.Emps.Add(emp);
            _CompanyContext.SaveChanges();
            return "Added successfully";
        }

        public async Task<string> DeleteEmp(int id)
        {
            Emp em= await _CompanyContext.Emps.FirstOrDefaultAsync(x=>x.Empid==id);
            _CompanyContext.Emps.Remove(em);
            _CompanyContext.SaveChanges();

            return "Deleted successfully";
        }
    }
}
