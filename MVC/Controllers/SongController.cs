using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SongController : Controller
    {
        // GET: Song
        public ActionResult Index()
        {
            List<SongVM> songsVM = new List<SongVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach(var item in service.GetSongs())
                {
                    songsVM.Add(new SongVM(item));
                }
            }
            return View(songsVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SongVM songVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        SongDTO songDTO = new SongDTO
                        {
                            Id = songVM.Id,
                            SongName = songVM.SongName,
                            SongType = songVM.SongType
                        };
                        service.PostSongs(songDTO);

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
            SongVM songVM = new SongVM();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var songDto = service.GetSongByID(id);
                songVM = new SongVM(songDto);
            }
            return View(songVM);
        }

        [HttpPost]
        public ActionResult Edit(SongVM songVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        //от един формат прехвърляме в друг
                        SongDTO songDTO = new SongDTO
                        {
                            Id = songVM.Id,
                            SongName = songVM.SongName,
                            SongType = songVM.SongType
                        };
                        service.PostSongs(songDTO);
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

        public ActionResult Details(int id)
        {
            SongVM songVM = new SongVM();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var songDto = service.GetSongByID(id);
                songVM = new SongVM(songDto);
            }

            return View(songVM);
        }


        public ActionResult Delete(int id)
        {
            using(SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteSong(id);
            }
            return RedirectToAction("Index");
        }
    }
}