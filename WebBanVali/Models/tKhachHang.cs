﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel;


    public partial class tKhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tKhachHang()
        {
            this.tHoaDonBans = new HashSet<tHoaDonBan>();
        }
        

        public int MaKhachHang { get; set; }
        [DisplayName("Tên khách hàng")]
        public string TenKhachHang { get; set; }
        [DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }
        [DisplayName("Tên đăng nhập")]
        public string username { get; set; }
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tHoaDonBan> tHoaDonBans { get; set; }
    }
}
