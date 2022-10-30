using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Adres
    {
        [Key]
        public int adresId { get; set; }
        [StringLength(30)]
        public string name { get; set; }
        [StringLength(60)]
        public string adress { get; set; }
        // adress aslında boyle olmamalı
        // burası daha detyalı olarak daha sonra ekleyecegım.
        // muhtemelen bir api kullanarak
        public int userId { get; set; }
        public virtual User User { get; set; }
    }
}
