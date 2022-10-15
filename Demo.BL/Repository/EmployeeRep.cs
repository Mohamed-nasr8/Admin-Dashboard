using Demo.BL.Interface;
using Demo.DAL.Context;
using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly DemoContext db;

        public EmployeeRep(DemoContext db)
        {
            this.db = db;
        }


        public Employee Creat(Employee obj)
        {


            db.Employee.Add(obj);
            db.SaveChanges();

            return db.Employee.OrderBy(a => a.Id).LastOrDefault();

        }

        public Employee Delet(Employee obj)
        {

            db.Employee.Remove(obj);
            db.SaveChanges();
            return db.Employee.Find(obj.Id);

        }
        public Employee Edit(Employee obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

            return db.Employee.Find(obj.Id);

        }

        public IEnumerable<Employee> Get()
        {

            var data = db.Employee.Include("Department").Include("District").Select(a => a);
            return data;

        }

        public Employee GetById(int id)
        {

            var data = db.Employee.Where(a => a.Id == id).Include("District").FirstOrDefault();
            return data;


        }


        public IEnumerable<Employee> SearchByName( string Name)
        {

            var data = db.Employee.Include("Department").Include("District").Where(a=>a.Name.Contains(Name));
            return data;

        }
    }
}

