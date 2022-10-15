using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IDistrictRep
    {
        IEnumerable<District> Get(System.Linq.Expressions.Expression<Func<District, bool>> filter = null);

        
    }
}
