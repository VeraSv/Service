using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Resources;
using System.Reflection;
using System.Globalization;
using NPOI.OpenXmlFormats.Spreadsheet;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {
        public string GetDetails(byte[] file)
        {
            // ReadFile infoFile = new ReadFile();


            StringBuilder sb = new StringBuilder();
            using (MemoryStream stream = new MemoryStream(file))
            {
                /* Stream st = new MemoryStream(file); 
                 FileStream fs =st as FileStream;
                string name=fs.Name;
                 string path = Path.GetFullPath(name);*/
                stream.Position = 0;

                IWorkbook workbook = WorkbookFactory.Create(stream);
                var sheet = workbook.GetSheetAt(0);
                string stringCellValue = "";
                
                        for (int count = 1; count < sheet.GetRow(0).LastCellNum; count++)
                        {
                            string key = "";
                            string lang = "";
                    string title = "";
                            string value = "";
                            for (int column = 0; column <=count; column += count)
                            {
                        for (int row = 0; row <= sheet.LastRowNum; row++)
                        {
                            var currentRow = sheet.GetRow(row);
                            if (currentRow != null)
                            {
                                if (currentRow.GetCell(column) != null)
                                {
                                    stringCellValue = currentRow.GetCell(column).StringCellValue;
                                    if (String.IsNullOrEmpty(key)) key = stringCellValue;
                                    else if (String.IsNullOrEmpty(title)) title = stringCellValue;
                                   else  if (String.IsNullOrEmpty(lang)) lang = stringCellValue;
                                    else value = stringCellValue;

                                }
                               
                            }
                           
                        }
                       
                    }
                    Resource newResource = new Resource { Key = key, Value = value };
                    newResource.createResource();
                }



            }

            return "Created file";
        }

    }
    /* public class ApplicationContext : DbContext
     {
         public DbSet<ReadFile> Resources { get; set; }

         public ApplicationContext()
         {
             Database.EnsureCreated();
         }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=resourcesql;Trusted_Connection=True;");
         }
     }*/
}
