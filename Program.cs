using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;


namespace ExcelDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            //  写入Excel文件
           
            HSSFWorkbook workbook2003 = new HSSFWorkbook(); //新建工作簿
            workbook2003.CreateSheet("Sheet2");  //新建1个Sheet工作表            
            HSSFSheet SheetOne = (HSSFSheet)workbook2003.GetSheet("Sheet2"); //获取名称为Sheet1的工作表
            //对工作表先添加行，下标从0开始
            for (int i = 0; i < 10; i++)
            {
                SheetOne.CreateRow(i);   //创建10行
            }
            //对每一行创建10个单元格
            HSSFRow SheetRow = (HSSFRow)SheetOne.GetRow(0);  //获取Sheet1工作表的首行
            HSSFCell[] SheetCell = new HSSFCell[10];
            for (int i = 0; i < 10; i++)
            {
                SheetCell[i] = (HSSFCell)SheetRow.CreateCell(i);  //为第一行创建10个单元格
            }
            //创建之后就可以赋值了
            SheetCell[0].SetCellValue(true); //赋值为bool型         
            SheetCell[1].SetCellValue(0.000001); //赋值为浮点型
            SheetCell[2].SetCellValue("Excel2003"); //赋值为字符串
            SheetCell[3].SetCellValue("123456789987654321");//赋值为长字符串
            for (int i = 4; i < 10; i++)
            {
                SheetCell[i].SetCellValue(i);    //循环赋值为整形
            }
            FileStream file2003 = new FileStream(@"F:\Excel2004.xls", FileMode.Create);
            workbook2003.Write(file2003);
            file2003.Close();
            workbook2003.Close();
            


            //      读取Excel文件
            /*
            IWorkbook workbook = null;  //新建IWorkbook对象
            string fileName = "F:\\Excel2003.xls";
            FileStream fileStream = new FileStream(@"F:\Excel2003.xls", FileMode.Open, FileAccess.Read);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook(fileStream);  //xlsx数据读入workbook
            }
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
            {
                workbook = new HSSFWorkbook(fileStream);  //xls数据读入workbook
            }
            ISheet sheet = workbook.GetSheetAt(0);  //获取第一个工作表
            IRow row;// = sheet.GetRow(0);            //新建当前工作表行数据
            for (int i = 0; i < sheet.LastRowNum; i++)  //对工作表每一行
            {
                row = sheet.GetRow(i);   //row读入第i行数据
                if (row != null)
                {
                    for (int j = 0; j < row.LastCellNum; j++)  //对工作表每一列
                    {
                        string cellValue = row.GetCell(j).ToString(); //获取i行j列数据
                        Console.WriteLine(cellValue);
                    }
                }
            }
            Console.ReadLine();
            fileStream.Close();
            workbook.Close();
            */

        }
    }
}
