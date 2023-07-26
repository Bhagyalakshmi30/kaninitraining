using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Relationships.Models;
using Relationships.Repository.EmpServices;

namespace Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpsController : ControllerBase
    {
        public readonly IEmpServices ctx;
        public EmpsController(IEmpServices _ctx)
        {
            ctx = _ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<Emp>> GetEmps()
        {
            return await ctx.GetEmps();
        }

        [HttpGet("{id}")]
        public async Task<Emp> GetEmp(int id)
        {
            return await ctx.GetEmp(id);
        }
        [HttpPost]
        public string PostEmp(Emp emp)
        {
            return ctx.PostEmp(emp);
        }

        [HttpPut("{id}")]
        public async Task<Emp> PutEmp(int id, Emp emp)
        {
            return await ctx.PutEmp(id, emp);
        }
        [HttpDelete("{id}")]
        public async Task<string> DeleteEmp(int id)
        {
            return await ctx.DeleteEmp(id);
        }

        }
}
