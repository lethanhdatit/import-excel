namespace export_excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void crawlFilePathBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialogCrawl.ShowDialog() == DialogResult.OK)
            {
                crawlFilePathTxt.Text = openFileDialogCrawl.FileName;
            }
        }
    }
}