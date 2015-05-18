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
namespace Thammapirom.Controllers
{
    public class AdminController : Controller
    {
        private IWelcomeImageRepository repository;
        private IGalleryImageRepository repository2;
        private IBackgroundRepository repository3;
        private IActivityClipRepository repository4;
        private IDhammaQARepository repository5;

        public AdminController(IWelcomeImageRepository repo, IGalleryImageRepository repo2, IBackgroundRepository repo3, IActivityClipRepository repo4, IDhammaQARepository repo5)
        {
            repository = repo;
            repository2 = repo2;
            repository3 = repo3;
            repository4 = repo4;
            repository5 = repo5;
        }

        public ViewResult IndexManaging()
        {
            return View(repository.WelcomeImages);
        }

        public ViewResult AddWelcomeImage()
        {
            return View("AddWelcomeImage", new WelcomeImage());
        }
        public ViewResult AddGalleryImage()
        {
            return View("AddGalleryImage", new GalleryImage());
        }

        [HttpPost]
        public ActionResult DeleteWelcomeImage(int ImageID)
        {
            WelcomeImage deletedWelcomeImage = repository.DeleteWelcomeImage(ImageID);
            if (deletedWelcomeImage != null)
            {


                TempData["message"] = "Delete success";
            }



            return RedirectToAction("IndexManaging");
        }
        /*
        public ActionResult Index()
        {
            using (EFDbContext contextObj = new EFDbContext())
            {
                var getAllImage = contextObj.GalleryImages.ToList();
                return View(getAllImage);
            }

        }*/
        public ViewResult GalleryManaging()
        {
            return View(repository2.GalleryImages);
        }
        public ViewResult EditBackgroundInfo(int backgroundId)
        {
            Background background = repository3.Backgrounds.FirstOrDefault(p => p.BackgroundID == backgroundId);
            return View(background);
        }
        public ViewResult BackgroundManaging()
        {
            return View(repository3.Backgrounds);
        }
        public ViewResult AddActivityClip()
        {

            return View("AddActivityClip", new ActivityClip());
        }

        public ViewResult ReplyDhammaQA(int qaID)
        {
            DhammaQA dhammaQA = repository5.DhammaQAs.FirstOrDefault(p => p.QAID == qaID);
            return View(dhammaQA);
        }
        public ViewResult ActivityClipManaging()
        {
            return View(repository4.ActivityClips);
        }
        public ViewResult DhammaQAManaging()
        {
            return View(repository5.DhammaQAs);
        }
        /*[HttpPost]
        public ActionResult DeleteImage(int ImageID)
        {
            
            using (EFDbContext context = new EFDbContext())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        
                        GalleryImage deletedImage = context.GalleryImages.Find(ImageID);
                        if (deletedImage != null)
                        {

                            context.GalleryImages.Remove(deletedImage);
                            context.SaveChanges();
                            TempData["message"] = "Delete success";

                            string filePath = Server.MapPath((deletedImage.ImagePath));
                            if (System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(filePath);

                            }
                        }
                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
            return RedirectToAction("Index");
        }
        */
        [HttpPost]
        public ActionResult DeleteGalleryImage(int ImageID)
        {
            GalleryImage deletedGalleryImage = repository2.DeleteGalleryImage(ImageID);
            if (deletedGalleryImage != null)
            {
                TempData["message"] = "Delete success";
            }
            return RedirectToAction("GalleryManaging");
        }
        [HttpPost]
        public ActionResult DeleteActivityClip(int clipID)
        {
            ActivityClip deletedActivityClip = repository4.DeleteActivityClip(clipID);
            if (deletedActivityClip != null)
            {
                TempData["message"] = "Delete success";
            }
            return RedirectToAction("ActivityClipManaging");
        }
        [HttpPost]
        public ActionResult DeleteDhammaQA(int QAID)
        {
            DhammaQA deletedDhammaQA = repository5.DeleteDhammaQA(QAID);
            if (deletedDhammaQA != null)
            {
                TempData["message"] = "Delete success";
            }
            return RedirectToAction("DhammaQAManaging");
        }
        /*
        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }
         * /
        /*[HttpPost]
        public ActionResult AddImage(HttpPostedFileBase ImagePath)
        {
            if (ImagePath != null)
            {
                string pic = System.IO.Path.GetFileName(ImagePath.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/images"), pic);
                ImagePath.SaveAs(path);
                using (EFDbContext myContext = new EFDbContext())
                {
                    GalleryImage galleryobj = new GalleryImage
                    {
                        ImagePath = "~/Content/images/" + pic
                    };
                    myContext.GalleryImages.Add(galleryobj);
                    myContext.SaveChanges();

                }

            }

            return RedirectToAction("Index", "Admin");
        }
         */
        [HttpPost]
        public ActionResult IndexManaging(WelcomeImage welcomeImage, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    welcomeImage.ImageMimeType = image.ContentType;
                    welcomeImage.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(welcomeImage.ImageData, 0, image.ContentLength);
                }
                repository.SaveWelcomeImage(welcomeImage);
                TempData["message"] = string.Format("{0} has been saved", welcomeImage.ImageID);
                return RedirectToAction("IndexManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(welcomeImage);
            }
        }
        [HttpPost]
        public ActionResult GalleryManaging(GalleryImage galleryImage, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    galleryImage.ImageMimeType = image.ContentType;
                    galleryImage.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(galleryImage.ImageData, 0, image.ContentLength);
                }
                repository2.SaveGalleryImage(galleryImage);
                TempData["message"] = string.Format("{0} has been saved", galleryImage.ImageID);
                return RedirectToAction("GalleryManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(galleryImage);
            }
        }
        [HttpPost]
        public ActionResult EditBackground(Background background)
        {
            if (ModelState.IsValid)
            {
                repository3.SaveBackgroundInfo(background);
                //TempData["message"] = string.Format("{0} has been saved", background.Name);
                return RedirectToAction("BackgroundManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(background);
            }
        }
        [HttpPost]
        public ActionResult AddActivityClip(ActivityClip activityClip)
        {
            if (ModelState.IsValid)
            {
                repository4.SaveActivityClip(activityClip);
                //TempData["message"] = string.Format("{0} has been saved", background.Name);
                return RedirectToAction("ActivityClipManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(activityClip);
            }
        }
        [HttpPost]
        public ActionResult ReplyDhammaQuestion(DhammaQA dhammaQA)
        {
            if (ModelState.IsValid)
            {

                repository5.SaveDhammaQA(dhammaQA);
                //TempData["message"] = string.Format("{0} has been saved", background.Name);
                return RedirectToAction("DhammaQAManaging");
            }
            else
            {
                // there is something wrong with the data values
                return View(dhammaQA);
            }
        }
    }
}