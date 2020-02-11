using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Exercise6.Models;

namespace Exercise6
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Emp> Emps { get; set; }
        public List<Dept> Depts { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            //Example();
            //SimpleQuery1();
            //SimpleQuery2();
            //SimpleQuery3();
            //SimpleQuery4();
            //SimpleQuery5();
            //SimpleQuery6();
            //SimpleQuery11();
           
            

        }

        public void LoadData()
        {
            Emps = new List<Emp>();
            Depts = new List<Dept>();

            Emps.Add(new Emp
            {
                Empno = 7369,
                Ename = "SMITH",
                Job = "CLERK",
                Mgr = 7902,
                HireDate = new DateTime(1980, 12, 17),
                Sal = 800,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7499,
                Ename = "ALLEN",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 2, 20),
                Sal = 1600,
                Comm = 300,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7521,
                Ename = "WARD",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 2, 22),
                Sal = 1250,
                Comm = 500,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7566,
                Ename = "JONES",
                Job = "MANAGER",
                Mgr = 7839,
                HireDate = new DateTime(1981, 4, 2),
                Sal = 2975,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7654,
                Ename = "MARTIN",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 9, 28),
                Sal = 1250,
                Comm = 1400,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7698,
                Ename = "BLAKE",
                Job = "MANAGER",
                Mgr = 7839,
                HireDate = new DateTime(1981, 5, 1),
                Sal = 2850,
                Comm = 0,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7782,
                Ename = "CLARK",
                Job = "MANAGER",
                Mgr = 7839,
                HireDate = new DateTime(1981, 6, 9),
                Sal = 2450,
                Comm = 0,
                Deptno = 10
            });

            Emps.Add(new Emp
            {
                Empno = 7788,
                Ename = "SCOTT",
                Job = "ANALYST",
                Mgr = 7566,
                HireDate = new DateTime(1982, 12, 9),
                Sal = 3000,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7839,
                Ename = "KING",
                Job = "PRESIDENT",
                Mgr = null,
                HireDate = new DateTime(1981, 11, 17),
                Sal = 5000,
                Comm = 0,
                Deptno = 10
            });

            Emps.Add(new Emp
            {
                Empno = 7844,
                Ename = "TURNER",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 9, 8),
                Sal = 1500,
                Comm = 0,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7876,
                Ename = "ADAMS",
                Job = "CLERK",
                Mgr = 7788,
                HireDate = new DateTime(1983, 1, 12),
                Sal = 1100,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7900,
                Ename = "JAMES",
                Job = "CLERK",
                Mgr = 7698,
                HireDate = new DateTime(1981, 12, 3),
                Sal = 950,
                Comm = 0,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7902,
                Ename = "FORD",
                Job = "ANALYST",
                Mgr = 7566,
                HireDate = new DateTime(1981, 12, 3),
                Sal = 3000,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7934,
                Ename = "MILLER",
                Job = "CLERK",
                Mgr = 7782,
                HireDate = new DateTime(1982, 1, 23),
                Sal = 1300,
                Comm = 0,
                Deptno = 10
            });

            Depts.Add(new Dept
            {
                Deptno = 10,
                Dname = "ACCOUNTING",
                Loc = "NEW YORK"
            });

            Depts.Add(new Dept
            {
                Deptno = 20,
                Dname = "RESEARCH",
                Loc = "DALLAS"
            });

            Depts.Add(new Dept
            {
                Deptno = 30,
                Dname = "SALES",
                Loc = "CHICAGO"
            });

            Depts.Add(new Dept
            {
                Deptno = 40,
                Dname = "OPERATIONS",
                Loc = "BOSTON"
            });
        }

        private void Example()
        {
            //Query syntax
            var result = from e in Emps
                         where e.Ename.StartsWith("K")
                         select e;

            //Lambda and Extension methods syntax
            var result2 = Emps.Where(e => e.Ename.StartsWith("K"));


            DataGrid.ItemsSource = result.ToList();
        }

        //Sort all EMP data according to ENAME.





        private void SimpleQuery1()
        {
            var result = Emps.OrderBy(e => e.Ename);

            DataGrid.ItemsSource = result.ToList();
        }

        private void SimpleQuery2()
        {
            var result = Emps.OrderBy(e => e.Deptno).OrderByDescending(e => e.Sal);
            DataGrid.ItemsSource = result.ToList();

        }

        private void SimpleQuery3()
        {
            var result = Emps
                .Where(emp => emp.Job =="CLERK")
                .Select(emp => new
                {
                    emp.Ename,
                    emp.Empno,
                    emp.Job,
                    emp.Deptno

                });

            DataGrid.ItemsSource = result.ToList();
        }

        private void SimpleQuery4()
        {
            var result = Emps.Where(e => e.Ename.StartsWith("S"));

            DataGrid.ItemsSource = result.ToList();
        }

        private void SimpleQuery5()
        {
            var result = Emps.Where(e => e.Mgr == null);

            DataGrid.ItemsSource = result.ToList();
        }

        private void SimpleQuery6()
        {
            var result = Emps
                .Where(emp => emp.Sal < 1000 || emp.Sal > 2000)
                .Select(emp => new
                {
                    LastName = emp.Ename,
                    emp.Sal
                });

            DataGrid.ItemsSource = result.ToList();
        }

        //Mistake.
        private void SimpleQuery7()
        {
            var result = from e in Emps
                        select e.Ename;

            var result2 = from e in Emps
                        select e.Deptno;

            foreach (Emp emp in Emps)
            {
                Debug.WriteLine(String.Format("{0} works in department {1} ", result, result2));
            }
        }
        //Mistake
        private void SimpleQuery8()
        {
            var result = Emps
                .Where(emp => emp.Sal > 1000 || emp.Sal < 2000 && emp.Job == "CLERK")
                .Select(emp => new
                {
                    LastName = emp.Ename,
                    emp.Sal
                });
        }
        //Mistake
        private void SimpleQuery9()
        {
            var result = Emps
                .Where(emp => (emp.Sal > 1000 || emp.Sal < 2000) || (emp.Job=="CLERK"))
                .Select(emp => new
                {
                    LastName = emp.Ename,
                    emp.Sal
                });
            DataGrid.ItemsSource = result.ToList();

        }

        private void SimpleQuery10()
        {
            var result = Emps
                .Where(emp => emp.Job =="MANAGER" && emp.Sal > 1500)
                .Where(emp => emp.Job =="SALESMAN")
                .Select(emp => new
            {
                LastName = emp.Ename,
                emp.Sal
            });

            DataGrid.ItemsSource = result.ToList();

        }

        private void SimpleQuery11()
        {
            var result = Emps.Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => emp);
            DataGrid.ItemsSource = result.ToList();

        }








        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps
                orderby emp.Ename
                select emp;

            DataGrid.ItemsSource = result.ToList();
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps
                orderby emp.Deptno, emp.Sal descending
                select new
                {
                    Empno = emp.Empno,
                    Ename = emp.Ename,
                    Job = emp.Job,
                    Mgr = emp.Mgr,
                    Hiredate = emp.HireDate,
                    Sal = emp.Sal,
                    Comm = emp.Comm,
                    Deptno = emp.Deptno
                };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Button3_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps
                where emp.Job == "CLERK"
                select new
                {
                    Empno = emp.Empno,
                    Ename = emp.Ename,
                    Job = emp.Job,
                    Deptno = emp.Deptno
                };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Button4_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps
                where emp.Ename.StartsWith("S")
                select emp;
            DataGrid.ItemsSource = result.ToList();
        }

        private void Button5_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps
                where emp.Mgr == null
                select emp;
            DataGrid.ItemsSource = result.ToList();
        }

        private void Button6_OnClick(object sender, RoutedEventArgs e)
        {
            var result = Emps.Where(emp => emp.Sal < 1000 || emp.Sal > 2000);
            DataGrid.ItemsSource = result.ToList();
        }

        private void Button7_OnClick(object sender, RoutedEventArgs e)
        {
            var result = Emps.Select(emp => new { Ename = emp.Ename + " works in department " + emp.Deptno });
            DataGrid.ItemsSource = result.ToList();
        }

        private void Button8_OnClick(object sender, RoutedEventArgs e)
        {
            var result = Emps.Where(emp => emp.Job == "CLERK" && (emp.Sal < 1000 || emp.Sal > 2000));
            DataGrid.ItemsSource = result.ToList();
        }

        private void Button9_OnClick(object sender, RoutedEventArgs e)
        {
            var result = Emps.Where(emp => emp.Job == "CLERK" || (emp.Sal < 1000 || emp.Sal > 2000));
            DataGrid.ItemsSource = result.ToList();
        }

        private void Button10_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps
                where (emp.Job == "MANAGER" && emp.Sal > 1500) || (emp.Job == "SALESMAN")
                select emp;
            DataGrid.ItemsSource = result.ToList();
        }

        private void Button11_OnClick(object sender, RoutedEventArgs e)
        {
            var result = (from emp in Emps
                join d in Depts on emp.Deptno equals d.Deptno
                select emp);

            DataGrid.ItemsSource = result.ToList();

        }

        private void Button12_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps
                join dep in Depts
                    on emp.Deptno equals dep.Deptno
                orderby dep.Dname
                select new
                {
                    Emp = emp.Ename,
                    Dept = dep.Dname
                };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Button13_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps
                join dep in Depts
                    on emp.Deptno equals dep.Deptno
                select new
                {
                    Emp = emp.Ename,
                    Dept = dep.Dname,
                    Num = dep.Deptno
                };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Button14_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps
                join dep in Depts
                    on emp.Deptno equals dep.Deptno
                where emp.Sal > 1500
                select new
                {
                    Emp = emp.Ename,
                    Loc = dep.Loc,
                    Dept = dep.Dname
                };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Button15_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps
                join dep in Depts
                    on emp.Deptno equals dep.Deptno
                where dep.Loc == "DALLAS"
                select emp;

            DataGrid.ItemsSource = result.ToList();
        }

        private void Button16_OnClick(object sender, RoutedEventArgs e)
        {
            //var result = (from emp in Emps
            //select emp.Sal).Average();

            //MessageBox.Show("Average Salary: " + result.ToString());

            var result = Emps.Where(x => x.Job != "MANAGER").GroupBy(s => s.Job)
                .Select(g => new { job = g.Key, Avg = g.Average(s => s.Sal) });
            DataGrid.ItemsSource = result.ToList();

        }

        private void Button17_OnClick(object sender, RoutedEventArgs e)
        {
            //var result = (from emp in Emps
            // where emp.Job == "CLERK"
            //select emp.Sal).Min();

            //MessageBox.Show("Min earning at CLERK position: " + result.ToString());

            var result = Emps.Where(x => x.Sal.Equals(Emps.Min(y => y.Sal)));
            DataGrid.ItemsSource = result.ToList();
        }

        private void Button18_OnClick(object sender, RoutedEventArgs e)
        {
           
            var result = (from emp in Emps
                where emp.Deptno == 20
                select emp).Count();

            MessageBox.Show("The number of people employed in DEPT 20: " + result.ToString());
            
        }

        private void Button19_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps
                group emp by new
                {
                    emp.Job
                } into g
                select new
                {
                    job = g.Key,
                    avg = g.Average(p => p.Sal)
                    
                };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Button20_OnClick(object sender, RoutedEventArgs e)
        {
            var ex = from emp in Emps where emp.Job == "MANAGER" select emp;
            var result = from emp in Emps.Except(ex)
                group emp by new
                {
                    emp.Job
                } into g
                select new
                {
                    job = g.Key,
                    avg = g.Average(p => p.Sal)
                };

            DataGrid.ItemsSource = result.ToList();
        }

        private void Button21_OnClick(object sender, RoutedEventArgs e)
        {
            var min = (from emp in Emps select emp.Sal).Min();
            var result = from emp in Emps where emp.Sal == min select emp;

            DataGrid.ItemsSource = result.ToList();

        }

        private void Button22_OnClick(object sender, RoutedEventArgs e)
        {
            var pos = (from emp in Emps where emp.Ename == "BLAKE" select emp.Job).First();
            var result = from emp in Emps where emp.Job == pos select emp;

            DataGrid.ItemsSource = result.ToList();

        }

        private void Button23_OnClick(object sender, RoutedEventArgs e)
        {
           
            var result = from emp in Emps
                group emp by new
                {
                    emp.Deptno
                } into g
                select new
                {
                    
                    deptno = g.Key,
                    min = g.Min(p => p.Sal)

                };

            DataGrid.ItemsSource = result.ToList();

        }

        private void Button24_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps where emp.Sal == (from em in Emps where em.Deptno == emp.Deptno select em.Sal).Min() select emp;

            DataGrid.ItemsSource = result.ToList();

        }

        private void Button25_OnClick(object sender, RoutedEventArgs e)
        {
            var result = from emp in Emps where Emps.Any(em => em.Sal < emp.Sal && em.Deptno == 30) select emp;

            DataGrid.ItemsSource = result.ToList();


        }
    }     
}
