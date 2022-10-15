using Demo.BL.Interface;
using Demo.DAL.Context;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class CityRep:ICityRep
    {

        private readonly DemoContext db;

        public CityRep(DemoContext db)
        {
            this.db = db;
        }


        public IEnumerable<City> Get(Expression<Func<City, bool>> filter = null)
        {
            if (filter == null)
            {
                var data = db.City.Select(a => a);
                return data;
            }
            else
            {
                return db.City.Where(filter);
            }
        }
    }
}
