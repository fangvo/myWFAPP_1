using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class GoodsAddForm : Form
    {
        public GoodsAddForm()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBoxTName.Text;
            decimal cena;

            if (!decimal.TryParse(textBoxCena.Text, out cena))
            {
                MessageBox.Show("Введие цифры", "Error", MessageBoxButtons.OK);
                return;
            }
            Int64 kolvo;
            if (!Int64.TryParse(textBoxKolvo.Text, out kolvo))
            {
                MessageBox.Show("Введие цифры", "Error", MessageBoxButtons.OK);
                return;
            }
            Int64 articyl;
            if (!Int64.TryParse(textBoxTArticyl.Text, out articyl))
            {
                MessageBox.Show("Введие цифры", "Error", MessageBoxButtons.OK);
                return;
            }
            Int64 cod ;
            if (!Int64.TryParse(textBoxStrihCod.Text, out cod))
            {
                MessageBox.Show("Введие цифры", "Error", MessageBoxButtons.OK);
                return;
            }
            String ed = textBoxED.Text;
            Form1.SQLExecuteNonQuery(String.Format("INSERT INTO Goods VALUES ( @name,@cena,@kolvo,@articyl,@cod,@ed,'2000-01-01' );"),
                new Dictionary<string, object> {
                { "@name", name },
                { "@cena", cena },
                { "@kolvo", kolvo },
                { "@articyl", articyl }, 
                { "@cod", cod }, 
                { "@ed", ed }});
            this.Close();
        }
    }
}
