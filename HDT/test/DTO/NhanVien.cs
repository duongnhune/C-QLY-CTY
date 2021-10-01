using System;
using System.Collections.Generic;
using System.Text;

namespace HDT.DTO
{
    abstract public class NhanVien
    {
        private string maNV, tenNV, gioitinh, diachi, maPB, sdt;
        private DateTime ngaysinh, thoigianvaolam, thoigianlamNVChinhThuc;
        private int cty;
        string email;
        public abstract float Luong();
        public abstract string XepLoaiThiDua();
        public abstract float TongLuong2021();
        public abstract bool ChuaDatChiTieu_1_2021();
        public abstract float tongPCTheoNam(int nam);

        public string MaNV 
        { 
            get => maNV;
            set => maNV = value;
        }
        public string TenNV 
        { 
            get => tenNV; 
            set => tenNV = value; 
        }
        public string Gioitinh 
        { 
            get => gioitinh; 
            set => gioitinh = checkGioiTinh(value); 
        }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt 
        { 
            get => sdt; 
            set => sdt = checkSdt(value); 
        }
        public DateTime Thoigianvaolam 
        { 
            get => thoigianvaolam;
            set => thoigianvaolam = value;//checkTuoi(value)? value : DateTime.Now.AddYears(-18); 
        }
        public DateTime ThoigianlamNVChinhThuc 
        { 
            get => thoigianlamNVChinhThuc; 
            set => thoigianlamNVChinhThuc = value; 
        }

        public string Email 
        { 
            get => email; 
            set => email = value; 
        }
        public string MaPB { get => maPB; set => maPB = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public int Cty { get => cty; set => cty = value; }

        private String taoMaNV()
        {
            Random r = new Random();

            int a = r.Next(998) + 100;

            String ma = this.maPB + thoigianvaolam.Year + a;
            return ma;
        }
        public NhanVien()
        {
            maNV = "";
            tenNV = "";
            ngaysinh = DateTime.Now.AddYears(-18);
            gioitinh = "Nam";
            diachi = "";
            sdt = "";
            thoigianvaolam = DateTime.Now;
            thoigianlamNVChinhThuc = DateTime.Now.AddDays(30);
            email = "";
        }
        public NhanVien( string maNV, string tenNV, DateTime ngaysinh, string gioitinh, string diachi, string sdt, DateTime thoigianvaolam, DateTime thoigianlamNVChinhThuc)
        {
            this.maNV = MaNV;
            this.tenNV = TenNV;
            this.ngaysinh = Ngaysinh;
            this.gioitinh = checkGioiTinh(Gioitinh);
            this.diachi = Diachi;
            this.sdt = checkSdt(Sdt);
            this.thoigianvaolam = checkTuoi(Thoigianvaolam) ? Thoigianvaolam : DateTime.Now.AddYears(-18);
            this.thoigianlamNVChinhThuc = ThoigianlamNVChinhThuc;
            this.email = Email;
        }
        public NhanVien(NhanVien a)
        {
            this.maNV = a.MaNV;
            this.tenNV = a.TenNV;
            this.ngaysinh = a.Ngaysinh;
            this.gioitinh = a.Gioitinh;
            this.diachi = a.Diachi;
            this.sdt = a.Sdt;
            this.thoigianvaolam = a.Thoigianvaolam;
            this.thoigianlamNVChinhThuc = a.ThoigianlamNVChinhThuc;
            this.email = a.Email;
        }
        private String checkGioiTinh(String gt)
        {
            String g = gt;
            if (g.ToLower().Equals("nam") || g.ToLower().Equals("nu"))
                return g;
            return "nam";
        }
        private String checkSdt(String sdt)
        {
            if (sdt.Length == 10) return sdt;
            return "";
        }
        private bool checkTuoi(DateTime ns)
        {
            if ((thoigianvaolam.Year - ns.Year) >= 18) return true;
            return false;
        }
        
        public float Thamnien()
        {
            return Math.Abs((DateTime.Now.Month - thoigianvaolam.Month) + 12 * (DateTime.Now.Year - thoigianvaolam.Year))/12;
        }
        public float PhuCapThamnien()
        {
            float s;
            if (Thamnien() <= 4)
                s = 600000;
            else if (Thamnien() <= 7)
                s = 2000000;
            else if (Thamnien() <= 10)
                s = 5000000;
            else
                s = 6000000 + (Thamnien() - 11) * 500;
            return s;
        }
        public virtual void xuat(int i)
        {
            if (i == 1)
                Console.WriteLine("Ma nhan vien: " + maNV + "\tTen nhan vien:" + tenNV + "\tDia chi:" + diachi + "\tSo dien thoai:" + sdt + " \tEmail: " + email);
            else if (i == 2)
                Console.WriteLine("Ma nhan vien: " + maNV + "\tTen nhan vien:" + tenNV + "\tDia chi:" + diachi + "\tSo dien thoai:" + sdt + " \tEmail: " + email + "\tThoi gian vao lam:" + thoigianvaolam);
            else if (i == 3)
                Console.WriteLine("Ma nhan vien: " + maNV + "\tTen nhan vien:" + tenNV + "\tGioi tinh:" + gioitinh + "\tDia chi:" + diachi + "\tSo dien thoai:" + sdt + "\t Email: " + email + "\tThoi gian vao lam:" + thoigianvaolam + "\tThoi gian duoc lam nhan vien chinh thuc:" + thoigianlamNVChinhThuc + "\tTham nien:" + Thamnien()+ "\tPhu cap tham nien:" + PhuCapThamnien());
            else
                Console.WriteLine("\nTham so nhap vao khong hop le!");
        }
    }
}
