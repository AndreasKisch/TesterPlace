using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TesterWebApplication
{

    /// <summary>
    /// Helps to hold Address to API used in controllers
    /// 
    /// </summary>
    public class APIHelper
    {
        public static HttpClient ComicAPI { get; set; }
        public static HttpClient InvAPI { get; set; }
        public static HttpClient BookAPI { get; set; }

       

        public static void InitializeClients()
        {
            ComicAPI = new HttpClient();
            ComicAPI.BaseAddress = new Uri("https://xkcd.com/");
            ComicAPI.DefaultRequestHeaders.Accept.Clear();
            ComicAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            InvAPI = new HttpClient();
            InvAPI.BaseAddress = new Uri("http://localhost:59597");
            InvAPI.DefaultRequestHeaders.Accept.Clear();
            InvAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            BookAPI = new HttpClient();
            BookAPI.BaseAddress = new Uri("http://localhost:53658");
            BookAPI.DefaultRequestHeaders.Accept.Clear();
            BookAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        

    }

}
