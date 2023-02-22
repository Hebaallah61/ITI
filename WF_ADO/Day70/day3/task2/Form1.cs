using BusinessLogicLayer.Entity;
using BusinessLogicLayer.EntityList;
using BusinessLogicLayer.EntityManager;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        TitleList tl1;
        PublisherList pl1;
        BindingSource bindp;
        private void Form1_Load(object sender, EventArgs e)
        {

            tl1 = TitleManager.SelectAllTitles();
            bindp = new BindingSource(tl1, "");

            BindingNavigator bn = new BindingNavigator(bindp);


            this.Controls.Add(bn);
            textBox1.DataBindings.Add("Text", bindp, "title_id");
            textBox2.DataBindings.Add("Text", bindp, "title");
            textBox3.DataBindings.Add("Text", bindp, "type");
            textBox4.DataBindings.Add("Text", bindp, "pub_id");
            numericUpDown1.DataBindings.Add("Value", bindp, "price", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown2.DataBindings.Add("Value", bindp, "advance", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown3.DataBindings.Add("Value", bindp, "royalty", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown4.DataBindings.Add("Value", bindp, "ytd_sales", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox9.DataBindings.Add("Text", bindp, "notes");
            textBox10.DataBindings.Add("Text", bindp, "pubdate");
            
            pl1 = PuplisherManager.SelectAllPublishers();
            comboBox1.DataSource = pl1;
            comboBox1.DisplayMember = "pub_name";
            comboBox1.ValueMember = "pub_id";
            comboBox1.DataBindings.Add("SelectedValue", bindp, "pub_id");

            bindp.AddingNew += (sender, e) => e.NewObject = new Titile() { State = EntityState.Add };
            //--

            
            
         


        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            decimal price =0, advance = 0;
            int royality = 0, ytdasles = 0;
            DateTime date = new();

            
            string titleid = textBox1.Text.Trim(); 
            string title = textBox2.Text.Trim(); 
            string pubid = textBox4.Text.Trim();  
            string type = textBox3.Text.Trim(); 
            if (decimal.TryParse(numericUpDown1.Text.Trim()?.ToString() ?? "-1", out decimal tempint1))
                price = tempint1;
            if (decimal.TryParse(numericUpDown2.Text.Trim()?.ToString() ?? "-1", out tempint1))
                advance = tempint1;
            if (int.TryParse(numericUpDown3.Text.Trim()?.ToString() ?? "-1", out int tempint2))
                royality = tempint2;
            if (int.TryParse(numericUpDown4.Text.Trim()?.ToString() ?? "-1", out tempint2))
                ytdasles = tempint2;
            string notes = textBox9.Text.Trim();
            if (DateTime.TryParse(textBox10.Text.Trim()?.ToString() ?? "-1", out DateTime tempint))
                date = tempint;
          

            var status1 = TitleManager.UpdateTitle(titleid, title, type, pubid, price, advance, royality, ytdasles, notes, date);
            this.Text = $"{status1}++";

            foreach (var item in tl1)
            {
                Trace.WriteLine(item.State);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.No)
            {
                var state3 = TitleManager.DeleteTitle(textBox1.Text?.ToString() ?? "NA");
                this.Text = $"{state3}//";
            }
            else
            {
                
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            string titleidin = textBox1.Text;
            string titlein = textBox2.Text;
            string typein = textBox3.Text;
            string pub_idin = textBox4.Text;
            string notesin = textBox9.Text;

            decimal? pricein = null;
            decimal? advancein = null;
            int? royalty = null;
            int? ytdaslesin = null;

            if (!string.IsNullOrEmpty(numericUpDown1.Text) && decimal.TryParse(numericUpDown1.Text, out decimal tempint1))
            {
                pricein = tempint1;
            }

            if (!string.IsNullOrEmpty(numericUpDown2.Text) && decimal.TryParse(numericUpDown2.Text, out tempint1))
            {
                advancein = tempint1;
            }

            if (!string.IsNullOrEmpty(numericUpDown3.Text) && int.TryParse(numericUpDown3.Text, out int tempint2))
            {
                royalty = tempint2;
            }

            if (!string.IsNullOrEmpty(numericUpDown4.Text) && int.TryParse(numericUpDown4.Text, out tempint2))
            {
                ytdaslesin = tempint2;
            }

            DateTime datein = new DateTime(2020, 5, 5);
            if (!string.IsNullOrEmpty(textBox10.Text) && DateTime.TryParse(textBox10.Text, out DateTime tempdate))
            {
                datein = tempdate;
            }

            var status2 = TitleManager.spInsertTitle(titleidin, titlein, typein, pub_idin, pricein, advancein, royalty, ytdaslesin, notesin, datein);
            this.Text = $"{status2}--";
        }
    }
}