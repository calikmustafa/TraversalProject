using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRezervationService:IGenericService<Rezervation>
    {
        
        List<Rezervation> GetListWithRezervationByWaitApproval(int id);
        List<Rezervation> GetListWithRezervationByAccepted(int id);
        List<Rezervation> GetListWithRezervationByPrevious(int id);
    }
}
