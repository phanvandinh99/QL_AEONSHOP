namespace AEONSHOP.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSanPham")]
    public partial class ChiTietSanPham
    {
        [Key]
        [Column(Order = 0)]
        public DateTime NgaySanXuat { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime HanSuDung { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string MaSanPham { get; set; }

        public int? NgaySuDungConLai { get; set; }

        public int? SoLuongHienCon { get; set; }

        public double DonGiaNhap { get; set; }

        public double DonGiaBan { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
