global using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;
using System.Diagnostics;

namespace task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sqlcom1 = new SqlCommand("select * from [dbo].[Products]", sqlcon);
            adpro=new SqlDataAdapter(sqlcom1);
            dtpro=new DataTable();
            sqlcom2 = new SqlCommand("select CompanyName,SupplierID as Sid from [dbo].[Suppliers]", sqlcon);
            adsup = new SqlDataAdapter(sqlcom2);
            dtsup = new DataTable();
            sqlcom3 = new SqlCommand("select [CategoryName],[CategoryID] as Cid from [dbo].[Categories]", sqlcon);
            adcat = new SqlDataAdapter(sqlcom3);
            dtcat = new DataTable();
            SqlCommandBuilder sqlbuilder = new SqlCommandBuilder(adpro);
            adpro.InsertCommand = sqlbuilder.GetInsertCommand();
            adpro.UpdateCommand = sqlbuilder.GetUpdateCommand();
            adpro.DeleteCommand = sqlbuilder.GetDeleteCommand();
        }

        SqlConnection sqlcon = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True;Encrypt=false");
        SqlCommand sqlcom1;
        SqlCommand sqlcom2;
        SqlCommand sqlcom3;
        SqlDataAdapter adpro;
        SqlDataAdapter adsup;
        SqlDataAdapter adcat;
        DataTable dtpro;
        DataTable dtsup;
        DataTable dtcat;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        BindingSource bindp;

        private void button1_Click(object sender, EventArgs e)
        {
            adpro.Fill(dtpro);
            bindp= new BindingSource(dtpro,"");
            dataGridView1.DataSource= bindp;

            DataGridViewComboBoxColumn DC1 = new DataGridViewComboBoxColumn();
            DC1.HeaderText = "Supplier";

            dataGridView1.Columns.AddRange(DC1);
            adsup.Fill(dtsup);

            DC1.DataSource = dtsup;
            DC1.DisplayMember = "CompanyName";   
            DC1.ValueMember = "Sid";             
            DC1.DataPropertyName = "SupplierID";


            DataGridViewComboBoxColumn DC2 = new DataGridViewComboBoxColumn();
            DC2.HeaderText = "Category";

            dataGridView1.Columns.AddRange(DC2);
            adcat.Fill(dtcat);

            DC2.DataSource = dtcat;
            DC2.DisplayMember = "CategoryName";   
            DC2.ValueMember = "Cid";             
            DC2.DataPropertyName = "CategoryID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            foreach(DataRow dr in dtpro.Rows)
            {
                Debug.WriteLine(dr.RowState);
     
            }
            
            dataGridView1.EndEdit();
            try
            {
                adpro.Update(dtpro);
            }catch(Exception ex)
            {
                MessageBox.Show("Cannot Delete");
            }

        }
    }
}