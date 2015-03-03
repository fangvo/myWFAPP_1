using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class MyDataGrid
    {
        public DataGridView dataGrid { get; set; }
        public SqlDataAdapter adapter { get; set; }
        public DataTable table { get; set; }
        public DataSet ds { get; set; }
        public String table_name { get; set; }
        //public Button b_save { get; set; }
        //public Button b_new_edit { get; set; }
        //public Button b_delete { get; set; }
    }
}
