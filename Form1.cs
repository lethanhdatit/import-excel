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

            WorkBook wb = null;
            WorkSheet ws = null;

            try
            {
                var temp = Path.GetFileNameWithoutExtension(data.MonthName);
                var monthInStr = temp.Substring(Math.Max(0, temp.Length - 2));
                var numNameAvailable = int.TryParse(monthInStr, out int monthInNumber);
                var sheetNameStr = $"Tháng {monthInStr}";
                var sheetNameNum = $"Tháng {monthInNumber}";

                wb = WorkBook.Load(resultFilePathTxt.Text);
                ws = wb.GetWorkSheet(sheetNameStr) ?? wb.GetWorkSheet(sheetNameNum);

                if (ws == null)
                {
                    //todo
                }

                int r_index = 2;
                var maxRow = ws.RowCount;
                var needRowCount = data.Items.Sum(s => s.DsHangHoa.Count());

                if (maxRow < needRowCount)
                {
                    var addMoreCount = needRowCount - maxRow + 5;
                    for (int i = 0; i < addMoreCount; i++)
                    {
                        var ii = maxRow - 1 + i;
                        ws.InsertRow(ii);
                        ws.GetRow(ii).Value = string.Empty;
                    }
                    wb.Save();
                    wb.Close();
                    wb = WorkBook.Load(resultFilePathTxt.Text);
                    ws = wb.GetWorkSheet(sheetNameStr) ?? wb.GetWorkSheet(sheetNameNum);
                }

                MessageBox.Show($"{ws.Name} có {data.Items.Count()} tờ khai chuẩn bị được ghi, nhấn OK để bắt đầu và kiên nhẫn chờ cho đến khi có thông báo mới, đừng tắt ứng dụng!.", "Thông báo");

                int stt = 1;
                foreach (var item in data.Items)
                {
                    ws.GetRow(r_index).Columns[0].FormatString = IronXL.Formatting.BuiltinFormats.Number0;
                    ws.GetRow(r_index).Columns[0].IntValue = stt;

                    ws.GetRow(r_index).Columns[1].FormatString = IronXL.Formatting.BuiltinFormats.Text;
                    ws.GetRow(r_index).Columns[1].StringValue = item.SoToKhai;

                    ws.GetRow(r_index).Columns[2].FormatString = IronXL.Formatting.BuiltinFormats.Text;
                    ws.GetRow(r_index).Columns[2].StringValue = !string.IsNullOrWhiteSpace(item.MaNguoiNhapKhau) ? $"{item.MaNguoiNhapKhau} - {item.TenNguoiNhapKhau}" : item.TenNguoiNhapKhau;

                    ws.GetRow(r_index).Columns[3].FormatString = IronXL.Formatting.BuiltinFormats.Text;
                    ws.GetRow(r_index).Columns[3].StringValue = item.TongTrongLuongHangGross;

                    ws.GetRow(r_index).Columns[4].FormatString = IronXL.Formatting.BuiltinFormats.Text;
                    ws.GetRow(r_index).Columns[4].StringValue = item.NgayHangDiDuKien;

                    ws.GetRow(r_index).Columns[5].FormatString = IronXL.Formatting.BuiltinFormats.Text;
                    ws.GetRow(r_index).Columns[5].StringValue = item.NgayPhatHanh;

                    ws.GetRow(r_index).Columns[6].FormatString = IronXL.Formatting.BuiltinFormats.Text;
                    ws.GetRow(r_index).Columns[6].StringValue = item.TongGiaTriHoaDon;

                    if (item.DsHangHoa != null && item.DsHangHoa.Any())
                    {
                        foreach (var sp in item.DsHangHoa)
                        {
                            ws.GetRow(r_index).Columns[7].FormatString = IronXL.Formatting.BuiltinFormats.Text;
                            ws.GetRow(r_index).Columns[7].StringValue = sp.MaSoHangHoa;

                            ws.GetRow(r_index).Columns[8].FormatString = IronXL.Formatting.BuiltinFormats.Text;
                            ws.GetRow(r_index).Columns[8].StringValue = sp.MoTaHangHoa;
                            r_index++;
                        }
                    }
                    else
                        r_index++;

                    stt++;
                }
                wb.Save();
                wb.Close();
                MessageBox.Show($"{ws.Name} ghi vào hoàn tất!", "Thông báo");
            }
            catch (Exception ex)
            {
                wb.Close();
                MessageBox.Show($"{ws.Name} trạng thái ghi vào có lỗi, message: {ex.Message}. Vui lòng gửi mã lỗi này đến quản trị viên ứng dụng", "Thông báo");
                return;
            }
        }
    }
}