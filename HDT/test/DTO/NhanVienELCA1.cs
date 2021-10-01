using System;
using System.Collections.Generic;
using System.Text;

namespace HDT.DTO
{
    abstract class NhanVienELCA1 : NhanVien
    {
        public float[] HESO = { 2.34f, 2.67f,3f, 3.33f,3.66f,3.99f,4.32f,4.65f };
        public static float LuongCB = 1500000f;

        public NhanVienELCA1(string maNV, string tenNV, DateTime ngaysinh, string gioitinh, string diachi, string sdt, DateTime thoigianvaolam, DateTime thoigianlamNVChinhThuc)
            : base(maNV, tenNV, ngaysinh, gioitinh, diachi, sdt, thoigianvaolam, thoigianlamNVChinhThuc)
        {

        }
        public NhanVienELCA1() : base()
        {

        }
        public float NhanLuong(String xl, float Luong)
        {
            if (xl.Equals("A")) return Luong+ PhuCapThamnien();
            else if (xl.Equals("B")) return Luong- (Luong* 0.2f) + PhuCapThamnien();
            else if(xl.Equals("C")) return Luong- (Luong* 0.45f) + PhuCapThamnien();
            else if(xl.Equals("D")) return PhuCapThamnien();
            return 0;
        }
        public override void xuat(int i)
        {
            base.xuat(i);
        } 
    }
}
