using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetById(int userId)
        {
            return _userDal.Get(x=>x.userId==userId);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        //public User GetByIdWithAdress(int userId)
        //{
        //    return _userDal.GetWithAdress(x=>x.userId==userId);
        //}

        //public User GetByIdWithCard(int userId)
        //{
        //    return _userDal.GetWithCard(x => x.userId == userId);
        //}
    }
}
