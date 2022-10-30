using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        public List<User> GetAll();
        
        public User GetById(int userId);
        //public User GetByIdWithAdress(int userId);
        //public User GetByIdWithCard(int userId);
    }
}
