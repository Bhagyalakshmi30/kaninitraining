using Microsoft.EntityFrameworkCore;
using Relationships.Models;

namespace Relationships.Repository.DeptServices
{
    public class DeptServices : IDeptServices
    {


        private readonly CompanyContext _context;

        public DeptServices(CompanyContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Dept>> GetDepts()
        {

          var dept= await _context.Depts.ToListAsync();
            return dept ;
        }

        public async Task<Dept> GetDept(int id)
        {
            var dept = await _context.Depts.FirstOrDefaultAsync(x=>x.Deptno==id);

            if (dept is null)
            {
                return null;
            }
            return dept;
        }

        public async Task<Dept> PutDept(int id, Dept dept)
        {
            var dp = await _context.Depts.FirstOrDefaultAsync(x => x.Deptno == id);
            dp.DeptName = dept.DeptName;
            dp.Deptno = dept.Deptno;
            await _context.SaveChangesAsync();
            return dept;
        }

        public async Task<Dept> PostDept(Dept dept)
        {
            _context.Depts.Add(dept);
            _context.SaveChanges();
            return dept;
        }

        public async Task<string> DeleteDept(int id)
        {
            var dep = await _context.Depts.FirstOrDefaultAsync(x=>x.Deptno==id);
            _context.Remove(dep);
            _context.SaveChanges();

            return "Deleted successfully"  ;
        }

    }
}
