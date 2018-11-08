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
        public async Task<IActionResult> Index()
        {
            
            string url = "";
            Comic comic;            
            if (false)
            {
                //url = $"{comicNumber}/info.0.json";
            }
            else
            {
                url = $"info.0.json";
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
            ViewData["Img"] = comic.Img;
            ViewData["Num"] = comic.Num;

            return View();

        }
    }
}