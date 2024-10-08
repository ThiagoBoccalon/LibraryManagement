﻿using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.InputModels
{
    public class NewBookInputModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }        
        public string ISBN { get; set; }
    }
}
