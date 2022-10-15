 using Demo.BL.Interface;
using Demo.BL.Models;
using Demo.DAL.Context;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo.BL.Repository
{
   public class DeprtamentRep:IDepartmentRep
    {
        private readonly DemoContext db;

        public DeprtamentRep(DemoContext db)
        {
            this.db = db;
        }


        public void Creat(Department obj)
        {
           

            db.Department.Add(obj); 
            db.SaveChanges();



        }

        public void Delet(Department obj)
        {

            db.Department.Remove(obj);
            db.SaveChanges();
        }

        public void Edit(Department obj)
        {

            db.Entry(obj).State =EntityState.Modified;

            db.SaveChanges();

        }

        public IEnumerable<Department> Get()
        {

            var data = db.Department.Select(a =>a);
            return data;

        }

        public Department GetById(int id)
        {

            var data = db.Department.Where(a => a.Id == id).FirstOrDefault();
            return data;

        }
    }
}
