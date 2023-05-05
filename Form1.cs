using IronXL;
using Newtonsoft.Json;

namespace export_excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IronXL.License.LicenseKey = "IRONXL.THANHDAT.27200-D4AAD4A7ED-7GZR4STSZWYEBS3Z-GSIXVSOPY3VV-TN7NIQMZK6J2-OZZGW4DJNISO-CDDCJAROFOJC-J6FRAQ-TW3JXRU5FQ2JUA-DEPLOYMENT.TRIAL-WUZFMK.TRIAL.EXPIRES.03.JUN.2023";
            var testLic = IronXL.License.IsLicensed;
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

        private void runBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(crawlFilePathTxt.Text))
            {
                MessageBox.Show("Hãy chọn file crawl", "Thông báo");
                return;
            }

            if (string.IsNullOrWhiteSpace(resultFilePathTxt.Text))
            {
                MessageBox.Show("Hãy chọn file đích cần ghi vào", "Thông báo");
                return;
            }

            var data = JsonConvert.DeserializeObject<CrawlData>(File.ReadAllText(crawlFilePathTxt.Text));
            if(string.IsNullOrWhiteSpace(data?.MonthName) || data.Items == null || !data.Items.Any())
            {
                MessageBox.Show("File crawl bạn chọn không có dữ liệu hoặc dữ liệu không hợp lệ.", "Thông báo");
                return;
            }

            var temp = Path.GetFileNameWithoutExtension(data.MonthName);
            var monthInStr = temp.Substring(Math.Max(0, temp.Length - 2));
            var numNameAvailable = int.TryParse(monthInStr, out int monthInNumber);
            var sheetNameStr = $"Tháng {monthInStr}";
            var sheetNameNum = $"Tháng {monthInNumber}";
            //WorkBook wb = WorkBook.Load(resultFilePathTxt.Text);

            //var ws = wb.GetWorkSheet();
        }
    }
}