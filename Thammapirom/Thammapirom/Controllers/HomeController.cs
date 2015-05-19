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
        private IOtherEventRepository repository8;
        public HomeController(IWelcomeImageRepository welcomeImageRepository, IGalleryImageRepository galleryImageRepository, IBackgroundRepository backgroundRepository, IActivityClipRepository activityClipRepository, IDhammaQARepository dhammaQARepository, IContactRepository contactRepository, IAnnualEventRepository annualEventRepository, IOtherEventRepository otherEventRepository)
        {
            this.repository = welcomeImageRepository;
            this.repository2 = galleryImageRepository;
            this.repository3 = backgroundRepository;
            this.repository4 = activityClipRepository;
            this.repository5 = dhammaQARepository;
            this.repository6 = contactRepository;
            this.repository7 = annualEventRepository;
            this.repository8 = otherEventRepository;
        }
        public FileContentResult GetWelcomeImage(int imageId)
        {
            WelcomeImage welimg = repository.WelcomeImages.FirstOrDefault(p => p.ImageID == imageId);
            if (welimg != null)
            {
                return File(welimg.ImageData, welimg.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public FileContentResult GetGalleryImage(int imageId)
        {
            GalleryImage galimg = repository2.GalleryImages.FirstOrDefault(p => p.ImageID == imageId);
            if (galimg != null)
            {
                return File(galimg.ImageData, galimg.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public ActionResult Index()
        {
            ViewBag.Message = "หน้าแรก";

            return View(repository.WelcomeImages);
        }

        public ActionResult Background()
        {
            ViewBag.Message = "ประวัติวัด";

            return View(repository3.Backgrounds);
        }

        public ActionResult AnnualEvent()
        {
            ViewBag.Message = "ข่าวสาร-กิจกรรม";

            return View(repository7.AnnualEvents);
        }
        public ActionResult AnnualEventDetail(int aEventID)
        {
            AnnualEvent annualEvent = repository7.AnnualEvents.FirstOrDefault(p => p.EventID == aEventID);

            return View(annualEvent);
        }
        
        public ActionResult DhammaContent()
        {
            ViewBag.Message = "สาระธรรม";

            return View();
        }

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
                //TempData["message"] = string.Format("{0} has been saved", background.Name);
                return RedirectToAction("DhammaQA");
            }
            else
            {
                // there is something wrong with the data values
                return View(dhammaQA);
            }
        }
        public ActionResult Gallery()
        {
            ViewBag.Message = "แกลอรี่";

            return View(repository2.GalleryImages);
        }

        public ActionResult ActivityClip()
        {
            ViewBag.Message = "วิดีโอกิจกรรม";

            return View(repository4.ActivityClips);
        }

        public ActionResult InternetTV()
        {
            ViewBag.Message = "อินเตอร์เน็ตทีวี";

            return View();
        }

        public ActionResult Map()
        {
            ViewBag.Message = "แผนที่วัด";

            return View();
        }

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
                string Body = "โปรดติตต่อกลับ: "+_objModelMail.Sender+"\n อีเมลล์: "+_objModelMail.SenderEmail+"\n เรื่อง: "+_objModelMail.ContactMessage;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential("se552115005@vr.camt.info","552115005");// Enter seders User name and password
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
