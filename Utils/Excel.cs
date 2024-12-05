using OfficeOpenXml;
using System.IO;
using GTechFlasher.Models;

namespace GTechFlasher.Utils
{
    public class Excel
    {
        private string filePath = "Device.xlsx";

        public Excel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (!File.Exists(filePath))
            {
                CreateExcelFile();
            }
        }

        private void CreateExcelFile()
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Device");
                worksheet.Cells[1, 1].Value = "Serial Number";
                worksheet.Cells[1, 2].Value = "Firmware Version";
                worksheet.Cells[1, 3].Value = "Vbatt";
                worksheet.Cells[1, 4].Value = "Location Fix Time";
                worksheet.Cells[1, 5].Value = "Latitude";
                worksheet.Cells[1, 6].Value = "Longitude";
                worksheet.Cells[1, 7].Value = "Timestamp";

                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }

        public void SaveDataToExcel(Device device)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets["Device"];

                // Check if the worksheet is empty
                if (worksheet.Dimension == null)
                {
                    // Write headers if the file is empty
                    worksheet.Cells[1, 1].Value = "Serial Number";
                    worksheet.Cells[1, 2].Value = "Firmware Version";
                    worksheet.Cells[1, 3].Value = "Vbatt";
                    worksheet.Cells[1, 4].Value = "Location Fix Time";
                    worksheet.Cells[1, 5].Value = "Latitude";
                    worksheet.Cells[1, 6].Value = "Longitude";
                    worksheet.Cells[1, 7].Value = "Timestamp";
                }

                bool isUpdated = false;
                int rows = worksheet.Dimension?.Rows ?? 0;

                // Look for the SerialNumber
                for (int row = 2; row <= rows; row++) // Start at 2 to skip headers
                {
                    if (worksheet.Cells[row, 1].Text == device.SerialNumber)
                    {
                        // Update existing row
                        worksheet.Cells[row, 2].Value = device.FirmwareVersion;
                        worksheet.Cells[row, 3].Value = device.Vbatt;
                        worksheet.Cells[row, 4].Value = device.LocationFixTime;
                        worksheet.Cells[row, 5].Value = device.Latitude;
                        worksheet.Cells[row, 6].Value = device.Longitude;
                        worksheet.Cells[row, 7].Value = device.Timestamp;
                        isUpdated = true;
                        break;
                    }
                }

                if (!isUpdated)
                {
                    // Add a new row if SerialNumber doesn't exist
                    int newRow = rows + 1;
                    worksheet.Cells[newRow, 1].Value = device.SerialNumber;
                    worksheet.Cells[newRow, 2].Value = device.FirmwareVersion;
                    worksheet.Cells[newRow, 3].Value = device.Vbatt;
                    worksheet.Cells[newRow, 4].Value = device.LocationFixTime;
                    worksheet.Cells[newRow, 5].Value = device.Latitude;
                    worksheet.Cells[newRow, 6].Value = device.Longitude;
                    worksheet.Cells[newRow, 7].Value = device.Timestamp;
                }

                package.Save();
            }
        }
    }
}