//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanVali.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tChiTietHDB
    {
        public int MaChiTietHDB { get; set; }
        public Nullable<int> MaHoaDon { get; set; }
        public Nullable<int> MaChiTietSP { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
    
        public virtual tChiTietSanPham tChiTietSanPham { get; set; }
        public virtual tHoaDonBan tHoaDonBan { get; set; }
    }
}
