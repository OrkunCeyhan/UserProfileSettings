using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
        // Oratk metot ımzalarrımız IEntityRepository dan gelecek
        // ayrıyeten diger dallardan farklı olacak metor ımzlarımız olursa
        // bura yazacagız.

        //User GetWithAdress(Expression<Func<User, bool>> filter);
        
        //User GetWithCard(Expression<Func<User, bool>> filter);
    }
}
