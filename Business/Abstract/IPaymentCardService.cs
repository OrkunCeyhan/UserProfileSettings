using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentCardService
    {
        void Add(PaymentCard paymentCard);
        void Update(PaymentCard paymentCard);
        void Delete(PaymentCard paymentCard);
        public List<PaymentCard> GetAll();
        public List<PaymentCard> GetAllPaymentCardWithUserId(int userId);
        public PaymentCard GetById(int paymentCardId);
    }
}
