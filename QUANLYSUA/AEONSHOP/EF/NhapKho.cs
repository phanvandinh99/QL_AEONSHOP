namespace AEONSHOP.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhapKho")]
    public partial class NhapKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhapKho()
        {
            ChiTietNhapKho = new HashSet<ChiTietNhapKho>();
        }

        [Key]
        [StringLength(10)]
        public string MaNhapKho { get; set; }

        public DateTime NgayNhapKho { get; set; }

        public double TongTien { get; set; }

        [StringLength(50)]
        public string TaiKhoanNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhapKho> ChiTietNhapKho { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
