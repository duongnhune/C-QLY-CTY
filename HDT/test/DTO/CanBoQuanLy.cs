using System;
using System.Collections.Generic;
using System.Text;

namespace HDT.DTO
{
    class CanBoQuanLy : NhanVienELCA1
    {
        private String chucvu;
        private float hesochucvu;

        public string Chucvu { get => chucvu; set => chucvu = value; }
        public float Hesochucvu { get => hesochucvu; set => hesochucvu = value; }

        public override bool ChuaDatChiTieu_1_2021()
        {
            return false;
        }

        public override float Luong()
        {
            return HESO[2] * LuongCB + (hesochucvu * 1500000);
        }

        public override float TongLuong2021()
        {
            return Luong() * DateTime.Now.Month - DateTime.Parse("2021-1-5").Month;
        }

        public override float tongPCTheoNam(int nam)
        {
            return PhuCapThamnien() * DateTime.Now.Month - DateTime.Parse(nam+"-1-5").Month;
        }

        public override string XepLoaiThiDua()
        {
            return "Chien si thi dua";
        }

        public override void xuat(int i)
        {
            base.xuat(i);
            Console.WriteLine("Chuc vu: " + Chucvu + " He so chuc vu: " + Hesochucvu+ " Luong nahn duoc: "+ NhanLuong("A",Luong()));

        }
    }
}
