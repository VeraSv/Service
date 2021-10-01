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
    public class FileController : Controller
    {

        [HttpPost]
        [Route("api/uploadfile")]
        public Task<string> AddFile(IFormFile myFile)
        {
            Task<string>  responce;
            if (myFile != null)
            {
                using (var stream = new MemoryStream()) 
                {
                    myFile.CopyTo(stream);
                    var fileButes = stream.ToArray();

      

                    ServiceReference3.Service1Client UploadFile = new ServiceReference3.Service1Client();
                   responce=  UploadFile.GetDetailsAsync(fileButes);

                }                
               

            }
            return null;
        }

    }
}
