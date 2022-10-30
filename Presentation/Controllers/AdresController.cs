using Business.Concrete;
using DataAccess;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class AdresController : Controller
    {
        Context context = new Context();
        AdresManager adresManager = new AdresManager(new EfAdresDal());
        public IActionResult MyAdresses()
        {
            var userMail = User.Identity.Name;
            // giriş yapanın maılını al
            // usermaıle ata

            var fullName = context.Users.Where(x => x.eMail == userMail)
               .Select(y => y.fullName)
               .FirstOrDefault();
            ViewData["FullName"] = fullName;
            // giriş yapanın maılıne gore
            // veritabanındakı fullname ı sec ve fullName ata
            // userlayoutta kullanacagımız ıcın viewdataya da atadık.

            var imageUrl = context.Users.Where(x => x.eMail == userMail)
                .Select(y => y.imageUrl)
                .FirstOrDefault();
            ViewData["Image"] = imageUrl;
            // giriş yapanın maılıne gore
            // veritabanındakı resmi ı sec ve imageUrlye ata
            // userlayoutta kullanacagımız ıcın viewdataya da atadık.
            
            var id = context.Users.Where(x => x.eMail == userMail)
                    .Select(y => y.userId)
                    .FirstOrDefault();
            //giriş yapanının maılını bılıyorusam onun userıdsını ogrenebılıırım
            //kullanıcı ıdye ulasmıs olduk artık.

            var list = adresManager.GetAllAdressWithUserId(id);
            return View(list);

        }
        [HttpGet]
        public IActionResult AddAdress()
        {
            var userMail = User.Identity.Name;


            var fullName = context.Users.Where(x => x.eMail == userMail)
               .Select(y => y.fullName)
               .FirstOrDefault();
            ViewData["FullName"] = fullName;


            var imageUrl = context.Users.Where(x => x.eMail == userMail)
                .Select(y => y.imageUrl)
                .FirstOrDefault();
            ViewData["Image"] = imageUrl;

            return View();
        }
        [HttpPost]
        public IActionResult AddAdress(Adres adres)
        {
            var userMail = User.Identity.Name;
          

           

           
            var userId = context.Users.Where(x => x.eMail == userMail)
                .Select(y => y.userId)
                .FirstOrDefault();

            adres.userId = userId;
            adresManager.Add(adres);

            return RedirectToAction("MyAdresses", "Adres");
        }
        [HttpGet]      
        public IActionResult EditAdress(int id)
        {
            var userMail = User.Identity.Name;


            var fullName = context.Users.Where(x => x.eMail == userMail)
               .Select(y => y.fullName)
               .FirstOrDefault();
            ViewData["FullName"] = fullName;


            var imageUrl = context.Users.Where(x => x.eMail == userMail)
                .Select(y => y.imageUrl)
                .FirstOrDefault();
            ViewData["Image"] = imageUrl;
            var adres = adresManager.GetById(id);
            return View(adres);
        }
        [HttpPost]
        public IActionResult EditAdress(Adres adres)
        {
            

            adresManager.Update(adres);
            return RedirectToAction("MyAdresses", "Adres");
        }
        public IActionResult DeleteAdress(int id)
        {
            var adres = adresManager.GetById(id);
            adresManager.Delete(adres);
            return RedirectToAction("MyAdresses", "Adres");
        }
    }
}
