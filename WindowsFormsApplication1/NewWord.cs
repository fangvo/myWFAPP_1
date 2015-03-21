using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word; 

namespace WindowsFormsApplication1
{
    class NewWord
    {
        Word._Application oWord = new Word.Application();

        /// <summary>
        /// Сохранить документ
        /// </summary>
        /// <param name="oDoc"></param>
        /// <param name="id"></param>

        private void SaveDoc(Word.Document oDoc, int id)
        {
            object FileName = String.Format("{0}\\Docs\\Dogovor_{1}.docx", Environment.CurrentDirectory, id);

            Form1.SQLExecuteNonQuery("update SELLS set [Doc] = @file where ID = @id", new Dictionary<string, object> { { "@file", FileName }, { "@id", id } });

            oDoc.SaveAs(ref FileName);
        }

        /// <summary>
        /// начать делать документ
        /// </summary>
        /// <param name="template"></param>
        /// <param name="table"></param>
        /// <param name="dict"></param>

        public void MakeWordDoc(String template, DataTable table, Dictionary<string,object> dict)
        {
            Word.Document oDoc = GetDoc(Environment.CurrentDirectory + "\\Template" + template, table,dict);
            oWord.Visible = true; 
        }

        /// <summary>
        /// начать делать документ
        /// </summary>
        /// <param name="template"></param>
        /// <param name="table"></param>
        /// <param name="dict"></param>

        public void MakeWordDoc(String template, Dictionary<string, object> dict,int num,bool show)
        {
            Word.Document oDoc = GetDoc(Environment.CurrentDirectory + "\\Template" + template, dict);
            SaveDoc(oDoc,num);
            if (show)
            {
                oWord.Visible = true;
            }
            else
            {
                oWord.Quit();
            }
        }

        

        /// <summary>
        /// Взять копию шаблона
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dict"></param>
        /// <returns></returns>

        private Word.Document GetDoc(string path, Dictionary<string, object> dict)
        {
            Word.Document oDoc = oWord.Documents.Add(path);
            SetTemplate(oDoc, dict);
            return oDoc;
        }

        /// <summary>
        /// Взять копию шаблона
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dict"></param>
        /// <returns></returns>

        private Word.Document GetDoc(string path, DataTable table, Dictionary<string, object> dict)
        {
            Word.Document oDoc = oWord.Documents.Add(path);
            SetTemplate(oDoc, dict);
            CreateTable(oDoc, "TABLE", table);
            return oDoc;
        }

        private void SetTemplate(Word.Document oDoc, Dictionary<string, object> dict)
        {
            foreach (KeyValuePair<string, object> item in dict)
            {
                oDoc.Bookmarks[item.Key].Range.Text = item.Value.ToString();
            }
        }

        /*
        private void SetTable(Word._Document oDoc, string bookmark,DataTable table)
        {

            int rowCount = table.Rows.Count;
            int collumCount = table.Columns.Count;

            Word.Table tbl = oDoc.Tables.Add(oDoc.Bookmarks[bookmark].Range, rowCount, collumCount);//.Text;//Tables[1];
            tbl.Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            tbl.Range.Borders[Word.WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            tbl.Range.Borders[Word.WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            tbl.Range.Borders[Word.WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            Object oMissing = System.Reflection.Missing.Value;
            
            

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    tbl.Cell(i, j).Range.InsertAfter(Convert.ToString(table.Rows[i].ItemArray[j].ToString()) + "\t");

                }

            }
            
            tbl.Rows[tbl.Rows.Count].Delete();

        }
        */


