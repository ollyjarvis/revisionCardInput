using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace revisionCardInput
{
    public partial class Form1 : Form
    {

        private Button selectButton;
        private OpenFileDialog openFileDialog1;

        string rootPath = "C:/Users/olly/Desktop/revision/";
        string rootPathBS = @"C:\Users\olly\Desktop\revision\";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select jpg files",
                Filter = "Image files (*.jpg)|*.jpg",
                Title = "Open jpg files"
            };
            selectButton = new Button()
            {
                Size = new Size(100, 20),
                Location = new Point(15, 15),
                Text = "Select file"
            };
            selectButton.Click += new EventHandler(selectButton_Click);
            Controls.Add(selectButton);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    textBox1.Text = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
            if (files != null && files.Any())
            {
                textBox1.Text = files.First(); //select the first one  hi
            }
        }

        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
            if (files != null && files.Any())
            {
                textBox2.Text = files.First(); //select the first one  
            }
        }

        private void textBox2_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qPath = textBox1.Text;
            string aPath = textBox2.Text;

            int amountOfQ = Directory.GetDirectories(rootPathBS + @"q").Length;

            Directory.CreateDirectory(rootPath + "q/" + (amountOfQ + 1).ToString());
            Directory.CreateDirectory(rootPath + "a/" + (amountOfQ + 1).ToString());
            File.Copy(textBox1.Text, rootPath + "q/" + (amountOfQ + 1).ToString() + "/page-1.jpg");
            File.Copy(textBox2.Text, rootPath + "a/" + (amountOfQ + 1).ToString() + "/page-1.jpg");

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
