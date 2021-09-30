using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using WebApplication1.Models;
using System.Threading.Tasks;
using GrpcService1;
using Grpc.Net.Client;
using System.Net.Http;
namespace WebApplication1.Controllers
{
    public class FileController : Controller
    {

        [HttpPost]
        [Route("api/uploadfile")]
        public async void AddFile(IFormFile myFile)
        {
            if (myFile != null)
            {
                using (var stream = new MemoryStream()) 
                {
                    myFile.CopyTo(stream);
                    var fileButes = stream.ToArray();

                    using var channel = GrpcChannel.ForAddress("https://localhost:5001");

                    var client = new Greeter.GreeterClient(channel);
                    var reply = await GreeterService1.GreeterService.upload(new File { content = fileButes });
                }                
               

            }
        }

    }
}
