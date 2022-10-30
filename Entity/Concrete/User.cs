using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class User
    {
        // User clasımı bir eticaret sıtesını baz alarak olusturdum. 
        [Key]
        public int userId { get; set; }
        [StringLength(30)]
        public string nickName { get; set; }
        [StringLength(30)]
        public string passWord { get; set; }
        [StringLength(30)]
        public string fullName { get; set; }
        [StringLength(40)]
        public string eMail { get; set; }
        [StringLength(15)]
        public string phoneNumber { get; set; }
        public bool gender { get; set; }
        [StringLength(15)]
        public string birthDate  { get; set; }
        [StringLength(500)]
        public string imageUrl { get; set; }
        // burası ıcın daha detyalı resım yukleme ekranı yapmak gerekır.
        public ICollection<Adres> Adresses { get; set; }
        public ICollection<PaymentCard> PaymentCards { get; set; }
    }
}
