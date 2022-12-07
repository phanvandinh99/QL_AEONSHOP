namespace AEONSHOP.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDon = new HashSet<ChiTietHoaDon>();
            ChiTietNhapKho = new HashSet<ChiTietNhapKho>();
            ChiTietSanPham = new HashSet<ChiTietSanPham>();
        }

        [Key]
        [StringLength(10)]
        public string MaSanPham { get; set; }

        [Required]
        [StringLength(255)]
        public string TenSanPham { get; set; }

        public int? DaBan { get; set; }

        public string Anh { get; set; }

        public string MoTa { get; set; }

        [StringLength(10)]
        public string MaLoaiSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhapKho> ChiTietNhapKho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSanPham> ChiTietSanPham { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
