using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Relationships.Models;
using Relationships.Repository.DeptServices;
using Relationships.Repository.EmpServices;

namespace Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptsController : ControllerBase
    {
        public readonly IDeptServices _context;

        public DeptsController(IDeptServices context)
        {
            _context = context;
        }

        // GET: api/Depts
        [HttpGet]
        public async Task<IEnumerable<Dept>> GetDepts()
        {
         

            return await _context.GetDepts();
        }

        // GET: api/Depts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dept>> GetDept(int id)
        {
          
            return await _context.GetDept(id);
        }

        // PUT: api/Depts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Dept> PutDept(int id, Dept dept)
        {
           

            return await _context.PutDept(id, dept);
        }

        // POST: api/Depts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Dept> PostDept(Dept dept)
        {
          
            

            return await _context.PostDept(dept);
        }

        // DELETE: api/Depts/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteDept(int id)
        {
           

            return await _context.DeleteDept(id);
        }

       
    }
}
