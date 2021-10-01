using System;
using System.Collections.Generic;
using System.Xml;

namespace HDT.DTO
{
    public class QuanLyPhongBan
    {
        List<PhongBan> lst = new List<PhongBan>();
        public List<PhongBan> Lst 
        { 
            get => lst; 
            set => lst = value; 
        }
        public void Them(PhongBan a)
        {
            lst.Add(a);
        }
        public int Xoa(PhongBan a)
        {

            foreach(PhongBan pb in lst)
            {
                if (pb.MaPB.Equals(a.MaPB))
                {
                    lst.Remove(pb);
                    return 1;
                }
            }

            return 0;
        }
        public int Sua(PhongBan a)
        {
            foreach(PhongBan pb in lst)
            {
                if(pb.MaPB.Equals(a.MaPB))
                {
                    pb.MaPB = a.MaPB;
                    pb.TenPB = a.TenPB;
                    return 1;
                }
            }
            return 0;
        }

        public void DocDuLieu(String filename)
        {
            XmlDocument read = new XmlDocument();
            read.Load(filename);

            XmlNodeList nodeLst = read.SelectNodes("DSPB/PhongBan");

            foreach (XmlNode node in nodeLst)
            {
                PhongBan pb = new PhongBan();

                pb.TenPB = node["TenPB"].InnerText;

                pb.MaPB = node["MaPB"].InnerText;

                lst.Add(pb);
            }
        }
        public void xuatDSPhongBan()
        {
            foreach (PhongBan pb in lst)
            {
                pb.Xuat();
            }
        }
    }
}
