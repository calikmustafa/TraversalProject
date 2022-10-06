using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRezervationDal:IGenericDal<Rezervation>
    {
        List<Rezervation> GetListWithRezervationByWaitApproval(int id);
        List<Rezervation> GetListWithRezervationByAccepted(int id);
        List<Rezervation> GetListWithRezervationByPrevious(int id);
    }
}
