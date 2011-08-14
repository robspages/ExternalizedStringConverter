using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ExcelToSQL;
using ExternalizedStringConverter;

namespace ESCUI
{
    public class ExcelToXLIFF
    {
        private ExcelFile excel;
        private XLIFFBuilder xBuilder;
        private String outputPath = String.Empty;

        public ExcelToXLIFF(String excelPath, String ouputPath)
        {
            try
            {
                excel = new ExcelFile(excelPath);
                xBuilder = new XLIFFBuilder("en-US", "en-GB");
                this.outputPath = ouputPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public String cDataCheck(String input)
        {
            if (input.Contains("&") || input.Contains(">") || input.Contains("<"))
            {
                input = "<![CDATA[" + input + "]]>";
            }
            return input;
        }


        public void DoWork(String sheetName)
        {
            ExcelSheet sheet = excel.findSheetByName(sheetName);
            foreach (DataRow row in sheet.Rows)
            {
                XLIFFUnit source = new XLIFFUnit(row["source-language"].ToString(), cDataCheck(row["ns1:source"].ToString()));
                XLIFFUnit target = new XLIFFUnit(row["target-language"].ToString(), cDataCheck(row["en-UK"].ToString()));
                XLIFFNode node = new XLIFFNode(row["id"].ToString(), true, source, target);
                xBuilder.nodes.Add(node);
            }

            xBuilder.toFile(outputPath);
        }

    }
}
