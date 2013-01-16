using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BDSBanGap.Helpers;

namespace BDSBanGap.Models.Enum
{
    public class TinhTrangPhapLy
    {
        public static string GetTinhTrangPhapLy(TinhTrangPhapLyEnum pl)
        {
            return GetTinhTrangPhapLy((int)pl);
        }

        public static string GetTinhTrangPhapLy(int loai)
        {
            return GetListTinhTrangPhapLy().Find(s => s.ItemValue == loai).DisplayValue;
        }

        public static List<ComboItem> GetListTinhTrangPhapLy()
        {
            List<ComboItem> result = new List<ComboItem>();

            result.Add(new ComboItem()
            {
                DisplayValue = "Sổ Hồng",
                ItemValue = (int)TinhTrangPhapLyEnum.TinhTrangPhapLy_So_Hong,
            });
            result.Add(new ComboItem()
            {
                DisplayValue = "Không Sổ Hồng",
                ItemValue = (int)TinhTrangPhapLyEnum.TinhTrangPhapLy_Khong_So_Hong,
            });
            return result;
        }
    }

    public enum TinhTrangPhapLyEnum
    {
        TinhTrangPhapLy_So_Hong = 1,
        TinhTrangPhapLy_Khong_So_Hong = 2
    }
}