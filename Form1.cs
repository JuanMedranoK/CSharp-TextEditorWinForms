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
            Abrir();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (archivo != null)
                GuardarArchivo();
            else
                GuardarComo();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarComo();
        }
        private void GuardarArchivo()
        {
            using StreamWriter sw = new(archivo!);
            sw.Write(richTextBox1.Text);
        }
        private void GuardarComo()
        {
            SaveFileDialog saveFile = new()
            {
                Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*",
                DefaultExt = "txt",
                AddExtension = true
            };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                archivo = saveFile.FileName;
                GuardarArchivo();
            }
        }

        private void Abrir() 
        {
            OpenFileDialog OpenFile = new()
            {
                Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            };

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                archivo = OpenFile.FileName;

                using StreamReader rr = new(archivo);
                richTextBox1.Text = rr.ReadToEnd();
            }
        }
    }
}
