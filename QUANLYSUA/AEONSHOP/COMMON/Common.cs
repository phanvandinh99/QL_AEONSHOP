using AEONSHOP.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEONSHOP.COMMON
{
    public class Common
    {
        EF_AEONSHOP db = new EF_AEONSHOP();

        #region Số hóa đơn tăng dần
        public string MaHoaDon()
        {
            // Tìm hóa đơn cao nhất
            string sMaHoaDon = db.HoaDon.Max(n => n.MaHoaDon.Substring(2).Trim());
            int iMaHoaDon = int.Parse(sMaHoaDon) + 1;
            sMaHoaDon = "HD000" + iMaHoaDon;

            return sMaHoaDon;

        }
        // Số hóa đơn tăng dần

        #endregion

    }
}
