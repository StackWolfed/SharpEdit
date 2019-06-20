using System;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace SharpEdit
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFile = new OpenFileDialog();
        private String filePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("You clicked Open!");
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Console.WriteLine(openFile.FileName);
                    filePath = openFile.FileName;
                    text.Enabled = true;
                    var sr = new StreamReader(openFile.FileName);
                    text.Text = sr.ReadToEnd();
                    sr.Close();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("You clicked Save!");
            File.WriteAllText(filePath, text.Text);
        }
    }
}
