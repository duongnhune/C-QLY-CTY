using HDT.DTO;
using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            hienthiMenu();
            thucthiCT();

            Console.ReadLine();
        }
        static void hienthiMenu()
        {
            Console.Write("**************************************************************************************************************");
            Console.Write("\n**************************************************CONG TY ELCA**********************************************");
            Console.Write("\n*1. Danh sach thanh vien                                                                                   *");
            Console.Write("\n*2. 5.Them moi 1 nhan vien cua cong ty                                                                     *");
            Console.Write("\n*3. 6.Tim Nhan vien theo cong ty:                                                                          *");
            Console.Write("\n*4. 7.Chinh sua thong tin theo ma dua vao                                                                  *");
            Console.Write("\n*5. 8.Xoa thong tin nhan vien:                                                                             *");
            Console.Write("\n*6. 9.Dem so nhan vien moi vao cong ty                                                                     *");
            Console.Write("\n*7. 10.Xuat danh sach nhan vien co tham nien tren 10 nam                                                   *");
            Console.Write("\n*8. 11.Xuat tong phu cap 2021                                                                              *");
            Console.Write("\n*9. 12.Xuat tong luong 2021                                                                                *");
            Console.Write("\n*10. 13.Xuat thong tin nhan vien la chien si thi dua                                                       *");
            Console.Write("\n*11. 14.Xuat danh sach cac nhan vien khong dat chi tieu trong tháng 1/2021 cua cong ty ELCA                *");
            Console.Write("\n************************************************************************************************************");
            Console.Write("\n************************************************************************************************************");
        }
        static void thucthiCT()
        {
            int chon = -1;
            CongTyELCA cty = new CongTyELCA();
            cty.docFile();
            while (chon != 0)
            {
                Console.Write("\nChon chuc nang can thuc thi chuong trinh: ");
                chon = int.Parse(Console.ReadLine());
                Console.Write("\n**********************************\n\n");

                switch (chon)
                {
                    case 1:                       
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("Danh sach nhanvien\n\n\n");
                        cty.xuat(cty.lst);
                        Console.WriteLine("=================================================================================");
                        break;
                    case 2:
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("\n5.Them moi 1 nhan vien cua cong ty");
                        NhanVien nv = new NhanVienELCA3();
                        nv.Cty = 1;
                        nv.MaPB = "SX";
                        nv.MaNV = "SX2001016";
                        nv.TenNV = "La Thi La";
                        nv.Ngaysinh = DateTime.Parse("1990-09-20");
                        nv.Gioitinh = "Nu";
                        nv.Diachi = "Go Vap";
                        nv.Sdt = "012345678";
                        DateTime dt = DateTime.Now;
                        nv.Thoigianvaolam = dt;
                        nv.ThoigianlamNVChinhThuc = dt.AddMonths(4);
                        nv.Email = "hrlo@gmail.com";
                        cty.ThemNhanVien(nv);
                        Console.WriteLine("=================================================================================");
                        break;
                    case 3:
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("\n6.Tim Nhan vien theo cong ty:");
                        cty.TimNhanVienTheoTheoCTy("ELCA4");
                        Console.WriteLine("=================================================================================");
                        break;
                    case 4:
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("\n.7.Chinh sua thong tin theo ma dua vao");
                        NhanVien n = new NhanVienELCA3();
                        n.Cty = 1;
                        n.MaPB = "SX";
                        n.MaNV = "SX2001012";
                        n.TenNV = "La Thi La";
                        n.Ngaysinh = DateTime.Parse("1990-09-19");
                        n.Gioitinh = "Nu";
                        n.Diachi = "Go Vap";
                        n.Sdt = "012345678";
                        n.Thoigianvaolam = DateTime.Now;
                        n.ThoigianlamNVChinhThuc = DateTime.Now.AddMonths(4);
                        n.Email = "hrlo001@gmail.com";
                        cty.CapNhatThongTinNhanvien(n);
                        Console.WriteLine("=================================================================================");
                        break;
                    case 5:
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("\n.8.Xoa thong tin nhan vien:");
                        cty.XoaNhanVien("SX2019002");
                        Console.WriteLine("=================================================================================");
                        break;
                    case 6:
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("\n9.Dem so nhan vien moi vao cong ty");
                        cty.demsoNVmoiCTy();
                        Console.WriteLine("=================================================================================");
                        break;
                    case 7:
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("\n.10.Xuat danh sach nhan vien co tham nien tren 10 nam");
                        cty.ThanhVienCoThamNienTren10Nam();
                        Console.WriteLine("=================================================================================");
                        break;
                    case 8:
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("\n11.Xuat tong phu cap 2021");
                        cty.TongPCTNTheoNam(2021);
                        Console.WriteLine("=================================================================================");
                        break;
                    case 9:
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("\n12.Xuat tong luong 2021");
                        cty.TongLuongNam2021();
                        Console.WriteLine("=================================================================================");
                        break;
                    case 10:
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("\n.13.Xuat thong tin nhan vien la chien si thi dua");
                        cty.NhanVienLaChienSiThiDua();
                        Console.WriteLine("=================================================================================");
                        break;
                    case 11:
                        Console.WriteLine("=================================================================================");
                        Console.WriteLine("\n14.Xuất danh sách các nhân viên không đạt chỉ tiêu trong tháng 1/2021 của công ty ELCA ");
                        cty.xuatDSKhongDatChiTieu_01_2021();
                        break;
                    case 12:
                        break;

                }
            }
        }
    }
}
