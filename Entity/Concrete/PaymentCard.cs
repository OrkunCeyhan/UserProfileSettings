using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class PaymentCard
    {
        [Key]
        public int paymentCardId { get; set; }
        [StringLength(20)]
        public string name { get; set; }
        public int userId { get; set; }
        public virtual User User { get; set; }

        //public string paymentCardNo { get; set; }
        //public string expiredDate { get; set; }
    }
}
