using Microsoft.EntityFrameworkCore;
using task1.Context;

namespace task1
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) => Context?.Dispose();
        }
         pubsContext Context=new ();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Context.Titles.Load();
            Context.Publishers.Load();
            this.dataGridView1.DataSource =
                Context.Titles.Local.ToBindingList();
            dataGridView1.Columns["Pub"].Visible = false;
            DataGridViewComboBoxColumn DC1 = new DataGridViewComboBoxColumn();
            DC1.HeaderText = "Publisher";

            dataGridView1.Columns.AddRange(DC1);

            DC1.DataSource = Context.Publishers.Local.ToBindingList();
            DC1.DisplayMember = "PubName";
            DC1.ValueMember = "PubId";
            DC1.DataPropertyName = "PubId";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Can not Delete");
            }
        }
    }
}