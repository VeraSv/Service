using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using WebApplication1.Models;
using System.Threading.Tasks;
using Grpc.Net.Client;
using System.Net.Http;
namespace WebApplication1.Controllers
{
    [Route("api/uploadfile")]
    public class FileController : Controller
    {

        [HttpPost]
        public void AddFile(FileModel newFile)
        {
            if (newFile != null)
            {
              // string path = Path.GetFullPath(newFile.Name);
               /* using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    var stream = new MemoryStream();
                    fileStream.CopyTo(stream);
                    var fileButes = stream.ToArray();
                }

                    /*  Task<string>  responce;
         if (myFile != null)
         {
             using (var stream = new MemoryStream()) 
             {
                 myFile.CopyTo(stream);
                 var fileButes = stream.ToArray();



                 ServiceReference3.Service1Client UploadFile = new ServiceReference3.Service1Client();
                responce=  UploadFile.GetDetailsAsync(fileButes);

             }                


         }*/
                    //  return null;
                }
        }

        }
}