        /// <summary>
        /// Сгенерировать таблицу
        /// </summary>
        /// <param name="oDoc"></param>
        /// <param name="bookmark"></param>
        /// <param name="table"></param>
        /// 
        private void CreateTable(Word.Document oDoc, string bookmark, DataTable table)
        {
            Word.Range wdRng = oDoc.Bookmarks[bookmark].Range;
            CreateBasicTable(ref wdRng, table);

            foreach (Word.Table tbl in oDoc.Tables)
            {
                tbl.Range.set_Style(CreateTableStyle(oDoc));
                // If the table ends in an "even band" the border will
                // be missing, so in this case add the border.

                if (System.Data.SqlTypes.SqlInt32.Mod(tbl.Rows.Count, 2) != 0)
                {
                    tbl.Borders[bottomBorder].LineStyle = doubleBorder;
                }
            }
        }

        
        private void CreateBasicTable(ref Word.Range wdRng, DataTable table)
        {
            object objDefaultBehaviorWord8 = Word.WdDefaultTableBehavior.wdWord8TableBehavior;
            object objAutoFitFixed = Word.WdAutoFitBehavior.wdAutoFitFixed;
            int nrRows = table.Rows.Count+1;
            int nrCols = table.Columns.Count;
            Word.Table tbl = wdRng.Tables.Add(wdRng, nrRows, nrCols, ref objDefaultBehaviorWord8, ref objAutoFitFixed);
            PopulateTable(tbl, table);
            //tbl.Columns.AutoFit();
        }
        
        //Populate existing rows
        private void PopulateTable(Word.Table tbl, System.Data.DataTable data)
        {
            // Iterate through the columns to get the headings.
            for (int nrCol = 1; nrCol <= data.Columns.Count; nrCol++)
            {
                tbl.Cell(1, nrCol).Range.Text = data.Columns[nrCol - 1].ColumnName;
            }

            // Iterate through the rows. The first row contains 
            // the column headings, so start with the second row.
            for (int nrRow = 2; nrRow - 1 <= data.Rows.Count; nrRow++)
            {
                // data.Rows is zero-based, so subtract two
                // in order to start with the first record.
                System.Data.DataRow rw = data.Rows[nrRow - 2];
                // Iterate through the columns to get the data.
                for (int nrCol = 1; nrCol <= data.Columns.Count; nrCol++)
                {
                    tbl.Cell(nrRow, nrCol).Range.Text = rw[nrCol - 1].ToString();
                }
            }

        }



        ////////////////////////////////////////////////////////////////////////////////////
        Word.WdBorderType verticalBorder = Word.WdBorderType.wdBorderVertical;
        Word.WdBorderType leftBorder = Word.WdBorderType.wdBorderLeft;
        Word.WdBorderType rightBorder = Word.WdBorderType.wdBorderRight;
        Word.WdBorderType topBorder = Word.WdBorderType.wdBorderTop;
        Word.WdBorderType bottomBorder = Word.WdBorderType.wdBorderBottom;

        Word.WdLineStyle doubleBorder = Word.WdLineStyle.wdLineStyleDouble;
        Word.WdLineStyle singleBorder = Word.WdLineStyle.wdLineStyleSingle;

        Word.WdTextureIndex noTexture = Word.WdTextureIndex.wdTextureNone;
        Word.WdColor gray10 = Word.WdColor.wdColorGray10;
        Word.WdColor gray70 = Word.WdColor.wdColorGray70;
        Word.WdColorIndex white = Word.WdColorIndex.wdWhite;

