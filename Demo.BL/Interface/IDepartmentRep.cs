using Demo.BL.Models;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IDepartmentRep
    {

        IEnumerable<Department> Get();

        Department GetById(int id);


        void Creat(Department obj);

        void Edit(Department obj);
        void Delet(Department obj);

    }
}
