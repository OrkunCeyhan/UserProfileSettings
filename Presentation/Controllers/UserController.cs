using Business.Concrete;
using DataAccess;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Presentation.Controllers
{

    public class UserController : Controller
    {
        Context context = new Context();
        UserManager userManager = new UserManager(new EfUserDal());
        AdresManager adresManager = new AdresManager(new EfAdresDal());
        PaymentCardManager paymentCardManager = new PaymentCardManager(new EfPaymentCardDal());

        // kullanıcı ıle ılgılı tum ıslemler user controllerda olur
        // register -daha yapmadık gercı- ve logın ıcın ayrı controller acılabılır

        [Authorize]
        public IActionResult Index()    
        {
            // giriş yapan kullanıcı bılgılerını alıyoruz.
            // user layoutta kullanacagız.
            var userMail = User.Identity.Name;
            ViewData["UserMail"] = userMail;
            
            // giris yapan emaıl bılgısıne gore fullname bulduk
            var fullName = context.Users.Where(x => x.eMail == userMail)
                .Select(y => y.fullName)
                .FirstOrDefault();
            ViewData["FullName"] = fullName;

            var imageUrl = context.Users.Where(x => x.eMail == userMail)
                .Select(y => y.imageUrl)
                .FirstOrDefault();
            ViewData["Image"] = imageUrl;

            // giris yapan emaıl bılgısıne gore ıd bulduk
            var userid = context.Users.Where(x => x.eMail == userMail)
                .Select(y => y.userId)
                .FirstOrDefault();
            ViewData["UserId"] = userid;
           
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            //Giriş ıslemı
            var results = context.Users.FirstOrDefault(x => x.eMail == user.eMail && x.passWord == user.passWord);
            if (results != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.eMail)
                };

                var userIdentity = new ClaimsIdentity(claims, "User");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);


                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // Cıkıs ıslemı
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult EditProfile()
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

            var id = context.Users.Where(x => x.eMail == userMail)
                    .Select(y => y.userId)
                    .FirstOrDefault();
            var userid = userManager.GetById(id);
            
            return View(userid);
            
        }
        [HttpPost]
        public IActionResult EditProfile(User user)
        {
            userManager.Update(user);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyAdresses()
        {
            var userMail = User.Identity.Name;
            // giriş yapanın maılını al
            // usermaıle ata

            var fullName = context.Users.Where(x => x.eMail == userMail)
               .Select(y => y.fullName)
               .FirstOrDefault();
            ViewData["FullName"] = fullName;


            var imageUrl = context.Users.Where(x => x.eMail == userMail)
                .Select(y => y.imageUrl)
                .FirstOrDefault();
            ViewData["Image"] = imageUrl;

            //giriş yapanının maılını bılıyorusam onun userıdsını ogrenebılıırım
            var id = context.Users.Where(x => x.eMail == userMail)
                    .Select(y => y.userId)
                    //sec neyı sec kullanıcı ıdsını
                    .FirstOrDefault();
            //kullanıcı ıdye ulasmıs olduk artık.

            var list = adresManager.GetAllAdressWithUserId(id);           
            return View(list);

        }
       

        [Authorize]
        [HttpGet]
        public IActionResult MyPaymentCards()
        {
            var userMail = User.Identity.Name;
            // giriş yapanın maılını al
            // usermaıle ata

            var fullName = context.Users.Where(x => x.eMail == userMail)
               .Select(y => y.fullName)
               .FirstOrDefault();
            ViewData["FullName"] = fullName;

            var imageUrl = context.Users.Where(x => x.eMail == userMail)
                .Select(y => y.imageUrl)
                .FirstOrDefault();
            ViewData["Image"] = imageUrl;

            //giriş yapanının maılını bılıyorusam onun userıdsını ogrenebılıırım
            var id = context.Users.Where(x => x.eMail == userMail)
                    .Select(y => y.userId)
                    //sec neyı sec kullanıcı ıdsını
                    .FirstOrDefault();
            //kullanıcı ıdye ulasmıs olduk artık.

            var list = paymentCardManager.GetAllPaymentCardWithUserId(id);
            return View(list);

        }

        //[HttpPost]
        //public IActionResult EditAdres(User user)
        //{
        //    userManager.Update(user);
        //    return RedirectToAction("Index");
        //}

        //[Authorize]
        //[HttpGet]
        //public IActionResult EditCard()
        //{
        //    var userMail = User.Identity.Name;

        //    var fullName = context.Users.Where(x => x.eMail == userMail)
        //       .Select(y => y.fullName)
        //       .FirstOrDefault();
        //    ViewData["FullName"] = fullName;

        //    var id = context.Users.Where(x => x.eMail == userMail)
        //            .Select(y => y.userId)                  
        //            .FirstOrDefault();

        //    var userid = userManager.GetById(id);           
        //    return View(userid);
        //}

        //[HttpPost]
        //public IActionResult EditCard(User user)
        //{
        //    userManager.Update(user);
        //    return RedirectToAction("Index");
        //}
        //[HttpGet]
        //public IActionResult AddAddress()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddAddress(Adres adres)
        //{
        //    var userMail = User.Identity.Name;
        //    // giriş yapanın maılını al
        //    // usermaıle ata

        //    //giriş yapanının maılını bılıyorusam onun userıdsını ogrenebılıırım
        //    var userid = context.Users.Where(x => x.eMail == userMail)
        //            .Select(y => y.userId)
        //            //sec neyı sec kullanıcı ıdsını
        //            .FirstOrDefault();
        //    adres.userId = userid;
        //    adresManager.Add(adres);
        //    return RedirectToAction("Index");
        //}
    }
}
