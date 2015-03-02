using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word; 

namespace WindowsFormsApplication1
{
    class NewWord
    {
        Word._Application oWord = new Word.Application();

        String name;
        MyDataGrid dgv;

        public NewWord(String s,MyDataGrid _dgv)
        {
            name = s;
            dgv = _dgv;
        }

        public void MakeWordDoc(String template)
        {
            Word._Document oDoc = GetDoc(Environment.CurrentDirectory + "\\Template" + template);
            oWord.Visible = true;
            //oDoc.SaveAs(FileName: Environment.CurrentDirectory + "\\New.docx");
            //oDoc.Close(); 
        }

        private Word._Document GetDoc(string path)
        {
            Word._Document oDoc = oWord.Documents.Add(path);
            SetTemplate(oDoc);
            SetTable(oDoc, "TABLE");
            return oDoc;
        }

        private void SetTemplate(Word._Document oDoc)
        {
            oDoc.Bookmarks["TEXT"].Range.Text = name;
            oDoc.Bookmarks["DATE"].Range.Text = DateTime.Now.ToShortDateString();
            oDoc.Bookmarks["TEXT2"].Range.Text = name;
        }

        private void SetTable(Word._Document oDoc, string bookmark)
        {
            Word.Table tbl = oDoc.Bookmarks[bookmark].Range.Tables[1];
            Object oMissing = System.Reflection.Missing.Value;
            
            int rowCount = dgv.table.Rows.Count;
            int collumCount = dgv.table.Columns.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                tbl.Rows.Add(ref oMissing);
                FillRow(tbl, i);

            }
            
            tbl.Rows[tbl.Rows.Count].Delete();

        }

        private void FillRow(Word.Table tbl, int Row)
        {

            for (int j = 0; j < dgv.table.Columns.Count; j++)
            {
                tbl.Cell(Row + 1, j + 1).Range.InsertAfter(Convert.ToString(dgv.dataGrid.Rows[Row - 1].Cells[j].Value) + "\t");
            }

        }

    }
}
