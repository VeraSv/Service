﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class FileModel
    {
        public string FileName { get; set; }
        public FileModel(string name)
        {

            FileName = name;

        }

    }
}
