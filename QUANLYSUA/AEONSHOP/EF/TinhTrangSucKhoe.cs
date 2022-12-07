namespace AEONSHOP.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinhTrangSucKhoe")]
    public partial class TinhTrangSucKhoe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TinhTrangSucKhoe()
        {
            KhachHang = new HashSet<KhachHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaTinhTrangSK { get; set; }

        [Required]
        [StringLength(100)]
        public string TenTinhTrang { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHang { get; set; }
    }
}
