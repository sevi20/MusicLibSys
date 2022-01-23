using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            List<AuthorVM> authorsVM = new List<AuthorVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach(var item in service.GetAuthors())
                {
                    authorsVM.Add(new AuthorVM(item));
                }
            }

                return View(authorsVM);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AuthorVM authorVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        //от един формат прехвърляме в друг
                        AuthorDTO authorDTO = new AuthorDTO
                        {
                            Name = authorVM.Name,
                            Age = authorVM.Age,
                            City = authorVM.City
                        };
                        service.PostAuthor(authorDTO);

                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            AuthorVM authorVM = new AuthorVM();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var authorDto = service.GetAuthorByID(id);
                authorVM = new AuthorVM(authorDto);
            }
            return View(authorVM);
        }

        [HttpPost]
        public ActionResult Edit(AuthorVM authorVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        //от един формат прехвърляме в друг
                        AuthorDTO authorDTO = new AuthorDTO
                        {
                            Id = authorVM.Id,
                            Name = authorVM.Name,
                            Age = authorVM.Age,
                            City = authorVM.City
                        };
                        service.PostAuthor(authorDTO);
                    }

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            AuthorVM authorVM = new AuthorVM();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var authorDto = service.GetAuthorByID(id);
                authorVM = new AuthorVM(authorDto);
            }

            return View(authorVM);
        }

        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteAuthor(id);
            }
            return RedirectToAction("Index");
        }
    }
}