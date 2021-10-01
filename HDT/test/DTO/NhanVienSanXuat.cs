using System;
using System.Collections.Generic;
using test.DTO;
using System.Linq;

namespace HDT.DTO
{
    class NhanVienSanXuat:NhanVienELCA1
    {
        int sonn;

        private List<NVSX_XL> dsLTT = new List<NVSX_XL>();

        public NhanVienSanXuat() : base(){}

        private static float PhuCapNangNhoc = 0.1f;

        public int Sonn { get => sonn; set => sonn = value; }

        public List<NVSX_XL> DsLTT { get => dsLTT; set => dsLTT = value; }

        public override float Luong()
        {
            return HESO[3] * LuongCB * (1+ PhuCapNangNhoc);
        }
        public override bool ChuaDatChiTieu_1_2021()
        {
            int num = dsLTT.Where(u => u.XepLoaiThiDua().Equals("D")).Select(t => t.Thang.Month == 1 && t.Thang.Year == 2021).Count();
            if (num > 0) return true;
            return false;
        }
        public override void xuat(int i)
        {
            base.xuat(i);

            foreach (NVSX_XL a in DsLTT)
            {
                a.xuat();
                Console.WriteLine("Luong nhan duoc: " + NhanLuong(a.XepLoaiThiDua(), Luong()));

            }
            Console.WriteLine("XepLoaiThiDua: "+ XepLoaiThiDua());

        }

        public override string XepLoaiThiDua()
        {
            int soA = dsLTT.Where(t => t.XepLoaiThiDua().Equals("A")).Count();
            int soB = dsLTT.Where(t => t.XepLoaiThiDua().Equals("B")).Count();
            int soC = dsLTT.Where(t => t.XepLoaiThiDua().Equals("C")).Count();
            int soD = dsLTT.Where(t => t.XepLoaiThiDua().Equals("D")).Count();

            if (soA > 10)
                return "Chien si thi dua";
            else if (soC <= 2 || soD == 1)
                return "Lao dong tien tien";
            return "Chua dat";
        }

        public override float TongLuong2021()
        {
            return dsLTT.Where(nv => nv.Thang.Year == 2021).Select(t => NhanLuong(t.XepLoaiThiDua(), Luong())).Sum();
        }

        public override float tongPCTheoNam(int nam)
        {
            return dsLTT.Where(nv => nv.Thang.Year == nam).Count() * PhuCapThamnien();
        }
    }
}
