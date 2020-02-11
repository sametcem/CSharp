using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6.Models
{
    public class Emp
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public int Sal { get; set; }
        public int? Comm { get; set; }
        public int Deptno { get; set; }
        public int? Mgr { get; set; }
        public DateTime HireDate { get; set; }
        public string Job { get; set; }
    }
}
