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
    
    public partial class tHoaDonBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tHoaDonBan()
        {
            this.tChiTietHDBs = new HashSet<tChiTietHDB>();
        }
    
        public int MaHoaDon { get; set; }
        public System.DateTime NgayBan { get; set; }
        public Nullable<int> MaKhachHang { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tChiTietHDB> tChiTietHDBs { get; set; }
        public virtual tKhachHang tKhachHang { get; set; }
    }
}
