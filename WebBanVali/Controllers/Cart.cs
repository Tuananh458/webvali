
using System;
using System.Collections.Generic;
using System.Linq;
using WebBanVali.Models;

namespace WebBanVali
{
    public class Cart
    {
        private Dictionary<int, CartItem> listcarts;
        private QLBanVaLiEntities db;

        public List<CartItem> GetLISTCARTS => this.listcarts.Values.ToList<CartItem>();

        public Cart()
        {
            listcarts = new Dictionary<int, CartItem>();
            db = new QLBanVaLiEntities();
        }

        public void AddCart(int masanpham, int count)
        {
            CartItem product = new CartItem(db.tChiTietSanPhams.Find(masanpham));

            if (product != null && count > 0)
            {
                if (listcarts.ContainsKey(masanpham))
                {
                    listcarts[masanpham].SoLuong += count;
                }
                else
                {
                    listcarts.Add(masanpham, product);
                    listcarts[masanpham].SoLuong = count;
                }
            }
        }
        public string HangHet()
        {
            foreach (CartItem item in listcarts.Values)
            {
                if (item.HetHang) return item.TenChiTietSP;
            }
            return null;
        }

        public void RemoveCart(int masanpham)
        {
            if (listcarts.ContainsKey(masanpham))
            {
                listcarts.Remove(masanpham);
            }
        }

        public double Total
        {
            get
            {
                double total = 0;
                foreach (CartItem item in listcarts.Values)
                {
                    total += item.ThanhTien;
                }
                return total;
            }
        }
        public double SubTotal
        {
            get
            {
                double total = 0;
                foreach (CartItem item in listcarts.Values)
                {
                    total += item.TienHang;
                }
                return total;
            }
        }
        public double Discout => SubTotal - Total;


        internal void UpdateQuantity(int maSanPham, int newQuantity)
        {
            if (listcarts.ContainsKey(maSanPham))
            {
                listcarts[maSanPham].SoLuong = newQuantity;
            }
        }
        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (CartItem item in listcarts.Values)
                {
                    sum += item.SoLuong;
                }
                return sum;
            }
        }
        public int Count => listcarts.Count;
    }

    public class CartItem
    {
        public int MaChiTietSP { get; set; }
        public string TenChiTietSP { get; set; }
        public double DonGiaBan { get; set; }
        public int SoLuong { get; set; }
        public string AnhDaiDien { get; set; }
        public Nullable<double> GiamGia {  get; set; }

        // Các thuộc tính khác của sản phẩm nếu cần

        public CartItem()
        {
        }
        public CartItem(tChiTietSanPham tChiTietSanPham)
        {
            MaChiTietSP = tChiTietSanPham.MaChiTietSP;
            TenChiTietSP = tChiTietSanPham.TenChiTietSP;
            DonGiaBan = (double)tChiTietSanPham.DonGiaBan;
            GiamGia = tChiTietSanPham.GiamGia; 
            SoLuong = 1;
            AnhDaiDien = tChiTietSanPham.AnhDaiDien;
        }
        public string TienGiam => (SoLuong * DonGiaBan * (GiamGia ?? 0)).ToString("0.00");
        public double ThanhTien => SoLuong * DonGiaBan * (1 - GiamGia ?? 0);
        public double TienHang => SoLuong * DonGiaBan;
        public bool HetHang => (SoLuong > (new QLBanVaLiEntities().tChiTietSanPhams.Find(MaChiTietSP).SLTon));


        public CartItem(int maChiTietSP, string tenChiTietSP, double donGiaBan, int soLuong, string anhDaiDien)
        {
            MaChiTietSP = maChiTietSP;
            TenChiTietSP = tenChiTietSP;
            DonGiaBan = donGiaBan;
            SoLuong = soLuong;
            AnhDaiDien = anhDaiDien;
        }
    }
}