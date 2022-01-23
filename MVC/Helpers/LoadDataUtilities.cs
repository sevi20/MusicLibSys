﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers
{
    public class LoadDataUtilities
    {
        public static SelectList LoadAuthorData()
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                return new SelectList(service.GetAuthors(), "Id", "Name");
            }
        }

        public static SelectList LoadSongData()
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                return new SelectList(service.GetSongs(), "Id", "SongName");
            }
        }
    }
}