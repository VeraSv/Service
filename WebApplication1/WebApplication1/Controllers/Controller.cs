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
        public void AddFile(IFormFile newFile)
        {

            if (newFile != null)
            {
              string path = Path.GetFullPath(newFile.Name);
               /* using ()
                {
                    // newFile.CopyTo(stream);
                    //var fileBytes = stream.ToArray();


                    //ServiceReference3.Service1Client UploadFile = new ServiceReference3.Service1Client();
                    //var responce = UploadFile.GetDetailsAsync(fileBytes);

                }*/
            }
        }


        [HttpGet]
        public string ReadFile()
        {

            return ("Upload");
        }

        }
}
