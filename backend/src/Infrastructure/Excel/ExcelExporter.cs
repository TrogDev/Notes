namespace Notes.Infrastructure.Excel;

using OfficeOpenXml;

using Notes.Application.DTO;
using Notes.Application.Common.Interfaces;
using Notes.Infrastructure.Excel.Enums;

public class ExcelExporter : IExporter
{
    public byte[] Export(List<NoteDTO> notes)
    {
        using var package = new ExcelPackage();

        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Notes");

        worksheet.Cells[1, (int)ColumnNumber.Id].Value = "#";
        worksheet.Cells[1, (int)ColumnNumber.Title].Value = "Заголовок";
        worksheet.Cells[1, (int)ColumnNumber.Description].Value = "Описание";

        for (int i = 0; i < notes.Count; i++)
        {
            int rowNumber = i + 2;
            worksheet.Cells[rowNumber, (int)ColumnNumber.Id].Value = notes[i].Id;
            worksheet.Cells[rowNumber, (int)ColumnNumber.Title].Value = notes[i].Title;
            worksheet.Cells[rowNumber, (int)ColumnNumber.Description].Value = notes[i].Description;
        }

        return package.GetAsByteArray();
    }
}
