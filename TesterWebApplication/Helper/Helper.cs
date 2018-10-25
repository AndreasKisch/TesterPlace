﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TesterWebApplication
{
    public class Helper
    {
        public static HttpClient ComicAPI { get; set; }
        public static HttpClient InvAPI { get; set; }


        public static void InitializeClients()
        {
            ComicAPI = new HttpClient();
            ComicAPI.BaseAddress = new Uri("http://localhost:59597");
            ComicAPI.DefaultRequestHeaders.Accept.Clear();
            ComicAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            InvAPI = new HttpClient();
            InvAPI.BaseAddress = new Uri("http://localhost:59597");
            InvAPI.DefaultRequestHeaders.Accept.Clear();

        }

    }

}