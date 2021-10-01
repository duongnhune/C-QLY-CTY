using System;
using System.Collections.Generic;
using System.Text;

namespace test.DTO
{
    class NVKD_XL
    {
        float doanhSToiThieu, doanhSTheoThang;
        float hoaHong;
        private DateTime thang;
        public float DoanhSoToiThieu { get => doanhSToiThieu; set => doanhSToiThieu = value; }
        public float DoanhSoTheoThang { get => doanhSTheoThang; set => doanhSTheoThang = value; }
        public float HoaHong { get => hoaHong; set => hoaHong = value; }
        public DateTime Thang { get => thang; set => thang = value; }

        public string XepLoaiThiDua()
        {
            string xl;
            if (doanhSTheoThang == doanhSToiThieu)
                xl = "B";
            else if (doanhSTheoThang < doanhSToiThieu)
                xl = "C";
            else if (doanhSTheoThang < 0.5f * doanhSToiThieu)
                xl = "D";
            else
                xl = "A";
            return xl;
        }
        public float DTHoaHong()
        {
            float s;
            if (doanhSTheoThang > doanhSToiThieu)
                s = (doanhSTheoThang - doanhSToiThieu) * 0.15f;
            else
                s = 0;
            return s;
        }
        public void xuat()
        {
            Console.WriteLine("Doanh so toi thieu:" + DoanhSoToiThieu + " Doanh so theo thang: " + DoanhSoTheoThang + " Hoa hong: " + HoaHong);
        }
    }
}
