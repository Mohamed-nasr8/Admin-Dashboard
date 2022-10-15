using Demo.BL.Interface;
using Demo.DAL.Context;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
  public  class CountryRep: ICountryRep

    {

        private readonly DemoContext db;

        public CountryRep(DemoContext db)
        {
            this.db = db;
        }


        public IEnumerable<Country> Get()
        {

            var data = db.Country.Select(a => a);
            return data;

        }


    }
}
