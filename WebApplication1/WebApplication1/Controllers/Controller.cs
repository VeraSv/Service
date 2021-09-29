using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FileController :Controller 
    {
        [HttpPost]
        [Route("api/UploadFile")]
        public void Upload(FileModel file)
        {
          /* string path = Path.GetFullPath(file);

            Program.readFile(path);*/
        }
    }
}
