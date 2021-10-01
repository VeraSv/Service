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
            ReadFile infoFile = new ReadFile();


            StringBuilder sb = new StringBuilder();
            using (MemoryStream stream = new MemoryStream(file))
            {
                stream.Position = 0;
                 //XSSFWorkbook workbook = new XSSFWorkbook(stream);
                IWorkbook workbook = WorkbookFactory.Create(stream);
               var sheet = workbook.GetSheetAt(0);
               string stringCellValue="";
                for (int row = 0; row <= sheet.LastRowNum; row++)
                {
                    var currentRow = sheet.GetRow(row);
                    if (currentRow != null) 
                    {
                        for (int column = 0; column < 3; column++)
                        {
                            stringCellValue = currentRow.GetCell(column).StringCellValue;

                            ResXResourceWriter resx =new ResXResourceWriter("C:\\Resources" + "." +CultureInfo.CurrentCulture.Name + ".resx");
                            resx.AddResource("Title", stringCellValue);
                            
                        }
                    }
                }


                List<ReadFile> list = new List<ReadFile>();
                using (ApplicationContext db = new ApplicationContext())
                {
                    list = db.Resources.ToList();

                }

                }
            
            return "";
        }
        
    }
    public class ApplicationContext : DbContext
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
    }
}
