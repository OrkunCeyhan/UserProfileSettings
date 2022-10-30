using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User>, IUserDal
    {
        //Context context = new Context();
        //public User GetWithAdress(Expression<Func<User, bool>> filter)
        //{
        //    //burada cozerken ef core ıcerısındekı
        //    //ıclude metodu ıle usera ait adres bılgılerını getırıyorum.
        //    return context.Set<User>()
        //        //.Include(i=>i.Adres)
        //        //userı set ederken adresı de dahıl et
        //        .SingleOrDefault(filter);
        //}

        //public User GetWithCard(Expression<Func<User, bool>> filter)
        //{
        //    return context.Set<User>()
        //       //.Include(i => i.PaymentCard)
        //       .SingleOrDefault(filter);
        //}
    }
}
