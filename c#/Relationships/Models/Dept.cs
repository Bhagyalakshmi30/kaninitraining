using System;
using System.Collections.Generic;

namespace Relationships.Models;

public partial class Dept
{
    public int Deptno { get; set; }

    public string? DeptName { get; set; }

    public virtual ICollection<Emp> Emps { get; set; } = new List<Emp>();
}
