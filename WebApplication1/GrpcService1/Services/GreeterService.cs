using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Text;


namespace GrpcService1
{
    public class GreeterService
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

       /*  public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
          {
              return Task.FromResult(new HelloReply
              {
                  Message = "Hello " + request.Name
              });
          }*/
        public Task Upload(Byte[] file, ServerCallContext context)
        {
            StringBuilder sb = new StringBuilder();
            Stream stream = new MemoryStream(file);
            XSSFWorkbook hssfwb = new XSSFWorkbook(stream);

            ISheet sheet = hssfwb.GetSheetAt(0);
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            sb.Append("<table class='table table-bordered'><tr>");
            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                sb.Append("<th>" + cell.ToString() + "</th>");
            }
            sb.Append("</tr>");
            sb.AppendLine("<tr>");
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
            {
                IRow row = sheet.GetRow(i);
                if (row == null) continue;
                if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        sb.Append("<td>" + row.GetCell(j).ToString() + "</td>");
                }
            }
            sb.Append("</table>");
            return Task.FromResult(
               sb.ToString()   
        );
            
        }


    }
}