        private Word.Style CreateTableStyle(Word.Document wdDoc)
        {
            object styleTypeTable = Word.WdStyleType.wdStyleTypeTable;
            Word.Style styl = wdDoc.Styles.Add("My Table Style", ref styleTypeTable);
            styl.Font.Name = "Calibri";
            styl.Font.Size = 11;
            Word.TableStyle stylTbl = styl.Table;
            stylTbl.Borders.Enable = 1;

            Word.ConditionalStyle evenRowBanding = stylTbl.Condition(Word.WdConditionCode.wdEvenRowBanding);
            evenRowBanding.Shading.Texture = noTexture;
            evenRowBanding.Shading.BackgroundPatternColor = gray10;
            // Borders have to be set specifically for every condition.
            evenRowBanding.Borders[leftBorder].LineStyle = singleBorder;
            evenRowBanding.Borders[rightBorder].LineStyle = singleBorder;
            evenRowBanding.Borders[verticalBorder].LineStyle = singleBorder;

            Word.ConditionalStyle firstRow = stylTbl.Condition(Word.WdConditionCode.wdFirstRow);
            firstRow.Shading.BackgroundPatternColor = gray70;
            firstRow.Borders[leftBorder].LineStyle = doubleBorder;
            firstRow.Borders[topBorder].LineStyle = doubleBorder;
            firstRow.Borders[rightBorder].LineStyle = doubleBorder;
            firstRow.Font.Size = 14;
            firstRow.Font.ColorIndex = white;
            firstRow.Font.Bold = 1;

            // Set the number of rows to include in a "band".
            stylTbl.RowStripe = 1;
            return styl;
        }



        public void MakePriceList(Dictionary<String, DataTable> dict,int colsCount)
        {

            object oEndOfDoc = "\\endofdoc";
            object oMissing = System.Reflection.Missing.Value;

            Word.Document oDoc = oWord.Documents.Add(Environment.CurrentDirectory + "\\Template\\PriceList.dotx");
            Word.Range wdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            
            object objDefaultBehaviorWord8 = Word.WdDefaultTableBehavior.wdWord8TableBehavior;
            object objAutoFitFixed = Word.WdAutoFitBehavior.wdAutoFitFixed;
            int tblCurRow = 1;

            Word.Table tbl = oDoc.Tables[1];
            //Word.Table tbl = wdRng.Tables.Add(wdRng, 1, colsCount, ref oMissing, ref oMissing);


            tbl.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            tbl.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            tbl.AllowAutoFit = false;

            foreach (KeyValuePair<String,DataTable> item in dict)
            {
                DataTable data = item.Value;
                int startRow = tblCurRow;
                tbl.Rows.Add();
                tblCurRow++;
                Boolean isNextGray = false;
                
                // Iterate through the rows. The first row contains 
                // the column headings, so start with the second row.
                for (int tblRow = 2; tblRow - 1 <= data.Rows.Count; tblRow++)
                {

                    tbl.Rows.Add();
                    tblCurRow++;

                    tbl.Rows[tblCurRow].SetHeight(20, Word.WdRowHeightRule.wdRowHeightAtLeast);
                    //tbl.Rows[tblCurRow].Shading.BackgroundPatternColor = gray70;
                    tbl.Rows[tblCurRow].Range.Font.Bold = 0;
                    if (isNextGray)
                    {
                        tbl.Rows[tblCurRow].Shading.BackgroundPatternColor = gray10;
                        isNextGray = false;
                    }
                    else 
                    {
                        tbl.Rows[tblCurRow].Shading.BackgroundPatternColor = Word.WdColor.wdColorWhite;
                        isNextGray = true; 
                    }

                    // data.Rows is zero-based, so subtract two
                    // in order to start with the first record.
                    System.Data.DataRow rw = data.Rows[tblRow - 2];
                    // Iterate through the columns to get the data.
                    for (int tblCol = 1; tblCol <= data.Columns.Count; tblCol++)
                    {
                        tbl.Cell(startRow + tblRow, tblCol).Range.Text = rw[tblCol - 1].ToString();  
                    }
                }


                tbl.Cell(startRow + 1, 1).Merge(tbl.Cell(startRow + 1, 6));
                tbl.Cell(startRow + 1, 1).Range.Text = item.Key;

                tbl.Rows[startRow+1].Shading.BackgroundPatternColor = gray70;
                tbl.Rows[startRow+1].Range.Font.Bold = 1;
                tbl.Rows[startRow + 1].Range.Font.ColorIndex = Word.WdColorIndex.wdWhite;
                tbl.Rows[startRow + 1].SetHeight(15, Word.WdRowHeightRule.wdRowHeightAtLeast);



            }

            oWord.Visible = true;

        }


    }
}
