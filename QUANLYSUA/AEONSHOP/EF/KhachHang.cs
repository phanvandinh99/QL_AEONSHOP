namespace AEONSHOP.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(12)]
        public string SDT { get; set; }

        [Required]
        [StringLength(200)]
        public string HoTen { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        public string Sothich { get; set; }

        [StringLength(10)]
        public string MaCongViec { get; set; }

        [StringLength(10)]
        public string MaThuNhap { get; set; }

        [StringLength(10)]
        public string MaTinhTrangSK { get; set; }

        public virtual CongViec CongViec { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDon { get; set; }

        public virtual ThuNhap ThuNhap { get; set; }

        public virtual TinhTrangSucKhoe TinhTrangSucKhoe { get; set; }
    }
}
