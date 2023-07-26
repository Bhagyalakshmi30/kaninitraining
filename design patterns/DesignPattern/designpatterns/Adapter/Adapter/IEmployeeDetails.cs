using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public interface IEmployeeDetails
    {
        string GetName();
        string GetPosition();
        decimal GetSalary();

    }
}
