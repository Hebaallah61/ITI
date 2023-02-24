using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using task2.Context;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) => Context?.Dispose();

        }
        pubsContext Context = new();
        BindingSource bsource;

        private void Form1_Load(object sender, EventArgs e)
        {
            Context.Titles.Load();
            bsource=new BindingSource(Context.Titles.Local.ToBindingList(),"");
            BindingNavigator bn = new BindingNavigator(bsource);
            
            Context.Publishers.Load();
            
           
            

            this.Controls.Add(bn);
            textBox1.DataBindings.Add("Text", bsource, "TitleId");
            textBox2.DataBindings.Add("Text", bsource, "Title1");
            textBox3.DataBindings.Add("Text", bsource, "Type");
            textBox4.DataBindings.Add("Text", bsource, "PubId");
            numericUpDown1.DataBindings.Add("Value", bsource, "Price", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown2.DataBindings.Add("Value", bsource, "Advance", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown3.DataBindings.Add("Value", bsource, "Royalty", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown4.DataBindings.Add("Value", bsource, "YtdSales", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox5.DataBindings.Add("Text", bsource, "Notes");
            textBox6.DataBindings.Add("Text", bsource, "Pubdate");

            comboBox1.DataSource = Context.Publishers.Local.ToBindingList();
            comboBox1.DisplayMember = "PubName";
            comboBox1.ValueMember = "PubId";
            comboBox1.DataBindings.Add("SelectedValue", bsource, "PubId");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Invalid action according to validation of DB");
            }
        }
    }
}