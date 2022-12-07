namespace AEONSHOP.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietNhapKho")]
    public partial class ChiTietNhapKho
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaHoaDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaSanPham { get; set; }

        public int? SoLuongNhap { get; set; }

        public double? DonGiaNhap { get; set; }

        public double? ThanhTien { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
