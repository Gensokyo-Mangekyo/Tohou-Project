using Microsoft.AspNetCore.Mvc;
using System;
using Tohou_Project.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tohou_Project.Models;

namespace Tohou_Project.Controllers
{
    public class HomeController : Controller
    {
        public InfoMangaContext info;

        public IActionResult Index()
        {
            
            return View(info.infoManga.ToArray());
        }
        public HomeController(InfoMangaContext infoManga)
        {
            info = infoManga;
        }

        [Route("manga/{id:int}")]
        [HttpGet]
        public IActionResult manga(byte id)
        {
           var path = HttpContext.RequestServices.GetService(typeof(PathRepository)) as PathRepository;
            var info = this.info.infoManga.FirstOrDefault(x => x.id == id);
            ViewData["Title"] = info.Name;
            PageRepository.key = info.Name;
            PageRepository.id = id;
            bool showlink = false;
            var GetChapter = this.info.alreadyRedPages.Where(x => x.InfoMangaGetId == id);
            int lastchapter = 0;
            if (!GetChapter.All(x => x.AlreadyPageRed == false))
            {
                showlink = true;
                try
                {
                    lastchapter = int.Parse(GetChapter.Where(x => x.AlreadyPageRed == false).First().chapter.GetNumberStr());
                }
                catch(Exception ex)
                {
                    lastchapter = -1;
                }

            }
            var result = new PathAndInfoTitle() { chapters = path.chapters, InfoManga = info, BeginReading = showlink, NotReadChapter = lastchapter };
            return View(result);
        }
        [NonAction]
        public Page GetPage(int chapter)
        {
            var path = HttpContext.RequestServices.GetService(typeof(PathRepository)) as PathRepository;
            var list = new SortedList<SortChapterAndPage, string>();
            if (path.directories.TryGetValue(PageRepository.key, out list))
            {
                var stringlist = list.Values;
                var b = stringlist.Where(x => x.Contains($"Chapter {chapter}")).Where(x => {
                    string[] strings = x.Split('\\');
                    return $"Chapter {chapter}" == strings[strings.Length - 2];
                }
                ).Select(x => x.Substring(x.IndexOf("wwwroot") + 8));

                var model = new Page { pages = b, chapter = chapter };
                return model;
            }
            throw new Exception();
        }

        [HttpPost]
        [Route("manga/{id:int}")]
        public IActionResult manga(int chapter,int LastReadChapter)
        {
            if (LastReadChapter != 0)
                PageRepository.chapter = LastReadChapter-1;
            else
            PageRepository.chapter = chapter;
            return RedirectPermanent("~/Home/Read"); //Обратился к сеньёру за помощью сам эту тему пропустил
        }
        [HttpGet]
        public IActionResult Read()
        {
            ViewData["Title"] = PageRepository.key;
            var arr = info.alreadyRedPages.ToArray().Where(x => x.InfoMangaGetId == PageRepository.id).ToArray();
            int GetId = arr.Where(x => int.Parse(x.chapter.GetNumberStr()) == PageRepository.chapter+1).FirstOrDefault().id;
            var data = info.alreadyRedPages.Find(GetId);
            data.AlreadyPageRed = true;
            info.SaveChanges();
            return View(GetPage(PageRepository.chapter));
        }
        [HttpPost]
        public IActionResult Read(string str)
        {
            ViewData["Title"] = PageRepository.key;
            var path = HttpContext.RequestServices.GetService(typeof(PathRepository)) as PathRepository;
            var sortlist = new SortedList<int, string>();
            if (str != null) //Переход на следующую главу
            {
                if (path.chapters.TryGetValue(PageRepository.key, out sortlist))
                {
                    if (PageRepository.chapter + 1 <= sortlist.Count-1)
                        PageRepository.chapter += 1;
                }
                
            }
            else
            {
                if (path.chapters.TryGetValue(PageRepository.key, out sortlist))
                {
                    if (PageRepository.chapter - 1 >= 0)
                        PageRepository.chapter -= 1;
                }
            }

            return View(GetPage(PageRepository.chapter));
        }
    }
}
