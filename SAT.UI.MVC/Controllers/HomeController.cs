using SAT.UI.MVC.Models;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace SAT.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult About()
        {
            

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            string message = $"You have recived an Imperial message from {cvm.Name} with a subject of {cvm.Subject}." +
                $"Respond to {cvm.EmailAddress}. Message: <br/>{cvm.Message}";

            MailMessage mm = new MailMessage(
                ConfigurationManager.AppSettings["EmailUser"].ToString(),
                ConfigurationManager.AppSettings["EmailTo"].ToString(),
                cvm.Subject,
                message
                );

            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            mm.ReplyToList.Add(cvm.EmailAddress);

            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());

            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailUser"].ToString(), ConfigurationManager.AppSettings["EmailPass"].ToString());

            try
            {
                client.Send(mm);
            }
            catch (Exception Ex)
            {
                ViewBag.CustomerMessage = $"I'm sorry dark one, your request could not be completed. Try again later. Error Message: <br/>{Ex.StackTrace}";
                return View(cvm);
            }


            return View("_EmailConfirmation", cvm);
        }

    }
}
