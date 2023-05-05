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
            openFileDialogCrawl.FileName = null;
            openFileDialogCrawl.Filter = "Text files |*-crawl.json";
            if (openFileDialogCrawl.ShowDialog() == DialogResult.OK)
            {
                crawlFilePathTxt.Text = openFileDialogCrawl.FileName;
            }
        }

        private void resultFilePathBtn_Click(object sender, EventArgs e)
        {
            openFileDialogOutput.FileName = null;
            openFileDialogOutput.Filter = "Excel |*.xlsx";
            if (openFileDialogOutput.ShowDialog() == DialogResult.OK)
            {
                resultFilePathTxt.Text = openFileDialogOutput.FileName;
            }
        }
    }
}