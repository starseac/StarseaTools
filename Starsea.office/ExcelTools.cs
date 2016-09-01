using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using StarSea.office;
using System.Collections;
namespace Starsea.office
{
    public class ExcelTools
    {
        /// <summary>
        /// 1、创建文件
        /// </summary>
        /// <param name="filepath"></param>

        private void CreateSpreadsheetWorkbook(string filepath)
        {
            // Create a spreadsheet document by supplying the filepath. 
            // By default, AutoSave = true, Editable = true, and Type = xlsx. 
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook);

            // Add a WorkbookPart to the document. 
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();

            // Add a WorksheetPart to the WorkbookPart. 
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            // Add Sheets to the Workbook. 
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
                AppendChild<Sheets>(new Sheets());

            // Append a new worksheet and associate it with the workbook. 
            Sheet sheet = new Sheet()
            {
                Id = spreadsheetDocument.WorkbookPart.
                    GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = Path.GetFileNameWithoutExtension(filepath)
            };
            sheets.Append(sheet);

            spreadsheetDocument.Close();
        }


        WorkbookPart wbPart = null;
        SpreadsheetDocument document = null;

        public WorkbookPart GetWorkbookPart(string templatePath, string savePath)
        { 
            
           
            CopyFile(templatePath, savePath);
            document = SpreadsheetDocument.Open(savePath, true);
            wbPart = document.WorkbookPart;
            return wbPart;
            
        }
        /// <summary>
        /// 关闭文档
        /// </summary>
        public void close() {
            document.Close();
        
        }

        public string [] getXY(string cellid) {    
            string [] str=new string[2];
          //int y= Convert.ToInt32( cellid.Replace("A","").Replace("B","")..Replace("C","")..Replace("D","").Replace("E","")
          //      .Replace("F","").Replace("G","").Replace("H","").Replace("I","").Replace("J","")
          //      .Replace("K","").Replace("L","").Replace("M","").Replace("N","").Replace("O","")
          //      .Replace("P","").Replace("Q","").Replace("R","").Replace("S","").Replace("T","")
          //      .Replace("U","").Replace("V","").Replace("W","").Replace("X","").Replace("Y","")
          //      .Replace("Z",""));
          string x=cellid.Replace("0","").Replace("1","").Replace("2","").Replace("3","").Replace("4","").Replace("5","")
                .Replace("6","").Replace("7","").Replace("8","").Replace("9","");
            string y=cellid.Replace(x,"");
            str[0]=x;
            str[1]=y;
         return str;       
            
         }

        public string getNewCell_Y_add(string cellid){
            string [] str=getXY(cellid);
            string result="";
            result=str[0]+(Convert.ToInt32(str[1])+1);
            return result;        
        }
        
       

        /// <summary>
        /// 新建一个空的excel
        /// </summary>
        /// <param name="dest"></param>
        /// <returns></returns>
        private bool NewExcelFile(string dest) {
            bool result = false;
            try
            {
                document = SpreadsheetDocument.Create(dest, SpreadsheetDocumentType.Workbook,true);
                WorkbookPart workbookpart = document.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();
                document.Close();
                result = true;
            }catch(Exception eg)
            {
                result = false;
            }
            return result;
        
        }
          
       

