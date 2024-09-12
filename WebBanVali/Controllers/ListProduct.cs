using PagedList;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Dynamic;
using System.Linq;
using WebBanVali.Models;

namespace WebBanVali.Controllers
{
    public class ListProduct
    {
        private QLBanVaLiEntities db = new QLBanVaLiEntities();
        private DbSet<tChiTietSanPham> tCT;
        List<tChiTietSanPham> listProduct;
        int npp = 9;
        int count = 0;
        bool iscategoryId, isminPrice, ismaxPrice, iscolor, issize, isproductName;
        int? categoryId;
        double? minPrice;
        double? maxPrice;
        string color;
        string size;
        string productName;

        public ListProduct()
        {   tCT = db.tChiTietSanPhams;
            listProduct = tCT.ToList();
            count = listProduct.Count;
            iscategoryId = false;
            iscolor = false;
            issize = false;
            isminPrice = false;
            ismaxPrice = false;
            isproductName = false;
            categoryId = 1;
            minPrice = 0;
            maxPrice = double.PositiveInfinity;
            color = string.Empty;
            size = string.Empty;
            productName = string.Empty;

        }

        public tChiTietSanPham getProduct(int id)
        {
            return tCT.Find(id);
        }
        public List<tChiTietSanPham> getListProduct()
        {
            return listProduct;
        }
        public IPagedList<tChiTietSanPham> getListProduct(int page, int? categoryId, double? minPrice, double? maxPrice, string color, string size, string productName)
        {
            if (categoryId.HasValue)
            {
                iscategoryId = true; this.categoryId = categoryId;
            }
            if (minPrice.HasValue)
            {
                isminPrice = true; this.minPrice = minPrice;
            }
            if (maxPrice.HasValue)
            {
                ismaxPrice = true; this.maxPrice = maxPrice;
            }
            if (!string.IsNullOrEmpty(color))
            {
                iscolor = true; this.color = color;
            }
            if (!string.IsNullOrEmpty(size))
            {
                issize = true; this.size = size;
            }
            if (!string.IsNullOrEmpty(productName))
            {
                isproductName = true; this.productName = productName;
            }
            return ListProductAfterFilt(page);
        }
        public IPagedList<tChiTietSanPham> getListProduct(string productName)
        {
            if (!string.IsNullOrEmpty(productName))
            {
                isproductName = true; this.productName = productName;
            }
            return ListProductAfterFilt(1);
        }
        public IPagedList<tChiTietSanPham> getListProduct(int page)
        {
            return ListProductAfterFilt(page);
        }
        public IPagedList<tChiTietSanPham> ListProductAfterFilt(int page)
        {
            var query = tCT.AsQueryable();
            if (iscategoryId)
            {
                query = query.Where(p => p.MaDM == categoryId);
            }
            if (isminPrice)
            {
                query = query.Where(p => p.DonGiaBan >= minPrice);
            }
            if (ismaxPrice)
            {
                query = query.Where(p => p.DonGiaBan <= maxPrice);
            }
            if (iscolor)
            {
                query = query.Where(p => p.MauSac.ToLower() == color.ToLower());
            }
            if (issize)
            {
                query = query.Where(p => p.KichThuoc == size);
            }
            if (isproductName)
            {
                query = query.Where(p => p.TenChiTietSP.Contains(productName));
            }
            return query.OrderBy(p => p.MaChiTietSP).ToPagedList((int)page, npp);
        }
    }
}