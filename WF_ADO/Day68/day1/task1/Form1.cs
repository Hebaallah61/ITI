using System.Windows.Forms;
using System.Text;
namespace task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b2.Click += (sender, e) => this.Close();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure? Y/N", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                {
                    e.Cancel = true;
                }
            }
        }


        private void b1_Click(object sender, EventArgs e)
        {
            
           

            openFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                switch (openFileDialog1.FilterIndex)
                {
                    case 1:
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                        break;
                    case 2:
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        break;
                }


        }

        private void b3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter= "Rich Text Files|*.rtf|Text Files|*.txt";
            saveFileDialog1.InitialDirectory = "D:";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(saveFileDialog1.FileName, (RichTextBoxStreamType)(saveFileDialog1.FilterIndex - 1));
        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText?.Length > 0)
                fontDialog1.Font = richTextBox1.SelectionFont;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void b5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText?.Length > 0)
                colorDialog1.Color = richTextBox1.SelectionColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionColor = colorDialog1.Color;
        }

        Form2 f2 = new();
        private void b6_Click(object sender, EventArgs e)
        {
            f2.ustext = "Type Here";
               if (f2.ShowDialog() == DialogResult.OK)
                   this.richTextBox1.AppendText(f2.ustext.ToUpper());
            
        }
    }
}