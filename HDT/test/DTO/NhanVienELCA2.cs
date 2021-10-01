using System;
using System.Collections.Generic;
using System.Text;
using test.DTO;
using System.Linq;

namespace HDT.DTO
{
    class NhanVienELCA2:NhanVien
    {

        private List<NVELCA2_XL> lst = new List<NVELCA2_XL>();

        internal List<NVELCA2_XL> Lst { get => lst; set => lst = value; }

        public NhanVienELCA2(string maNV, string tenNV, DateTime ngaysinh, string gioitinh, string diachi, string sdt, DateTime thoigianvaolam, DateTime thoigianlamNVChinhThuc)
            :base(maNV,  tenNV,  ngaysinh,  gioitinh,  diachi,  sdt,  thoigianvaolam,  thoigianlamNVChinhThuc)
        {
           
        }
        public NhanVienELCA2() : base()
        {
           
        }
        public override bool ChuaDatChiTieu_1_2021()
        {
            int num = lst.Where(u => u.xeploaithang(PhuCapThamnien()).Equals("Khong Dat Chi Tieu!")).Select(t => t.Thang.Month == 1 && t.Thang.Year == 2021).Count();
            if (num > 0) return true;
            return false;
        }
        public override float Luong()//tong luong của nhan viên đó
        {
            return lst.Select(t => t.Luong(PhuCapThamnien())).Sum();
        }
       
        public override void xuat(int i)
        {
            base.xuat(i);
            Console.WriteLine("NV CTY2\n\n\n");
            foreach (NVELCA2_XL nv in Lst)
            {
                
                nv.xuat();
                Console.WriteLine("Luong: " + (nv.Luong(PhuCapThamnien())));
                Console.WriteLine("Xep loai thang: " + nv.xeploaithang(PhuCapThamnien()));
            }
            Console.WriteLine("xeploaithidua: " + XepLoaiThiDua());

        }

        public override string XepLoaiThiDua()
        {
            int soA = Lst.Where(t => t.xeploaithang(PhuCapThamnien()).Equals("Chien Si Thi Dua Thang")).Count();
            int soB = Lst.Where(t => t.xeploaithang(PhuCapThamnien()).Equals("Lao Dong Tien Tien Thang")).Count();
            int soC = Lst.Where(t => t.xeploaithang(PhuCapThamnien()).Equals("Khong Dat Chi Tieu!")).Count();

            if (soA > 9)
                return "Chien si thi dua";
            else if (soC >= 3)
                return "Khong dat chi tieu";
            return "Lao dong tien tien";
        }

        public override float TongLuong2021()
        {
            return lst.Where(nv => nv.Thang.Year == 2021).Select(t => t.Luong(PhuCapThamnien())).Sum();
        }

        public override float tongPCTheoNam(int nam)
        {
            return lst.Where(nv => nv.Thang.Year == nam).Count() * PhuCapThamnien();
        }
    }
}
