using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace GrpcService1
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }
       
      /* public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }*/
        public Task<HelloReply> upload(HelloRequest File, ServerCallContext FileUploadResponse)
        {


            /*  XSSFWorkbook xssfwb;
              Stream templateStream = new MemoryStream();
              string reply = "";
              using (FileStream fstream = new FileStream(request.Name, FileMode.OpenOrCreate))
              {

                  xssfwb = new XSSFWorkbook(fstream);
              }

              ISheet sheet = xssfwb.GetSheetAt(0);
              IRow headerRow = sheet.GetRow(0);
              for (int row = 0; row <= sheet.LastRowNum; row++)
              {
                  var currentRow = sheet.GetRow(row);
                  if (currentRow != null)
                  {
                      for (int column = 0; column < 3; column++)
                      {
                          var stringCellValue = currentRow.GetCell(column).StringCellValue;
                          reply = (string.Format("Cell {0}-{1} value:{2}", row, column, stringCellValue));
                      }
                  }

              }*/
            return Task.FromResult(new HelloReply
            {
               
            });
        }
    }
}
