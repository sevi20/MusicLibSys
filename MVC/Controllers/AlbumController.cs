using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            List<AlbumVM> albumVMs = new List<AlbumVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetAlbums())
                {
                    albumVMs.Add(new AlbumVM(item));
                }
            }
                return View(albumVMs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Authors = Helpers.LoadDataUtilities.LoadAuthorData();
            ViewBag.Songs = Helpers.LoadDataUtilities.LoadSongData();

            return View();
        }

        [HttpPost]
        public ActionResult Create(AlbumVM albumVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    AlbumDTO albumDTO = new AlbumDTO
                    {
                        Title = albumVM.Title,
                        AuthorId = albumVM.AuthorId,
                        SongId = albumVM.SongId,

                        Author = new AuthorDTO
                        {
                            Id = albumVM.AuthorId
                        },

                        Song = new SongDTO
                        {
                            Id = albumVM.SongId
                        }
                    };
                    service.PostAlbums(albumDTO);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Authors = Helpers.LoadDataUtilities.LoadAuthorData();
                ViewBag.Songs = Helpers.LoadDataUtilities.LoadSongData();
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            AlbumVM albumVM = new AlbumVM();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var albumDto = service.GetAlbumByID(id);
                albumVM = new AlbumVM(albumDto);
            }

            ViewBag.Authors = Helpers.LoadDataUtilities.LoadAuthorData();
            ViewBag.Songs = Helpers.LoadDataUtilities.LoadSongData();

            return View(albumVM);
        }

        [HttpPost]
        public ActionResult Edit(AlbumVM albumVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        //от един формат прехвърляме в друг
                        AlbumDTO albumDTO = new AlbumDTO
                        {
                            Id = albumVM.Id,
                            Title = albumVM.Title,
                            AuthorId = albumVM.AuthorId,
                            SongId = albumVM.SongId,

                            Author = new AuthorDTO
                            {
                                Id = albumVM.AuthorId
                            },

                            Song = new SongDTO
                            {
                                Id = albumVM.SongId
                            }
                        };
                        service.PostAlbums(albumDTO);
                    }

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                ViewBag.Authors = Helpers.LoadDataUtilities.LoadAuthorData();
                ViewBag.Songs = Helpers.LoadDataUtilities.LoadSongData();
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            AlbumVM albumVM = new AlbumVM();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var albumDto = service.GetAlbumByID(id);
                albumVM = new AlbumVM(albumDto);
            }
            return View(albumVM);
        }

        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteAlbum(id);
            }
            return RedirectToAction("Index");
        }
    }
}