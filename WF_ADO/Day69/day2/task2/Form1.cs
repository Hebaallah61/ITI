
using System.Configuration;
using System.Data;
using System;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sqlcom1 = new SqlCommand("SelectAllProducts", sqlcon);//Stored procedure
            sqlcom1.CommandType = CommandType.StoredProcedure;
            adpro = new SqlDataAdapter(sqlcom1);
            dtpro = new DataTable();
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
            
            adpro.Fill(dtpro);
            adsup.Fill(dtsup);
            adcat.Fill(dtcat);
            BindingSource bindp=new BindingSource(dtpro,"");
            BindingNavigator bn = new BindingNavigator(bindp);
            this.Controls.Add(bn);
            textBox1.DataBindings.Add("Text", bindp, "ProductName");
            textBox2.DataBindings.Add("Text", bindp, "QuantityPerUnit");
            textBox3.DataBindings.Add("Text", bindp, "UnitPrice");
            textBox4.DataBindings.Add("Text", bindp, "UnitsInStock");
            textBox5.DataBindings.Add("Text", bindp, "UnitsOnOrder");
            textBox6.DataBindings.Add("Text", bindp, "ReorderLevel");
            textBox7.DataBindings.Add("Text", bindp, "Discontinued");
            //checkBox1.DataBindings.Add("Checked", bindp,"Discontinued");
            

            comboBox1.DataSource= dtsup;
            comboBox1.DisplayMember = "CompanyName";
            comboBox1.ValueMember = "Sid";
            comboBox1.DataBindings.Add("SelectedValue", bindp, "SupplierID");

            comboBox2.DataSource = dtcat;
            comboBox2.DisplayMember = "CategoryName";
            comboBox2.ValueMember = "Cid";
            comboBox2.DataBindings.Add("SelectedValue", bindp, "CategoryID");


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in dtpro.Rows)
            {
                Debug.WriteLine(dr.RowState);
            }
            adpro.Update(dtpro);
        }
    }
}