using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdresService
    {
        void Add(Adres adres);
        void Update(Adres adres);
        void Delete(Adres adres);
        public List<Adres> GetAll();
        public List<Adres> GetAllAdressWithUserId(int userId);
        public Adres GetById(int adressId);
       
    }
}
