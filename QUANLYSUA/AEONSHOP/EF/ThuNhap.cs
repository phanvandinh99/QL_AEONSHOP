namespace AEONSHOP.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuNhap")]
    public partial class ThuNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThuNhap()
        {
            KhachHang = new HashSet<KhachHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaThuNhap { get; set; }

        [Required]
        [StringLength(100)]
        public string TenThuNhap { get; set; }

        [StringLength(100)]
        public string SoTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHang { get; set; }
    }
}
