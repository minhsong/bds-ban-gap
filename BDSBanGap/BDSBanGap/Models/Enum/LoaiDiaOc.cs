using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BDSBanGap.Helpers;

namespace BDSBanGap.Models.Enum
{
    public class LoaiDiaOc
    {
        public static string GetLoaiDiaOc(LoaiDiaOcEnum loai)
        {
            return GetLoaiDiaOc((int)loai);
        }

        public static string GetLoaiDiaOc(int loai)
        {
            return GetListLoaiDiaOc().Find(s => s.ItemValue == loai).DisplayValue;
        }

        public static List<ComboItem> GetListLoaiDiaOc()
        {
            List<ComboItem> result = new List<ComboItem>();
            result.Add(new ComboItem()
            {
                DisplayValue = "Nhà ở",
                ItemValue = (int)LoaiDiaOcEnum.LoaiDiaOc_Nha_O,
            });
            result.Add(new ComboItem()
            {
                DisplayValue = "Chung Cư",
                ItemValue = (int)LoaiDiaOcEnum.LoaiDiaOc_Chung_Cu,
            });

            result.Add(new ComboItem()
            {
                DisplayValue = "Đất nền",
                ItemValue = (int)LoaiDiaOcEnum.LoaiDiaOc_Dat_Nen,
            });

            return result;
        }
    }

    public enum LoaiDiaOcEnum
    {
        LoaiDiaOc_Nha_O = 1,
        LoaiDiaOc_Chung_Cu = 2,
        LoaiDiaOc_Dat_Nen = 3,
    }
}