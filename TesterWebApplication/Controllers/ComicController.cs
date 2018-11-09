using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesterWebApplication.Models;

namespace TesterWebApplication.Controllers
{
    public class ComicController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(int comicNumber)
        {

            string url = "";
            Comic comic;
            int temp = Helper.SessionHelper.Get<int>(HttpContext.Session, "ComicMaxNumber");
            if (comicNumber >= 1 && comicNumber < temp)
            {
                url = $"{comicNumber}/info.0.json";
            }
            else
            {
                url = $"/info.0.json";

            }



            using (HttpResponseMessage res = await APIHelper.ComicAPI.GetAsync(url))
            {
                if (res.IsSuccessStatusCode)
                {
                    comic = await res.Content.ReadAsAsync<Comic>();

                }
                else
                {
                    throw new Exception(res.ReasonPhrase);
                }


            }
            

            if (Helper.SessionHelper.Get<int>(HttpContext.Session, "ComicMaxNumber") == 0)
            {
                Helper.SessionHelper.Set<int>(HttpContext.Session, "ComicMaxNumber", int.Parse(comic.Num));
            }

            return View(comic);

        }
    }
}