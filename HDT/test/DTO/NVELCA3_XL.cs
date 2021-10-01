using System;
using System.Collections.Generic;
using System.Text;

namespace test.DTO
{
    class NVELCA3_XL
    {
        private int slKhachHangMoi;
        private int slKhacHangToiThieu;
        private float phuCapCongTacPhi;
        private DateTime thang;
        public int SlKhachHangMoi { get => slKhachHangMoi; set => slKhachHangMoi = value; }
        public int SlKhacHangToiThieu { get => slKhacHangToiThieu; set => slKhacHangToiThieu = value; }
        public float PhuCapCongTacPhi { get => phuCapCongTacPhi; set => phuCapCongTacPhi = value; }
        public DateTime Thang { get => thang; set => thang = value; }

        internal void xuat()
        {
            Console.WriteLine("slKhachHangMoi: "+ slKhachHangMoi);
        }
        public string xlTheoThang(float phucapthamniem)
        {
            if (luong(phucapthamniem) >= 25000000)
                return "Chien si thi dua";
            else if (luong(phucapthamniem) >= 20000000)
                return "Lao dong tien tien";
            return "Khong dat chi tieu";
        }
        public float luong(float phucapthamniem)
        {
            float luong = 0;

            if (slKhachHangMoi > (slKhacHangToiThieu + slKhacHangToiThieu * 0.5))
                luong = 1.4f * slKhachHangMoi * 2000000 + 6000000 + phuCapCongTacPhi + phucapthamniem;
            else if (slKhachHangMoi > (slKhacHangToiThieu + slKhacHangToiThieu * 0.2))
                luong = 1.2f * slKhachHangMoi * 2000000 + phuCapCongTacPhi + phucapthamniem;
            else if (slKhachHangMoi > slKhacHangToiThieu)
                luong = slKhachHangMoi * 2000000 + phuCapCongTacPhi + phucapthamniem;
            else luong = 0.5f * slKhachHangMoi * 2000000 + phuCapCongTacPhi + phucapthamniem;

            return luong;
        }
    }
}
