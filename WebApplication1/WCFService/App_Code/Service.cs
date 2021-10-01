using System;
using System.Collections.Generic;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Text;

//using Microsoft.EntityFrameworkCore;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени класса "Service" в коде, SVC-файле и файле конфигурации.
public class Service : IService
{
	

	public ReadFile GetDetails(byte[] file)
	{
		ReadFile info = null;

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

        ReadFile fileData = new ReadFile { info = sb.ToString() };
    
        /*if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.info!="")
		{
			return composite;
		}*/
        return info;
	}

}
/*public class ApplicationContext : DbContext
{
	public DbSet<Employee> Employees { get; set; }

	public ApplicationContext()
	{
		Database.EnsureCreated();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=winformappsql;Trusted_Connection=True;");
	}
}
*/