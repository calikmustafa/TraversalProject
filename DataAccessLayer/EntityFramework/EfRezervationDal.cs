using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfRezervationDal : GenericRepository<Rezervation>, IRezervationDal
    {
        public List<Rezervation> GetListWithRezervationByAccepted(int id)
        {
            using (var context = new Context())
            {
                return context.Rezervations.Include(x => x.Destination).Where(x => x.Status == "Onaylandı" && x.AppUserId == id).ToList();
            }
        }

        public List<Rezervation> GetListWithRezervationByPrevious(int id)
        {
            using (var context = new Context())
            {
                return context.Rezervations.Include(x => x.Destination).Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserId == id).ToList();
            }
        }

        public List<Rezervation> GetListWithRezervationByWaitApproval(int id)
        {
            using (var context=new Context())
            {
                return context.Rezervations.Include(x => x.Destination).Where(x => x.Status == "Onay Bekliyor" && x.AppUserId==id).ToList();
            }
        }
    }
}
