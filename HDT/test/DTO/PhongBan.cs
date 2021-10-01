using System;
using System.Collections.Generic;
using System.Text;

namespace HDT.DTO
{
    public class PhongBan
    {
        string maPB;
        string tenPB;

        public string MaPB { get => maPB; set => maPB = checkmaPB(value)? value: ""; } 
        public string TenPB { get => tenPB; set => tenPB = value; }

        public PhongBan()
        {
            this.maPB = "";
            this.tenPB = "";
        }
        public PhongBan( string maPB, string tenPB)
        {
            this.maPB = checkmaPB(maPB) ? maPB : ""; 
            this.tenPB = TenPB;
        }
        public PhongBan( PhongBan a)
        {
            this.maPB = checkmaPB(a.maPB) ? a.maPB : "";
            this.tenPB = a.TenPB;
        }
        private bool checkmaPB(String maPB) // check ma phong ban
        {   // tach chuoi
            char a = TenPB[0];
            char b = this.tenPB.ToUpper()[tenPB.IndexOf(' ') + 1];
            // noi chuoi
            String ma = String.Concat(a,b);
            if (ma.Equals(maPB)) return true;

            return false;
        }
        public void Xuat()
        {
            Console.WriteLine("Ma phong: "+ MaPB + " Ten phong: "+TenPB);
        }
    }
}
