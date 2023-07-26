using System;
using System.Collections.Generic;

namespace Relationships.Models;

public partial class Emp
{
    public int Empid { get; set; }

    public string? Ename { get; set; }

    public int? Deptno { get; set; }

    public virtual Dept? DeptnoNavigation { get; set; }
}
