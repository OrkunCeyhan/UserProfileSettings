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
    public class PaymentCardManager : IPaymentCardService
    {
        IPaymentCardDal _paymentCardDal;
        public PaymentCardManager(IPaymentCardDal paymentCardDal)
        {
            _paymentCardDal = paymentCardDal;
        }
        public void Add(PaymentCard paymentCard)
        {
            _paymentCardDal.Add(paymentCard);
        }

        public void Delete(PaymentCard paymentCard)
        {
            _paymentCardDal.Delete(paymentCard);
        }

        public List<PaymentCard> GetAll()
        {
            return _paymentCardDal.GetAll();
        }

        public List<PaymentCard> GetAllPaymentCardWithUserId(int userId)
        {
            return _paymentCardDal.GetAll(x=>x.userId==userId);
        }

        public PaymentCard GetById(int paymentCardId)
        {
            return _paymentCardDal.Get(x=>x.paymentCardId==paymentCardId);
        }

        public void Update(PaymentCard paymentCard)
        {
            _paymentCardDal.Update(paymentCard);
        }
    }
}
