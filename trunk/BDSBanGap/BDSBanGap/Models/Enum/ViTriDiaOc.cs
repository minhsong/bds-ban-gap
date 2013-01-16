using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BDSBanGap.Helpers;

namespace BDSBanGap.Models.Enum
{
    public class ViTriDiaOc
    {
        public static string GetViTriDiaOc(ViTriDiaOcEnum pl)
        {
            return GetViTriDiaOc((int)pl);
        }

        public static string GetViTriDiaOc(int loai)
        {
            return GetListViTriDiaOc().Find(s => s.ItemValue == loai).DisplayValue;
        }

        public static List<ComboItem> GetListViTriDiaOc()
        {
            List<ComboItem> result = new List<ComboItem>();

            result.Add(new ComboItem()
            {
                DisplayValue = "Hẻm xe hơi",
                ItemValue = (int)ViTriDiaOcEnum.HemXeHoi,
            });
            result.Add(new ComboItem()
            {
                DisplayValue = "Hẻm xe máy",
                ItemValue = (int)ViTriDiaOcEnum.HemXeMay,
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "Mặt tiền đường",
                ItemValue = (int)ViTriDiaOcEnum.MatTienDuong,
            });
            return result;
        }
    }

    public enum ViTriDiaOcEnum
    {
        MatTienDuong = 1,
        HemXeHoi = 2,
        HemXeMay = 3,
    }
}