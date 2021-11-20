using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemoMY.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoMY.Controllers
{
    
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository()); 

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult EditWriterProfile()
        {
            var values = writerManager.TGetById(1);
            return View(values);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult EditWriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writer.WriterStatus = true;
                writerManager.TUpdate(writer);
                return RedirectToAction("Index","Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage writer)
        {
            Writer w = new Writer();
            if (writer.WriterImage != null)
            {
                var extension = Path.GetExtension(writer.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                writer.WriterImage.CopyTo(stream);
                w.WriterImage = newImageName; 
            }
            w.WriterMail = writer.WriterMail;
            w.WriterAbout = writer.WriterAbout;
            w.WriterStatus = true;
            w.WriterPassword = writer.WriterPassword;
            w.WriterStatus = writer.WriterStatus;
            writerManager.TAdd(w);
            return RedirectToAction("Index","Dashboard"); 
        }
    }
}
