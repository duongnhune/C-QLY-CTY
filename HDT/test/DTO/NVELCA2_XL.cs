using System;
using System.Collections.Generic;
using System.Text;

namespace test.DTO
{
    class NVELCA2_XL
    {
        private float doanhthudatduoc, thuong, hoahong;
        private DateTime thang;
        private float doanhthuthang;
        private float phucapcongtacphi;

        public float Doanhthudatduoc { get => doanhthudatduoc; set => doanhthudatduoc = value; }

        public float Thuong { get => thuong; set => thuong = value; }
        public float Hoahong { get => hoahong; set => hoahong = value; }
        public float Doanhthuthang { get => doanhthuthang; set => doanhthuthang = value; }
        public float Phucapcongtacphi { get => phucapcongtacphi; set => phucapcongtacphi = value; }
        public DateTime Thang { get => thang; set => thang = value; }

        public String xeploaithang(float pcThamNien)
        {
            string xl;

            float luong = Luong(pcThamNien);

            if (luong >= 23000000)
                xl = "Chien Si Thi Dua Thang";
            else if (luong >= 18000000)
                xl = "Lao Dong Tien Tien Thang";
            else
                xl = "Khong Dat Chi Tieu!";
            return xl;
        }

        public float Luong(float phuCapThamnien)//luong từng tháng
        {
            float luong = 0;
            if (doanhthudatduoc > (Doanhthuthang + (0.5f * Doanhthuthang)))
                luong = 0.3f * Doanhthuthang + Phucapcongtacphi + 10000000 + thuong + hoahong + phuCapThamnien;
            else if (doanhthudatduoc > (Doanhthuthang + (0.2f * Doanhthuthang)))
                luong = 0.25f * Doanhthuthang  + Phucapcongtacphi + thuong + hoahong + phuCapThamnien;
            else if (doanhthudatduoc > Doanhthuthang)
                luong = 0.2f * Doanhthuthang  + Phucapcongtacphi + thuong + hoahong + phuCapThamnien;
            else
                luong = 0.1f * Doanhthuthang + Phucapcongtacphi + phuCapThamnien;

            return luong;
        }
        public void xuat()
        {
            Console.WriteLine("Thang: " + Thang);
            Console.WriteLine("doanhthudatduoc: "+ doanhthudatduoc+ " doanhthuthang: " + doanhthuthang);
        }
    }
}
