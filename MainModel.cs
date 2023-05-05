using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace export_excel
{
    public class DsHangHoa
    {
        public string MaSoHangHoa { get; set; }
        public string MoTaHangHoa { get; set; }
    }

    public class Item
    {
        public string FilePath { get; set; }
        public string SoToKhai { get; set; }
        public string MaNguoiNhapKhau { get; set; }
        public string TenNguoiNhapKhau { get; set; }
        public string TongTrongLuongHangGross { get; set; }
        public string NgayHangDiDuKien { get; set; }
        public string NgayPhatHanh { get; set; }
        public string TongGiaTriHoaDon { get; set; }
        public List<DsHangHoa> DsHangHoa { get; set; }
    }

    public class CrawlData
    {
        public string MonthName { get; set; }
        public List<Item> Items { get; set; }
    }
}
