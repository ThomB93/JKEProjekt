using JKEMVC.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JKEMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p><b>Email fra:</b> {0} ({1})({2})</p><p><b>Besked:</b> </p><p>{3}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("mvctest@cool.dk"));  // replace with valid value 
                message.From = new MailAddress("mvctest@cool.dk");  // replace with valid value
                message.Subject = "Book et møde";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.FromTlf, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "mvctest@cool.dk",  // replace with valid value
                        Password = "Frants123"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.jubii.dk";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kontakt_information()
        {
            ViewBag.Message = "Kontakt information";

            return View();
        }

        public ActionResult Info_om_os()
        {
            ViewBag.Message = "Info om os";

            return View();
        }
        public ActionResult Send_en_besked()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Links()
        {
            ViewBag.Message = "Your links page";

            return View();
        }
    }
}