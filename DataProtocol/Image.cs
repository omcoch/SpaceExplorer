﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProtocol
{
    public class Image
    {
        string name;
        string description;
        string uri;
        string title;
        public string Name { get => name; set => name = value; }    
        public string Description { get => description; set => description = value; }
        public string Uri { get => uri; set => uri = value; }
        public string Title { get => title; set => title = value; }
    }
}
