using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Operations
    {
        public List<Employee> GetAllEmployees()
        {
            DacWondersEntities1 DacWondersEntities = new DacWondersEntities1();
            List<Employee> lst = (from emp in DacWondersEntities.Employees select emp).ToList();
            DacWondersEntities.Dispose();
            return lst;
        }
        public void AddEmployee(Employee emp)
        {
            using (DacWondersEntities1 DacWondersEntities = new DacWondersEntities1())
            {
                DacWondersEntities.Employees.Add(emp);
                DacWondersEntities.SaveChanges();
            }
        }
        public void UpdateEmployee(Employee empToBeModified)
        {
            using (DacWondersEntities1 dacWondersEntities = new DacWondersEntities1())
            {
                var empSelected = (from emp in dacWondersEntities.Employees
                                   where emp.eid == empToBeModified.eid
                                   select emp).First();
                empSelected.ename = empToBeModified.ename;
                empSelected.dept = empToBeModified.dept;
                dacWondersEntities.SaveChanges();
            }
        }
        public void DeleteEmployee(int id)
        {
            using (DacWondersEntities1 dacWondersEntities = new DacWondersEntities1())
            {
                var empSelected = (from emp in dacWondersEntities.Employees
                                   where emp.eid == id
                                   select emp).First();
                dacWondersEntities.Employees.Remove(empSelected);
                dacWondersEntities.SaveChanges();
            }
        }
    }
}