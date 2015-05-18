using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thammapirom.Abstract;
using Thammapirom.Models;

namespace Thammapirom.Controllers
{
    public class HomeController : Controller
    {
        private IWelcomeImageRepository repository;
        private IGalleryImageRepository repository2;
        private IBackgroundRepository repository3;
        private IActivityClipRepository repository4;
        private IDhammaQARepository repository5;
        public HomeController(IWelcomeImageRepository welcomeImageRepository, IGalleryImageRepository galleryImageRepository, IBackgroundRepository backgroundRepository, IActivityClipRepository activityClipRepository, IDhammaQARepository dhammaQARepository)
        {
            this.repository = welcomeImageRepository;
            this.repository2 = galleryImageRepository;
            this.repository3 = backgroundRepository;
            this.repository4 = activityClipRepository;
            this.repository5 = dhammaQARepository;
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

        public ActionResult NewsActivities()
        {
            ViewBag.Message = "ข่าวสาร-กิจกรรม";

            return View();
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

            return View();
        }

    }
}
