using Thammapirom.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thammapirom.Models;
using Thammapirom.Concrete;
using System.Data;
using System.Data.Common;
using System.Transactions;
using System.Web.Security;
using System.Windows.Forms;
namespace Thammapirom.Controllers
{
    public class AdminController : Controller
    {
        private IWelcomeImageRepository welcomeImageRepo;
        private IGalleryImageRepository galleryImageRepo;
        private IBackgroundRepository backgroundRepo;
        private IActivityClipRepository activityClipRepo;
        private IDhammaQARepository dhammaQARepo;
        private IAnnualEventRepository annualEventRepo;
        private ICustomEventRepository customEventRepo;
        // Constructor //
        public AdminController(IWelcomeImageRepository repo, IGalleryImageRepository repo2, IBackgroundRepository repo3, IActivityClipRepository repo4, IDhammaQARepository repo5, IAnnualEventRepository repo6, ICustomEventRepository repo8)
        {
            welcomeImageRepo = repo;
            galleryImageRepo = repo2;
            backgroundRepo = repo3;
            activityClipRepo = repo4;
            dhammaQARepo = repo5;
            annualEventRepo = repo6;
            customEventRepo = repo8;
        }
        // Admin Login-Logout Controller //
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminAccount model, string returnUrl)
        {
            if (model.UserName == "admin" && model.Password == "admin1234")
            {
                Session["LoginStatus"] = "True";
                return RedirectToAction("IndexManaging");
            }
            else
            {
                return View();
            }
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Remove("LoginStatus");
            return RedirectToAction("Login");
        }
        public ViewResult Index()
        {
            return View();
        }

