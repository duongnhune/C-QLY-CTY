using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using test.DTO;

namespace HDT.DTO
{
    public class CongTyELCA
    {
       public List<NhanVien> lst = new List<NhanVien>();
        XmlDocument read = new XmlDocument();
        XmlElement root;
        String fileName = "XMLFile1.xml";
       public CongTyELCA()
        {
            read.Load(fileName);
            root = read.DocumentElement;
        }
        public void docFile()
        {
            lst.Clear();

            XmlNodeList nodeList = read.SelectNodes("/DSNhanVien/NhanSu");
            foreach (XmlNode node in nodeList)
            {
                //NhanVien nv = null;
                
                int cty = int.Parse(node["ELCA"].InnerText);
                if(cty == 1)
                {
                    String maPB = node["MaPB"].InnerText;
                    if(maPB.Equals("SX"))
                    {
                        NhanVienSanXuat nva = new NhanVienSanXuat();
                        nva.Cty = cty;
                        nva.MaPB = node["MaPB"].InnerText;
                        nva.MaNV = node["MaNV"].InnerText;
                        nva.TenNV = node["HoTen"].InnerText;
                        nva.Ngaysinh = DateTime.Parse(node["NgaySinh"].InnerText);
                        nva.Gioitinh = node["GioiTinh"].InnerText;
                        nva.Diachi = node["DiaChi"].InnerText;
                        nva.Sdt = node["SDT"].InnerText;
                        nva.Thoigianvaolam = DateTime.Parse(node["TGVL"].InnerText);
                        nva.ThoigianlamNVChinhThuc = DateTime.Parse(node["TGCT"].InnerText);
                        nva.Email = node["Email"].InnerText;

                        XmlNodeList nodeLstSub = node.SelectNodes("DSSoNgayNghi/SLThang");

                        foreach (XmlNode node1 in nodeLstSub)
                        {
                            NVSX_XL n = new NVSX_XL();
                            n.Thang = DateTime.Parse(node1["Thang"].InnerText);
                            n.Sonn = int.Parse(node1["SNN"].InnerText);
                            nva.DsLTT.Add(n);
                        }

                        lst.Add(nva);
                    }
                    else if (maPB.Equals("KD"))
                    {
                        NhanVienKinhDoanh nv = new NhanVienKinhDoanh();
                        nv.Cty = cty;
                        nv.MaPB = node["MaPB"].InnerText;
                        nv.MaNV = node["MaNV"].InnerText;
                        nv.TenNV = node["HoTen"].InnerText;
                        nv.Ngaysinh = DateTime.Parse(node["NgaySinh"].InnerText);
                        nv.Gioitinh = node["GioiTinh"].InnerText;
                        nv.Diachi = node["DiaChi"].InnerText;
                        nv.Sdt = node["SDT"].InnerText;
                        nv.Thoigianvaolam = DateTime.Parse(node["TGVL"].InnerText);
                        nv.ThoigianlamNVChinhThuc = DateTime.Parse(node["TGCT"].InnerText);
                        nv.Email = node["Email"].InnerText;
                     
                        XmlNodeList nodeLstSub = node.SelectNodes("DSDSThang/LThang");

                        foreach (XmlNode node1 in nodeLstSub)
                        {
                            NVKD_XL n = new NVKD_XL();
                            n.Thang = DateTime.Parse(node1["Thang"].InnerText);
                            n.DoanhSoToiThieu = int.Parse(node1["DSTT"].InnerText);
                            n.DoanhSoTheoThang = int.Parse(node1["DSBHTT"].InnerText);
                            n.HoaHong = float.Parse(node1["HoaHong"].InnerText);
                            nv.Lst.Add(n);
                        }
                        lst.Add(nv);
                    }
                    else if (maPB.Equals("CB"))
                    {
                        CanBoQuanLy nv = new CanBoQuanLy();
                        nv.Cty = cty;
                        nv.MaPB = node["MaPB"].InnerText;
                        nv.MaNV = node["MaNV"].InnerText;
                        nv.TenNV = node["HoTen"].InnerText;
                        nv.Ngaysinh = DateTime.Parse(node["NgaySinh"].InnerText);
                        nv.Gioitinh = node["GioiTinh"].InnerText;
                        nv.Diachi = node["DiaChi"].InnerText;
                        nv.Sdt = node["SDT"].InnerText;
                        nv.Thoigianvaolam = DateTime.Parse(node["TGVL"].InnerText);
                        nv.ThoigianlamNVChinhThuc = DateTime.Parse(node["TGCT"].InnerText);
                        nv.Email = node["Email"].InnerText;
                        nv.Chucvu = node["ChucVu"].InnerText;
                        nv.Hesochucvu = float.Parse(node["HSChucVu"].InnerText);
                        lst.Add(nv);
                    }
                }
                else if(cty == 2)
                {
                    NhanVienELCA2 nv = new NhanVienELCA2();
                    nv.Cty = cty;
                    nv.MaPB = node["MaPB"].InnerText;
                    nv.MaNV = node["MaNV"].InnerText;
                    nv.TenNV = node["HoTen"].InnerText;
                    nv.Ngaysinh = DateTime.Parse(node["NgaySinh"].InnerText);
                    nv.Gioitinh = node["GioiTinh"].InnerText;
                    nv.Diachi = node["DiaChi"].InnerText;
                    nv.Sdt = node["SDT"].InnerText;
                    nv.Thoigianvaolam = DateTime.Parse(node["TGVL"].InnerText);
                    nv.ThoigianlamNVChinhThuc = DateTime.Parse(node["TGCT"].InnerText);
                    nv.Email = node["Email"].InnerText;

                    XmlNodeList nodeLstSub = node.SelectNodes("DSThang/LThang");

                    foreach (XmlNode node1 in nodeLstSub)
                    {
                        NVELCA2_XL n = new NVELCA2_XL();
                        n.Thang = DateTime.Parse(node1["Thang"].InnerText);
                        n.Doanhthuthang = float.Parse(node1["DTT"].InnerText);
                        n.Doanhthudatduoc = float.Parse(node1["DTDC"].InnerText);
                        n.Phucapcongtacphi = int.Parse(node1["PCCongTacPhi"].InnerText);
                        n.Thuong = float.Parse(node1["Thuong"].InnerText);
                        n.Hoahong = float.Parse(node1["HoaHong"].InnerText);

                        nv.Lst.Add(n);
                    }
                    lst.Add(nv);
                }
                else if (cty == 3)
                {
                    NhanVienELCA3 nv = new NhanVienELCA3();
                    nv.Cty = cty;
                    nv.MaPB = node["MaPB"].InnerText;
                    nv.MaNV = node["MaNV"].InnerText;
                    nv.TenNV = node["HoTen"].InnerText;
                    nv.Ngaysinh = DateTime.Parse(node["NgaySinh"].InnerText);
                    nv.Gioitinh = node["GioiTinh"].InnerText;
                    nv.Diachi = node["DiaChi"].InnerText;
                    nv.Sdt = node["SDT"].InnerText;
                    nv.Thoigianvaolam = DateTime.Parse(node["TGVL"].InnerText);
                    nv.ThoigianlamNVChinhThuc = DateTime.Parse(node["TGCT"].InnerText);
                    nv.Email = node["Email"].InnerText;

                    XmlNodeList nodeLstSub = node.SelectNodes("DSThang/LThang");

                    foreach (XmlNode node1 in nodeLstSub)
                    {
                        NVELCA3_XL n = new NVELCA3_XL();
                        n.Thang = DateTime.Parse(node1["Thang"].InnerText);
                        n.SlKhachHangMoi = int.Parse(node1["SLKHM"].InnerText);
                        n.SlKhacHangToiThieu = int.Parse(node1["SLKHTT"].InnerText);
                        n.PhuCapCongTacPhi = float.Parse(node1["PCCongTacPhi"].InnerText);
                        nv.Lst.Add(n);
                    }
                    lst.Add(nv);
                }
            }
        }
        //(5).	Thêm mới 1 nhân viên của các công ty
        public void ThemNhanVien(NhanVien nv)
        {
            XmlNode node = root.SelectSingleNode("/DSNhanVien/NhanSu[MaNV='" + nv.MaNV + "']");

            if (node == null)
            {
                XmlElement nhanSu, cTy, maPB, maNV, hoTen, ngaySinh, gioiTinh, diaChi, sdt, tGVL, tGCT, email;

                nhanSu = read.CreateElement("NhanSu");

                cTy = read.CreateElement("ELCA");
                cTy.InnerText = nv.Cty.ToString();

                maPB = read.CreateElement("MaPB");
                maPB.InnerText = nv.MaPB.ToString();

                maNV = read.CreateElement("MaNV");
                maNV.InnerText = nv.MaNV.ToString();

                hoTen = read.CreateElement("HoTen");
                hoTen.InnerText = nv.TenNV.ToString();

                ngaySinh = read.CreateElement("NgaySinh");
                ngaySinh.InnerText = nv.Ngaysinh.ToString();

                gioiTinh = read.CreateElement("GioiTinh");
                gioiTinh.InnerText = nv.Gioitinh.ToString();

                diaChi = read.CreateElement("DiaChi");
                diaChi.InnerText = nv.Diachi.ToString();

                sdt = read.CreateElement("SDT");
                sdt.InnerText = nv.Sdt.ToString();

                tGVL = read.CreateElement("TGVL");
                tGVL.InnerText = nv.Thoigianvaolam.ToString();

                tGCT = read.CreateElement("TGCT");
                tGCT.InnerText = nv.ThoigianlamNVChinhThuc.ToString();

                email = read.CreateElement("Email");
                email.InnerText = nv.Email.ToString();

                nhanSu.AppendChild(cTy);
                nhanSu.AppendChild(maPB);
                nhanSu.AppendChild(maNV);
                nhanSu.AppendChild(hoTen);
                nhanSu.AppendChild(ngaySinh);
                nhanSu.AppendChild(gioiTinh);
                nhanSu.AppendChild(diaChi);
                nhanSu.AppendChild(sdt);
                nhanSu.AppendChild(tGVL);
                nhanSu.AppendChild(tGCT);
                nhanSu.AppendChild(email);

                read.DocumentElement.AppendChild(nhanSu);
                read.Save(fileName);

                docFile();
                xuat(lst);
            }
            else Console.WriteLine("Nhan vien co ma :" + nv.MaNV + " da ton tai");

        }
        public void xuat(List<NhanVien> l)
        {
            if (l != null)
            {
                foreach (NhanVien nv in l)
                {
                    nv.xuat(1);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
        //(6).	Tìm kiếm thông tin nhân viên của mỗi công ty
        public void TimNhanVienTheoTheoCTy(String CongTy)
        {
            Console.WriteLine("------------------------------------------\n");
            List<NhanVien> l;
            if (CongTy.Equals("ELCA1"))
            {
                Console.WriteLine("Danh sach nhan vien Cong ty ELCA1: ");
                l = lst.Where(t => t.Cty == 1).ToList();
            }
            else if (CongTy.Equals("ELCA2"))
            {
                Console.WriteLine("Danh sach nhan vien Cong ty ELCA2: ");
                l = lst.Where(t => t.Cty == 2).ToList();
            }
            else if (CongTy.Equals("ELCA3"))
            {
                Console.WriteLine("Danh sach nhan vien Cong ty ELCA3: ");
                l = lst.Where(t => t.Cty == 3).ToList();
            }
            else
            {
                Console.WriteLine("Khong ton tai cong ty " + CongTy);
                l = null;
            }
            xuat(l);
        }
        //7.Chỉnh sửa thông tin nhân viên được đưa vào
        public void CapNhatThongTinNhanvien(NhanVien nv)
        {
            XmlNode node = root.SelectSingleNode("/DSNhanVien/NhanSu[MaNV='" + nv.MaNV + "']");

            if (node != null)
            {
                node["HoTen"].InnerText = nv.TenNV;
                node["NgaySinh"].InnerText = nv.Ngaysinh.ToString("yyyy-MM-dd");  //ToString("dd / MM / yy");
                node["GioiTinh"].InnerText = nv.Gioitinh;
                node["DiaChi"].InnerText = nv.Diachi;
                node["SDT"].InnerText = nv.Sdt;
                node["Email"].InnerText = nv.Email;
                read.Save(fileName);

                docFile();
                xuat(lst);
            }
            else
            {
                Console.WriteLine("Nhan vien co ma: " + nv.MaNV + " khong ton tai");
            }
        }
        // 8.Xoá thông tin nhân viên
        public void XoaNhanVien(String maNV)
        {
            XmlNode node = root.SelectSingleNode("/DSNhanVien/NhanSu[MaNV='"+maNV+"']");

            if(node != null)
            {
                root.RemoveChild(node);
                read.Save(fileName);
                docFile();
                xuat(lst);
            }
            else
            {
                Console.WriteLine("Nhan vien co ma: "+ maNV + " khong ton tai");
            }
         
        }
        
        //(9).	Đếm số nhân viên của mỗi công ty 
        public void demsoNVmoiCTy()
        {
            Console.WriteLine("So nhan vien cua moi cong ty: ");
            Console.WriteLine("Cong ty ELCA1: "+ lst.Where(t=> t.Cty == 1).Count());
            Console.WriteLine("Cong ty ELCA2: "+ lst.Where(t=> t.Cty == 2).Count());
            Console.WriteLine("Cong ty ELCA3: "+ lst.Where(t=> t.Cty == 3).Count());
        }
        //(10).	Xuất danh sách nhân viên các công ty thành viên có thâm niên trên 10 năm.
        public void ThanhVienCoThamNienTren10Nam()
        {
            xuat(lst.Where(t => t.Thamnien() > 10).ToList());
        }
        //(13).Xuất thông tin các nhân viên là chiến sĩ thi đua của tổng công ty ELCA.
        public void NhanVienLaChienSiThiDua()
        {
            xuat(lst.Where(t => t.XepLoaiThiDua().Equals("Chien si thi dua")).ToList());
        }

        //(11).	Xuất tổng phụ cấp thâm niên trong năm 2021 của ELCA 1, 2, 3; 
        public void TongPCTNTheoNam(int nam)
        {
            Console.WriteLine("Tong phu cap tham nien phai tra:");
            Console.WriteLine("Cong ty ELCA1: " + lst.Where(a => a.Cty == 1).Select(t => t.tongPCTheoNam(nam)).Sum());
            Console.WriteLine("Cong ty ELCA2: " + lst.Where(a => a.Cty == 2).Select(t => t.tongPCTheoNam(nam)).Sum());
            Console.WriteLine("Cong ty ELCA3: " + lst.Where(a => a.Cty == 3).Select(t => t.tongPCTheoNam(nam)).Sum());
        }

        //(12).	Xuất tổng lương năm 2021 của ELCA 1, 2, 3;
        public void TongLuongNam2021()
        {
            Console.WriteLine("Tong luong phai tra:");
            Console.WriteLine("Cong ty ELCA1: "+ lst.Where(a => a.Cty == 1).Select(t => t.TongLuong2021()).Sum());
            Console.WriteLine("Cong ty ELCA2: "+ lst.Where(a => a.Cty == 2).Select(t => t.TongLuong2021()).Sum());
            Console.WriteLine("Cong ty ELCA3: "+ lst.Where(a => a.Cty == 3).Select(t => t.TongLuong2021()).Sum());
        }
        //14.Xuất danh sách các nhân viên không đạt chỉ tiêu trong tháng 1/2021 của công ty ELCA 
        public void xuatDSKhongDatChiTieu_01_2021()
        {

            xuat(lst.Where(t => t.ChuaDatChiTieu_1_2021() == true).ToList());
              
        }

    }
}