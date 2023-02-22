using BusinessLogicLayer.EntityList;
using BusinessLogicLayer.EntityManager;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TitleList tl1;
        PublisherList pl1;
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        BindingSource bint;//-------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            tl1=TitleManager.SelectAllTitles();
            bint=new BindingSource(tl1,"");//responsibilty -----
            dataGridView1.DataSource = bint;//tl1;

            pl1 = PuplisherManager.SelectAllPublishers();
            //dataGridView1.DataSource = pl1;

            DataGridViewComboBoxColumn DC1 = new DataGridViewComboBoxColumn();
            DC1.HeaderText = "Publisher";

            dataGridView1.Columns.AddRange(DC1);

            DC1.DataSource = new BindingSource(pl1,"");
            //DC1.DataSource = pl1;
            DC1.DisplayMember = "pub_name";
            DC1.ValueMember = "pub_id";
            DC1.DataPropertyName = "pub_id";



            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            decimal price=0,advance=0;
            int royality = 0,ytdasles=0;
            DateTime date=new();
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            string titleid = selectedRow.Cells["title_id"].Value.ToString();
            string title = selectedRow.Cells["title"].Value.ToString();
            string pubid = selectedRow.Cells["pub_id"].Value.ToString();
            string type = selectedRow.Cells["type"].Value.ToString();
            if( decimal.TryParse(selectedRow.Cells["price"].Value?.ToString() ?? "-1", out decimal tempint1)) 
               price = tempint1;
            if (decimal.TryParse(selectedRow.Cells["advance"].Value?.ToString() ?? "-1", out  tempint1))
                advance = tempint1;
            if (int.TryParse(selectedRow.Cells["royalty"].Value?.ToString() ?? "-1", out int tempint2))
                royality = tempint2;
            if (int.TryParse(selectedRow.Cells["ytd_sales"].Value?.ToString() ?? "-1", out  tempint2))
                ytdasles = tempint2;
            string notes = selectedRow.Cells["notes"].Value.ToString();
            if (DateTime.TryParse(selectedRow.Cells["pubdate"].Value?.ToString() ?? "-1", out DateTime tempint))
                date = tempint;
            // string cellValue = dataGridView1.Rows[2].Cells[1].Value.ToString();

           var status1= TitleManager.UpdateTitle(titleid, title,type, pubid, price, advance, royality, ytdasles, notes, date);
            this.Text = $"{status1}++";

           


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string titleidin = row.Cells["title_id"].Value?.ToString()??"NA";
                string titlein = row.Cells["title"].Value?.ToString() ?? "NA";
                string typein = row.Cells["type"].Value?.ToString() ?? "NA";
                string pub_idin = row.Cells["pub_id"].Value?.ToString() ?? "NA";
                string notesin = row.Cells["notes"].Value?.ToString() ?? "NA";
                decimal pricein = Convert.ToDecimal(row.Cells["price"].Value);
                decimal advancein = Convert.ToDecimal(row.Cells["advance"].Value);
                int royalty = Convert.ToInt32(row.Cells["royalty"].Value);
                int  ytdaslesin = Convert.ToInt32(row.Cells["ytd_sales"].Value);
                DateTime datein = Convert.ToDateTime(row.Cells["pubdate"].Value);

                var status2 = TitleManager.spInsertTitle(titleidin, titlein, typein, pub_idin, pricein, advancein, royalty, ytdaslesin, notesin, datein);
                this.Text = $"{status2}--";
            
            }

            foreach (var item in tl1)
            {
                Trace.WriteLine(item.State);
            }


        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var state3 = TitleManager.DeleteTitle(row.Cells["title_id"].Value?.ToString() ?? "NA");
                    this.Text = $"{state3}//";
                }
            }
        }


        //private void dataGridView1_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    e.Cancel = true;
        //}
        

    }
}