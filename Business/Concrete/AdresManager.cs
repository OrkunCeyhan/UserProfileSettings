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
    public class AdresManager : IAdresService
    {
        IAdresDal _adresDal;
        public AdresManager(IAdresDal adresDal)
        {
            _adresDal = adresDal;
        }
        public void Add(Adres adres)
        {
            _adresDal.Add(adres);
        }

        public void Delete(Adres adres)
        {
            _adresDal.Delete(adres);
        }

        public List<Adres> GetAll()
        {
            return _adresDal.GetAll();
        }

        public List<Adres> GetAllAdressWithUserId(int userId)
        {
            return _adresDal.GetAll(i=>i.userId==userId);
        }

        public Adres GetById(int adressId)
        {
            return _adresDal.Get(x => x.adresId == adressId);
        }

        public void Update(Adres adres)
        {
            _adresDal.Update(adres);
        }
    }
}