        // Index Page Controller //
        public ViewResult IndexManaging()
        {
            return View(welcomeImageRepo.WelcomeImages);
        }
        public ViewResult AddWelcomeImage()
        {
            return View("AddWelcomeImage", new WelcomeImage());
        }
        [HttpPost]
        public ActionResult AddWelcomeImage(WelcomeImage welcomeImage)
        {
            if (ModelState.IsValid)
            {
                welcomeImageRepo.SaveWelcomeImage(welcomeImage);
                //TempData["message"] = string.Format("{0} has been saved", welcomeImage.ImageID);
                return RedirectToAction("IndexManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(welcomeImage);
            }
        }
        [HttpPost]
        public ActionResult DeleteWelcomeImage(int ImageID)
        {
            WelcomeImage deletedWelcomeImage = welcomeImageRepo.DeleteWelcomeImage(ImageID);
            if (deletedWelcomeImage != null)
            {
                TempData["message"] = "Delete success";
            }

            return RedirectToAction("IndexManaging");
        }
        // Background Page Controller //
        public ViewResult BackgroundManaging()
        {
            return View(backgroundRepo.Backgrounds);
        }
        public ViewResult AddBackgroundInfo()
        {

            return View("AddBackgroundInfo", new Background());
        }
        [HttpPost]
        public ActionResult AddBackgroundInfo(Background background)
        {
            if (ModelState.IsValid)
            {
                backgroundRepo.SaveBackgroundInfo(background);
                //TempData["message"] = string.Format("{0} has been saved", background.Name);
                return RedirectToAction("BackgroundManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(background);
            }
        }
        public ViewResult EditBackgroundInfo(int backgroundId)
        {
            Background background = backgroundRepo.Backgrounds.FirstOrDefault(p => p.BackgroundID == backgroundId);
            return View(background);
        }
        [HttpPost]
        public ActionResult EditBackgroundInfo(Background background)
        {
            if (ModelState.IsValid)
            {
                backgroundRepo.SaveBackgroundInfo(background);
                //TempData["message"] = string.Format("{0} has been saved", background.Name);
                return RedirectToAction("BackgroundManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(background);
            }
        }

        // Event Page Controller //
        public ViewResult AnnualEventManaging()
        {
            return View(annualEventRepo.AnnualEvents);
        }
        public ViewResult CustomEventManaging()
        {
            return View(customEventRepo.CustomEvents);
        }
        public ViewResult AddAnnualEvent()
        {
            return View("AddAnnualEvent", new AnnualEvent());
        }
        public ViewResult AddCustomEvent()
        {
            return View("AddCustomEvent", new CustomEvent());
        }
        [HttpPost]
        public ActionResult AddAnnualEvent(AnnualEvent annualEvent)
        {
            if (ModelState.IsValid)
            {
                annualEventRepo.SaveAnnualEvent(annualEvent);
                return RedirectToAction("AnnualEventManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(annualEvent);
            }
        }
        [HttpPost]
        public ActionResult AddCustomEvent(CustomEvent customEvent)
        {
            if (ModelState.IsValid)
            {
                customEventRepo.SaveCustomEvent(customEvent);
                return RedirectToAction("CustomEventManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(customEvent);
            }
        }
        public ViewResult EditAnnualEvent(int aEventID)
        {
            AnnualEvent annualEvent = annualEventRepo.AnnualEvents.FirstOrDefault(p => p.aEventID == aEventID);
            return View(annualEvent);
        }
        public ViewResult EditCustomEvent(int cEventID)
        {
            CustomEvent customEvent = customEventRepo.CustomEvents.FirstOrDefault(p => p.cEventID == cEventID);
            return View(customEvent);
        }
        [HttpPost]
        public ActionResult EditCustomEvent(CustomEvent customEvent)
        {
            if (ModelState.IsValid)
            {
                customEventRepo.SaveCustomEvent(customEvent);
                return RedirectToAction("CustomEventManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(customEvent);
            }
        }
        [HttpPost]
        public ActionResult DeleteAnnualEvent(int aEventID)
        {
            AnnualEvent deletedAnnualEvent = annualEventRepo.DeleteAnnualEvent(aEventID);
            if (deletedAnnualEvent != null)
            {
                TempData["message"] = "Delete success";
            }
            return RedirectToAction("AnnualEventManaging");
        }
        [HttpPost]
        public ActionResult DeleteCustomEvent(int cEventID)
        {
            CustomEvent deletedCustomEvent = customEventRepo.DeleteCustomEvent(cEventID);
            if (deletedCustomEvent != null)
            {
                TempData["message"] = "Delete success";
            }
            return RedirectToAction("CustomEventManaging");
        }

        // Dhamma QA Page Controller //
        public ViewResult DhammaQAManaging()
        {
            return View(dhammaQARepo.DhammaQAs);
        }
        public ViewResult ReplyDhammaQA(int qaID)
        {
            DhammaQA dhammaQA = dhammaQARepo.DhammaQAs.FirstOrDefault(p => p.QAID == qaID);
            return View(dhammaQA);
        }
        [HttpPost]
        public ActionResult ReplyDhammaQuestion(DhammaQA dhammaQA)
        {
            if (ModelState.IsValid)
            {

                dhammaQARepo.SaveDhammaQA(dhammaQA);
                return RedirectToAction("DhammaQAManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(dhammaQA);
            }
        }
        [HttpPost]
        public ActionResult DeleteDhammaQA(int QAID)
        {
            DhammaQA deletedDhammaQA = dhammaQARepo.DeleteDhammaQA(QAID);
            if (deletedDhammaQA != null)
            {
                TempData["message"] = "Delete success";
            }
            return RedirectToAction("DhammaQAManaging");
        }

        // Gallery Page Controller //
        public ViewResult GalleryManaging()
        {
            return View(galleryImageRepo.GalleryImages);
        }
        public ViewResult AddGalleryImage()
        {
            return View("AddGalleryImage", new GalleryImage());
        }
        [HttpPost]
        public ActionResult AddGalleryImage(GalleryImage galleryImage)
        {
            if (ModelState.IsValid)
            {
                galleryImageRepo.SaveGalleryImage(galleryImage);
                //TempData["message"] = string.Format("{0} has been saved", welcomeImage.ImageID);
                return RedirectToAction("GalleryManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(galleryImage);
            }
        }
        [HttpPost]
        public ActionResult DeleteGalleryImage(int ImageID)
        {
            GalleryImage deletedGalleryImage = galleryImageRepo.DeleteGalleryImage(ImageID);
            if (deletedGalleryImage != null)
            {
                TempData["message"] = "Delete success";
            }
            return RedirectToAction("GalleryManaging");
        }

        // Activity Clip Page Controller //
        public ViewResult ActivityClipManaging()
        {
            return View(activityClipRepo.ActivityClips);
        }
        public ViewResult AddActivityClip()
        {
            return View("AddActivityClip", new ActivityClip());
        }
        [HttpPost]
        public ActionResult AddActivityClip(ActivityClip activityClip)
        {
            if (ModelState.IsValid)
            {
                activityClipRepo.SaveActivityClip(activityClip);
                return RedirectToAction("ActivityClipManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(activityClip);
            }
        }
        [HttpPost]
        public ActionResult DeleteActivityClip(int clipID)
        {
            ActivityClip deletedActivityClip = activityClipRepo.DeleteActivityClip(clipID);
            if (deletedActivityClip != null)
            {
                TempData["message"] = "Delete success";
            }
            return RedirectToAction("ActivityClipManaging");
        }
    }
}