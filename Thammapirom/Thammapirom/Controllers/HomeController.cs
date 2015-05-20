using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;
using System.Net.Mail;
using System.Net;


namespace Thammapirom.Controllers
{
    public class HomeController : Controller
    {
        private IWelcomeImageRepository repository;
        private IGalleryImageRepository repository2;
        private IBackgroundRepository repository3;
        private IActivityClipRepository repository4;
        private IDhammaQARepository repository5;
        private IContactRepository repository6;
        private IAnnualEventRepository repository7;
        private ICustomEventRepository repository8;
        public HomeController(IWelcomeImageRepository welcomeImageRepository, IGalleryImageRepository galleryImageRepository, IBackgroundRepository backgroundRepository, IActivityClipRepository activityClipRepository, IDhammaQARepository dhammaQARepository, IContactRepository contactRepository, IAnnualEventRepository annualEventRepository, ICustomEventRepository customEventRepository)
        {
            this.repository = welcomeImageRepository;
            this.repository2 = galleryImageRepository;
            this.repository3 = backgroundRepository;
            this.repository4 = activityClipRepository;
            this.repository5 = dhammaQARepository;
            this.repository6 = contactRepository;
            this.repository7 = annualEventRepository;
            this.repository8 = customEventRepository;
        }

        // Index Controller //
        public ActionResult Index()
        {
            ViewBag.Message = "หน้าแรก";

            return View(repository.WelcomeImages);
        }

        // Background Controller //
        public ActionResult Background()
        {
            ViewBag.Message = "ประวัติวัด";

            return View(repository3.Backgrounds);
        }

        // Event Controller //
        public ActionResult AnnualEvent()
        {
            ViewBag.Message = "ข่าวสาร-กิจกรรม";

            return View(repository7.AnnualEvents);
        }
        public ActionResult AnnualEventDetail(int aEventID)
        {
            AnnualEvent annualEvent = repository7.AnnualEvents.FirstOrDefault(p => p.aEventID == aEventID);

            return View(annualEvent);
        }
        public ActionResult CustomEvent()
        {
            ViewBag.Message = "ข่าวสาร-กิจกรรม";

            return View(repository8.CustomEvents);
        }
        public ActionResult CustomEventDetail(int cEventID)
        {
            CustomEvent customEvent = repository8.CustomEvents.FirstOrDefault(p => p.cEventID == cEventID);

            return View(customEvent);
        }

        // Dhamma Content Controller //
        public ActionResult DhammaContent()
        {
            ViewBag.Message = "สาระธรรม";

            return View();
        }

        // DhammaQA Controller //
        public ActionResult DhammaQA()
        {
            ViewBag.Message = "ถาม-ตอบธรรมะ";

            return View(repository5.DhammaQAs);
        }
        public ViewResult SendDhammaQ()
        {
            return View("SendDhammaQ", new DhammaQA());
        }
        [HttpPost]
        public ActionResult SendDhammaQ(DhammaQA dhammaQA)
        {
            if (ModelState.IsValid)
            {
                repository5.SaveDhammaQA(dhammaQA);            
                return RedirectToAction("DhammaQA");
            }
            else
            {
                // there is something wrong with the data values
                return View(dhammaQA);
            }
        }

        // Gallery Controller //
        public ActionResult Gallery()
        {
            ViewBag.Message = "แกลอรี่";

            return View(repository2.GalleryImages);
        }

        // Activity Clip Controller //
        public ActionResult ActivityClip()
        {
            ViewBag.Message = "วิดีโอกิจกรรม";

            return View(repository4.ActivityClips);
        }

        // Internet TV Controller //
        public ActionResult InternetTV()
        {
            ViewBag.Message = "อินเตอร์เน็ตทีวี";

            return View();
        }

        // Map Controller //
        public ActionResult Map()
        {
            ViewBag.Message = "แผนที่วัด";

            return View();
        }

        // Contact Controller //
        public ActionResult Contact()
        {
            ViewBag.Message = "ติดต่อวัด";

            return View("Contact", new Contact());
        }
        [HttpPost]
        public ActionResult Contact(Contact _objModelMail)
        {
            if (ModelState.IsValid)
            {
                repository6.SaveContact(_objModelMail);
                MailMessage mail = new MailMessage();
                mail.To.Add("se552115005@vr.camt.info");
                mail.From = new MailAddress(_objModelMail.SenderEmail);
                mail.Subject = _objModelMail.ContactTitle;
                string Body = "โปรดติตต่อกลับ: " + _objModelMail.Sender + "\n อีเมลล์: " + _objModelMail.SenderEmail + "\n เรื่อง: " + _objModelMail.ContactMessage;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential("se552115005@vr.camt.info", "552115005");// Enter seders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Contact", _objModelMail);
            }
            else
            {
                return View();
            }
        }
    }
}