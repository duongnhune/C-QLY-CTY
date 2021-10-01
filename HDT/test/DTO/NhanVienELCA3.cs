using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using test.DTO;

namespace HDT.DTO
{
    class NhanVienELCA3 : NhanVien
    {
        private List<NVELCA3_XL> lst = new List<NVELCA3_XL>();

        internal List<NVELCA3_XL> Lst { get => lst; set => lst = value; }

        public NhanVienELCA3(string maNV, string tenNV, DateTime ngaysinh, string gioitinh, string diachi, string sdt, DateTime thoigianvaolam, DateTime thoigianlamNVChinhThuc) 
            : base(maNV, tenNV, ngaysinh, gioitinh, diachi, sdt, thoigianvaolam, thoigianlamNVChinhThuc)
        {
        }

        public NhanVienELCA3() : base() { }
        public override bool ChuaDatChiTieu_1_2021()
        {
            int num = lst.Where(u => u.xlTheoThang(PhuCapThamnien()).Equals("Khong dat chi tieu")).Select(t => t.Thang.Month == 1 && t.Thang.Year == 2021).Count();
            if (num > 0) return true;
            return false;
        }
        public override float Luong()
        {
            return Lst.Select(t => t.luong(PhuCapThamnien())).Sum();
        }

        public override void xuat(int i)
        {
            base.xuat(i);
            foreach (NVELCA3_XL nv in Lst)
            {
                nv.xuat();
                Console.WriteLine("Luong: "+nv.luong(PhuCapThamnien()));
                Console.WriteLine("xlTheoThang :"+ nv.xlTheoThang(PhuCapThamnien()));
                
            }
            Console.WriteLine("Tong luong: " + Luong());
            Console.WriteLine("xeploaithidua: " + XepLoaiThiDua());
        }

        public override string XepLoaiThiDua()
        {
            int soA = Lst.Where(t => t.xlTheoThang(PhuCapThamnien()).Equals("Chien si thi dua")).Count();
            int soB = Lst.Where(t => t.xlTheoThang(PhuCapThamnien()).Equals("Lao dong tien tien")).Count();
            int soC = Lst.Where(t => t.xlTheoThang(PhuCapThamnien()).Equals("Khong dat chi tieu")).Count();

            if (soA > 9)
                return "Chien si thi dua";
            else if (soC >= 3)
                return "Khong dat chi tieu";
            return "Lao dong tien tien";
        }

        public override float TongLuong2021()
        {
            return lst.Where(nv => nv.Thang.Year == 2021).Select(t => t.luong(PhuCapThamnien())).Sum();
        }

        public override float tongPCTheoNam(int nam)
        {
            return lst.Where(nv => nv.Thang.Year == nam).Count() * PhuCapThamnien();
        }
    }
}
