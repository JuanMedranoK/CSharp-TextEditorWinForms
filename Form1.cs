namespace CSharp_TextEditorWinForms
{
    public partial class Form1 : Form
    {
        string? archivo = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                archivo = OpenFile.FileName;

                using (StreamReader rr = new StreamReader(archivo))
                {
                    richTextBox1.Text = rr.ReadToEnd();
                }
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();

            if(archivo != null) 
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.Write(richTextBox1.Text);
                }
            }
            else 
            { 
               if(SaveFile.ShowDialog() == DialogResult.OK)
                {
                    archivo = SaveFile.FileName;
                    using (StreamWriter sw = new StreamWriter(archivo))
                    {
                        sw.Write(richTextBox1.Text);
                    }
                }
            }
        }
    }
}
