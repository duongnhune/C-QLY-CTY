
using System;
using System.Collections.Generic;
using System.Text;

namespace test.DTO
{
    class NVSX_XL
    {
        private int sonn;
        private DateTime thang;
        public int Sonn { get => sonn; set => sonn = value; }
        public DateTime Thang { get => thang; set => thang = value; }

        public string XepLoaiThiDua()
        {
            string xl;
            if (sonn <= 1)
                xl = "A";
            else if (sonn <= 3)
                xl = "B";
            else if (sonn <= 5)
                xl = "C";
            else
                xl = "D";
            return xl;
        }
        
        public void xuat()
        {
            Console.WriteLine("So ngay nghi :" + Sonn);
        }
    }
}
