using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=UserProfileSettingsDB;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //migration yapıldıgında veritabanına birkac hazır verı gonderıyoruz.

            modelBuilder.Entity<Adres>().HasData
                (
                    new Adres()
                    {
                        adresId = 1,
                        name = "Ev",
                        adress = "Cemal Sururi Sokak Mecidiyekoy/Sisli/Istanbul",
                        userId=1,
                        
                    },
                    new Adres()
                    {
                        adresId = 2,
                        name = "Is",
                        adress = "Bilmemne Sokak Bostancı/Kadıkoy/Istanbul",
                        userId=1,
                    },
                    new Adres()
                    {
                        adresId = 3,
                        name = "Ev",
                        adress = "Cemal Sururi Sokak Mecidiyekoy/Sisli/Istanbul",
                        userId = 2,
                    }
                );

            modelBuilder.Entity<PaymentCard>().HasData
               (
                   new PaymentCard()
                   {
                       paymentCardId = 1,
                       name = "Akbank",
                       userId=1,
                   },
                   new PaymentCard()
                   {
                       paymentCardId = 2,
                       name = "Vakıfbank",
                       userId=2,
                   }
               );

            modelBuilder.Entity<User>().HasData
               (
                   new User()
                   {
                       userId = 1,
                       nickName = "Samet",
                       passWord = "123",
                       fullName = "Abdussamet Solak",
                       eMail = "samet66@gmail.com",
                       phoneNumber = "123",
                       gender = true,
                       birthDate = "30-12-1992",
                       imageUrl= "https://i0.wp.com/www.thewhitetree.org/wp-content/uploads/2015/11/Thorin.jpg",
                   },
                   new User()
                   {
                       userId = 2,
                       nickName = "Elif",
                       passWord = "123",
                       fullName = "Elif Solak",
                       eMail = "elif@gmail.com",
                       phoneNumber = "123",
                       gender = false,
                       birthDate = "30-12-1994",
                       imageUrl = "https://cdn.yeniakit.com.tr/images/news/625/cate-blanchett-b2b56d.jpg",
                   }
               ); ; ;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }
        public DbSet<Adres> Adresses  { get; set; }
    }
}