        //复制模板
        private string CopyFile(string source, string dest)
        {
            string result = "Copied file";
            try
            {
               
                    // Overwrites existing files
                    File.Copy(source, dest, true);
               
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }


        // Given a Worksheet and an address (like "AZ254"), either return a cell reference, or 
        // create the cell reference and return it.
        private Cell InsertCellInWorksheet(Worksheet ws, string addressName)
        {
            SheetData sheetData = ws.GetFirstChild<SheetData>();
            Cell cell = null;

            UInt32 rowNumber = GetRowIndex(addressName);
            Row row = GetRow(sheetData, rowNumber);

            // If the cell you need already exists, return it.
            // If there is not a cell with the specified column name, insert one.  
            Cell refCell = row.Elements<Cell>().
                Where(c => c.CellReference.Value == addressName).FirstOrDefault();
            if (refCell != null)
            {
                cell = refCell;
            }
            else
            {
                cell = CreateCell(row, addressName);
            }
            return cell;
        }

        private Cell CreateCell(Row row, String address)
        {
            Cell cellResult;
            Cell refCell = null;

            // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
            foreach (Cell cell in row.Elements<Cell>())
            {
                if (string.Compare(cell.CellReference.Value, address, true) > 0)
                {
                    refCell = cell;
                    break;
                }
            }

            cellResult = new Cell();
            cellResult.CellReference = address;

            row.InsertBefore(cellResult, refCell);
            return cellResult;
        }

        private Row GetRow(SheetData wsData, UInt32 rowIndex)
        {
            var row = wsData.Elements<Row>().
            Where(r => r.RowIndex.Value == rowIndex).FirstOrDefault();
            if (row == null)
            {
                row = new Row();
                row.RowIndex = rowIndex;
                wsData.Append(row);
            }
            return row;
        }

        private UInt32 GetRowIndex(string address)
        {
            string rowPart;
            UInt32 l;
            UInt32 result = 0;

            for (int i = 0; i < address.Length; i++)
            {
                if (UInt32.TryParse(address.Substring(i, 1), out l))
                {
                    rowPart = address.Substring(i, address.Length - i);
                    if (UInt32.TryParse(rowPart, out l))
                    {
                        result = l;
                        break;
                    }
                }
            }
            return result;
        }

        public bool UpdateValue(string sheetName, string addressName, string value, UInt32Value styleIndex, bool isString)
        {
            // Assume failure.
            bool updated = false;

            Sheet sheet = wbPart.Workbook.Descendants<Sheet>().Where((s) => s.Name == sheetName).FirstOrDefault();

            if (sheet != null)
            {
                Worksheet ws = ((WorksheetPart)(wbPart.GetPartById(sheet.Id))).Worksheet;
                Cell cell = InsertCellInWorksheet(ws, addressName);

                if (isString)
                {
                    // Either retrieve the index of an existing string,
                    // or insert the string into the shared string table
                    // and get the index of the new item.
                    int stringIndex = InsertSharedStringItem(wbPart, value);

                    cell.CellValue = new CellValue(stringIndex.ToString());
                    cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                }
                else
                {
                    cell.CellValue = new CellValue(value);
                    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                }

                if (styleIndex > 0)
                    cell.StyleIndex = styleIndex;
                
                // Save the worksheet.
                ws.Save();
                updated = true;
            }

            return updated;
        }

        public bool UpdateValueBySheetId(string sheetId, string addressName, string value, UInt32Value styleIndex, bool isString)
        {
            // Assume failure.
            bool updated = false;

            Sheet sheet = wbPart.Workbook.Descendants<Sheet>().Where((s) => s.SheetId == sheetId).FirstOrDefault();

            if (sheet != null)
            {
                Worksheet ws = ((WorksheetPart)(wbPart.GetPartById(sheet.Id))).Worksheet;
                Cell cell = InsertCellInWorksheet(ws, addressName);

                if (isString)
                {
                    // Either retrieve the index of an existing string,
                    // or insert the string into the shared string table
                    // and get the index of the new item.
                    int stringIndex = InsertSharedStringItem(wbPart, value);

                    cell.CellValue = new CellValue(stringIndex.ToString());
                    cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                }
                else
                {
                    cell.CellValue = new CellValue(value);
                    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                }

                if (styleIndex > 0)
                    cell.StyleIndex = styleIndex;

                // Save the worksheet.
                ws.Save();
                updated = true;
            }

            return updated;
        }

        // Given the main workbook part, and a text value, insert the text into the shared
        // string table. Create the table if necessary. If the value already exists, return
        // its index. If it doesn't exist, insert it and return its new index.
        private int InsertSharedStringItem(WorkbookPart wbPart, string value)
        {
            int index = 0;
            bool found = false;
            var stringTablePart = wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();

            // If the shared string table is missing, something's wrong.
            // Just return the index that you found in the cell.
            // Otherwise, look up the correct text in the table.
            if (stringTablePart == null)
            {
                // Create it.
                stringTablePart = wbPart.AddNewPart<SharedStringTablePart>();
            }

            var stringTable = stringTablePart.SharedStringTable;
            if (stringTable == null)
            {
                stringTable = new SharedStringTable();
            }

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in stringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == value)
                {
                    found = true;
                    break;
                }
                index += 1;
            }

            if (!found)
            {
                stringTable.AppendChild(new SharedStringItem(new Text(value)));
                stringTable.Save();
            }

            return index;
        }

        // Used to force a recalc of cells containing formulas. The
        // CellValue has a cached value of the evaluated formula. This
        // will prevent Excel from recalculating the cell even if 
        // calculation is set to automatic.
        private bool RemoveCellValue(string sheetName, string addressName)
        {
            bool returnValue = false;

            Sheet sheet = wbPart.Workbook.Descendants<Sheet>().
                Where(s => s.Name == sheetName).FirstOrDefault();
            if (sheet != null)
            {
                Worksheet ws = ((WorksheetPart)(wbPart.GetPartById(sheet.Id))).Worksheet;
                Cell cell = InsertCellInWorksheet(ws, addressName);

                // If there is a cell value, remove it to force a recalc
                // on this cell.
                if (cell.CellValue != null)
                {
                    cell.CellValue.Remove();
                }

                // Save the worksheet.
                ws.Save();
                returnValue = true;
            }

            return returnValue;
        }

       
     
    }
}
