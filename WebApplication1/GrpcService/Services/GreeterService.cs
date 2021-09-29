using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Diagnostics;
using GrpcService;


namespace GrpcService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> Hello (HelloRequest request, ServerCallContext context)
        {
            XSSFWorkbook xssfwb;
              Stream templateStream = new MemoryStream();
           
           
           /* for (int row = 0; row <= sheet.LastRowNum; row++)
            {
                var currentRow = sheet.GetRow(row);
                if (currentRow != null)
                {

                    for (int column = 0; column < 3; column++)
                    {

                        var stringCellValue = currentRow.GetCell(column).StringCellValue;
                        reply = (string.Format("Ячейка {0}-{1} значение:{2}", row, column, stringCellValue));
                    }
                }

            }
            */

            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.File
            });
        }
       
    }
}
