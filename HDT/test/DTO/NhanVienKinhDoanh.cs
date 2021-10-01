using System;
using System.Collections.Generic;
using System.Text;
using test.DTO;
using System.Linq;

namespace HDT.DTO
{
    class NhanVienKinhDoanh : NhanVienELCA1
    {
        private List<NVKD_XL> lst = new List<NVKD_XL>();

        public NhanVienKinhDoanh() : base()
        {
        }

        internal List<NVKD_XL> Lst { get => lst; set => lst = value; }

        public override bool ChuaDatChiTieu_1_2021()
        {
            int num = lst.Where(u => u.XepLoaiThiDua().Equals("D")).Select(t => t.Thang.Month == 1 && t.Thang.Year == 2021).Count();
            if (num > 0) return true;
            return false;
        }

        public override float Luong()
        {
            return HESO[0] * LuongCB;
        }

        public override float TongLuong2021()
        {
            return lst.Where(nv => nv.Thang.Year == 2021).Select(t => t.HoaHong + Luong()).Sum();
        }

        public override float tongPCTheoNam(int nam)
        {
            return lst.Where(nv => nv.Thang.Year == nam).Count() * PhuCapThamnien();
        }

        public override string XepLoaiThiDua()
        {
            int soA = Lst.Where(t => t.XepLoaiThiDua().Equals("A")).Count();
            int soB = Lst.Where(t => t.XepLoaiThiDua().Equals("B")).Count();
            int soC = Lst.Where(t => t.XepLoaiThiDua().Equals("C")).Count();
            int soD = Lst.Where(t => t.XepLoaiThiDua().Equals("D")).Count();

            if (soA > 10)
                return "Chien si thi dua";
            else if (soC <= 2 || soD == 1)
                return "Lao dong tien tien";
            return "Chua dat";
        }

        public override void xuat(int i)
        {
            base.xuat(i);
            Console.WriteLine("xeploaiNV(): "+ XepLoaiThiDua());
            foreach (NVKD_XL a in Lst)
            {
                a.xuat();
                Console.WriteLine("Luong theo thang: "+ (Luong() + a.HoaHong));
            }
        }
    }
}
